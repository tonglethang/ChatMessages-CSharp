using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using System.Runtime.InteropServices;

namespace TongLeThang_ChatMessages
{
    public partial class frmSever : Form
    {
        Socket sever;
        List<Socket> listClient = new List<Socket>();
        IPEndPoint endPoint;
        int port = 5161;
        IPAddress ipAddress;
        string path = "";
        List<int> listPos = new List<int>();
        public frmSever()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Connect();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if(path != "")
            {
                Image image1 = Image.FromFile(path);
                Clipboard.SetImage(image1);
                listMess.AppendText("Tôi: \n");
                listMess.Paste();
                listMess.AppendText("\n");
            }
            else
            {
                listMess.AppendText("Tôi: \n" + txtMess.Text + "\n");
            }

            foreach (Socket item in listClient)
            {
                SendMess(item);
            }   
            path = "";
            txtMess.Text = "";
        }

 
        private void Connect()
        {
            sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ipAddress = IPAddress.Any;
            endPoint = new IPEndPoint(ipAddress, port);
            sever.Bind(endPoint);

            Console.WriteLine("Cho ket noi tu Client !");
            int tmp = 0;
            Thread threadListen = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        sever.Listen(50);
                        Socket client = sever.Accept();
                        listClient.Add(client);
                        if (checkSocketConnected(client))
                        {
                            tmp++;
                            listPos.Add(tmp);
                        }
                        Thread threadReceive = new Thread(ReceiveMess);
                        threadReceive.SetApartmentState(ApartmentState.STA);
                        threadReceive.IsBackground = true;
                        threadReceive.Start(client);

                    }
                    catch
                    {
                        sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        endPoint = new IPEndPoint(ipAddress, port);
                    }
                }
            });
            threadListen.IsBackground = true;
            threadListen.Start();

        }
        private void SendMess(Socket client)
        {
            if (path != "")
            {
                Image image = Image.FromFile(path);
                byte[] data = new byte[1024 * 10000];
                data = ImageToByteArray(image);
                client.Send(data);

            }
            else
            {
                if (txtMess.Text != String.Empty)
                {
                    byte[] data = new Byte[1024 * 5000];
                    string str = txtMess.Text;
                    data = EnCode(str);
                    client.Send(EnCode(str));
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tin nhắn !");
                }
            }
        }
          
        private void ReceiveMess(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    if (IsValidImage(data))
                    {
                        Image image = byteArrayToImage(data);
                        Clipboard.SetImage(image);
                        listMess.AppendText("Client " + client.LocalEndPoint + ": \n");
                        listMess.Paste();
                        listMess.AppendText("\n");
                    }
                    else
                    {
                        string str = DeCode(data);
                        if (str != null || str != String.Empty)
                            listMess.AppendText("Client " + client.LocalEndPoint + ": \n" + str);
                        listMess.AppendText("\n");

                    }
                }
            }
            catch
            {
                MessageBox.Show("Một Client đã ngắt kết nối !", "Thông báo !");
            }
    
        }
        private string DeCode(byte[] data)
        {
            return Encoding.Unicode.GetString(data);
        }
        private byte[] EnCode(string str)
        {
            return Encoding.Unicode.GetBytes(str);
        }

        private void frmSever_Load(object sender, EventArgs e)
        {


            for (int i = 0; i < 5; i++)
            {
                Button btnClient = new Button();

                btnClient.Name = "btnClient";
                btnClient.Size = new System.Drawing.Size(180, 81);
                btnClient.TabIndex = 0;
                btnClient.Text = "Client1";
                btnClient.UseVisualStyleBackColor = true;
                panelClient.Controls.Add(btnClient);
            }
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);

            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private bool IsValidImage(byte[] bytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                    Image.FromStream(ms);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Filter = "Image|*.bmp;*.jpg;*.gif;*.png;*.tif";
            image.ShowDialog();
            path = image.FileName;
            if (path != "")
            {
                Clipboard.SetImage(Image.FromFile(path));
                txtMess.Paste();
            }
        }
        private bool checkSocketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }
    }
}
