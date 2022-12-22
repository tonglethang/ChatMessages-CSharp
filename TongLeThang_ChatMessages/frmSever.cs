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

namespace TongLeThang_ChatMessages
{
    public partial class frmSever : Form
    {
        Socket sever;
        List<Socket> listClient = new List<Socket>();
        IPEndPoint endPoint;
        int port = 5000;
        IPAddress ipAddress;
        String path = "";
        public frmSever()
        {
            InitializeComponent();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            foreach (Socket item in listClient)
            {
                SendMess(item);
            }

        }

        private void frmSever_FormClosed(object sender, FormClosedEventArgs e)
        {
            sever.Close();
        }
        private void Connect()
        {
            sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ipAddress = IPAddress.Any;
            endPoint = new IPEndPoint(ipAddress, port);
            sever.Bind(endPoint);

            Console.WriteLine("Cho ket noi tu Client !");

            Thread threadListen = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        sever.Listen(50);
                        Socket client = sever.Accept();
                        listClient.Add(client);

                        Thread threadReceive = new Thread(ReceiveMess);
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
            string str = txtMess.Text.ToString();
            if (txtMess.Text != String.Empty)
            {
                client.Send(EnCode(str));
                listMess.Items.Add("Tôi: ");
                listMess.Items.Add(txtMess.Text.ToString());
                txtMess.Text = "";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tin nhắn !");
            }
        }
        private void ReceiveMess(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 100000];
                    client.Receive(data);

                    if (IsValidImage(data))
                    {

                        Image image = byteArrayToImage(data);

                        imageList1.Images.Add(image);
                        this.imageList1.ImageSize = new Size(200, 250);
                        listMess.Items.Add("Client " + listClient.Count  + ": ") ;
                        listMess.LargeImageList = imageList1;
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = imageList1.Images.Count - 1 ;
                        listMess.Items.Add(item);
                    }
                    else
                    {        
                        string str = DeCode(data);
                        if (str != null || str != String.Empty)
              
                            listMess.Items.Add("Client " + listClient.Count + ": " + str);
   
   
                    }
                }
            }
            catch
            {
                listClient.Remove(client);
                client.Close();
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
            Connect();

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
    }
}
