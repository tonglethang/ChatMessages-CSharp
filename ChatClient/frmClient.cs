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

namespace ChatClient
{
    public partial class frmClient : Form
    {
        Socket client;
        IPEndPoint endPoint;
        int port = 5000;
        IPAddress ipAddress;
        string path = "";
        public frmClient()
        {
            InitializeComponent();

        }
        private void Connect()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ipAddress = IPAddress.Parse("127.0.0.1");
            endPoint = new IPEndPoint(ipAddress, port);

            client.Connect(endPoint);
            Thread thread = new Thread(ReceiveMess);
            thread.IsBackground = true;
            thread.Start();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMess();
        }
        private void SendMess()
        {
            string str =  txtMess.Text;
            if (txtMess.Text != String.Empty && path == "")
            {
                client.Send(EnCode(str));

                listMess.AppendText("Tôi: \n" + txtMess.Text + "\n");
                txtMess.Text = "";
            }
            else if(path != "")
            {
                Image image = Image.FromFile(path);
                byte[] data = new byte[1024*10000];
                data = ImageToByteArray(image);
                client.Send(data);
                Clipboard.SetImage(image);
                listMess.AppendText("Tôi: \n");
 
                listMess.Paste();
                listMess.AppendText("\n");
                path = "";
                txtMess.Text = "";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tin nhắn !");
            }
        }
        private void ReceiveMess()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 10000];
                    client.Receive(data);
                    string str = DeCode(data);
         /*           if (str != null)
                    {
                        listMess.AppendText("Sever: \n" + str);
                        listMess.AppendText("\n");
                    }*/
                }
            }
            catch
            {
                client.Close();
            }   
        }
        private byte[] EnCode(string str)
        {
            return Encoding.Unicode.GetBytes(str);
        }
        private string DeCode(byte[] data)
        {
            return Encoding.Unicode.GetString(data);
        }
        private void frmClient_Load(object sender, EventArgs e)
        {
            Connect();
          
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
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
