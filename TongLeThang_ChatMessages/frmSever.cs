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
using System.Drawing.Imaging;

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
        Image icon;
        public static int ip = 1;

        public frmSever()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMess.Text != String.Empty && path == "" && icon == null)
            {
                listMess.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n" + txtMess.Text + "\n");
            }
            else if(icon != null)
            {
                Clipboard.SetImage(icon);
                listMess.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + ") \n");
                listMess.Paste();
                listMess.AppendText("\n");
            }
            else if(path != "")
            {
                Image image1 = Image.FromFile(path);
                Clipboard.SetImage(image1);
                listMess.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n");
                listMess.Paste();
                listMess.AppendText("\n");
            }

            foreach (Socket item in listClient)
            {
                SendMess(item);
            }   
            path = "";
            txtMess.Text = "";
            icon = null;
        }

        private void Connect()
        {
            sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ipAddress = IPAddress.Any;
            endPoint = new IPEndPoint(ipAddress, port);
            sever.Bind(endPoint);
            sever.Listen(50);
            Console.WriteLine("Cho ket noi tu Client !");

            Thread threadListen = new Thread(() =>
            {
                while (true)
                {
                    try
                    {

                        Socket client = sever.Accept();
                        listClient.Add(client);

/*                            CheckBox checkBox = new CheckBox();
                            checkBox.Name = listClient.Count + "";
                            checkBox.Text = "als" + listClient.Count;
                            this.panelClient.Controls.Add(checkBox);*/
     
                        Thread threadReceive = new Thread(ReceiveMess);
                        threadReceive.SetApartmentState(ApartmentState.STA);
                        threadReceive.IsBackground = true;
                        threadReceive.Start(client);
                    }
                    catch
                    {
                        sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        endPoint = new IPEndPoint(ipAddress, port);
                        sever.Bind(endPoint);
                    }
                }
            });
            threadListen.SetApartmentState(ApartmentState.STA);
            threadListen.IsBackground = true;
            threadListen.Start();
            for (int i = 0; i < listClient.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Name = i + "";
                checkBox.Text = "als" + i;
                this.panelClient.Controls.Add(checkBox);
            }
        }
        private void SendMess(Socket client)
        {
            if (txtMess.Text != String.Empty && icon == null && path == "")
            {
                byte[] data = new Byte[1024 * 5000];
                string str = txtMess.Text;
                data = EnCode(str);
                client.Send(EnCode(str));

            }
            else if(icon != null && path == "")
            {
                byte[] data = new byte[1024 * 5000];
                data = ImageToByteArray(icon);
                client.Send(data);


            }
            else if (path != "" && icon ==null)
            {
                Image image = Image.FromFile(path);
                byte[] data = new byte[1024 * 5000];
                data = ImageToByteArray(image);
                client.Send(data);
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
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    if (IsValidImage(data))
                    {
                        Image image = byteArrayToImage(data);
                        Clipboard.SetImage(image);
                        listMess.AppendText("Client " + client.LocalEndPoint +" " + "(" + DateTime.Now.ToString("h:mm:ss tt")+ "):  \n");
                        listMess.Paste();
                        listMess.AppendText("\n");
                    }
                    else
                    {
                        string str = DeCode(data);
                        if (str != null || str != String.Empty)
                            listMess.AppendText("Client " + client.LocalEndPoint + " "+ "(" + DateTime.Now.ToString("h:mm:ss tt")+ "): \n" + str);
                        listMess.AppendText("\n");

                    }
                }
            }
            catch
            {
                client.Close();
                listClient.Remove(client);
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
            Connect();

        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Png);
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

        private void btnIcon_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\Documents\WinForm\TongLeThang_MiniWord\TongLeThang_MiniWord\icon");
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    this.imageList.Images.Add(file.Name, Image.FromFile(file.FullName));
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
            this.listIcon.View = View.LargeIcon;
            this.imageList.ImageSize = new Size(32, 32);
            this.listIcon.LargeImageList = this.imageList;

            for (int j = 0; j < this.imageList.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                this.listIcon.Items.Add(item);

            }

            listIcon.Visible = true;
        }
        int pos = 0;
        private void listIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listIcon.FocusedItem == null) return;
                pos = listIcon.SelectedIndices[0];
                Clipboard.SetImage(imageList.Images[pos]);
                icon = imageList.Images[pos];
                txtMess.Paste();
            }
            catch (Exception)
            {
                return;
            }

            listIcon.Visible = false;
        }

        private void listIcon_MouseLeave(object sender, EventArgs e)
        {
            listIcon.Visible = false;
        }
    }
}
