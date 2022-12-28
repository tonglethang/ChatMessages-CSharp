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
                listMess.SelectionAlignment = HorizontalAlignment.Right;
                listMess.ReadOnly = false;
                listMess.SelectionFont = new Font("Times New Roman", 12, FontStyle.Regular);
                listMess.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n");
                listMess.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
                listMess.AppendText(txtMess.Text + "\n");
                listMess.ReadOnly = true;
            }
            else if (icon != null)
            {
                listMess.SelectionAlignment = HorizontalAlignment.Right;
                listMess.ReadOnly = false;
                Clipboard.SetImage(icon);
                listMess.SelectionFont = new Font("Times New Roman", 12, FontStyle.Regular);
                listMess.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n");
                listMess.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
                listMess.Paste();
                listMess.AppendText("\n");
                listMess.ReadOnly = true;
            }
            else if (path != "")
            {
                listMess.SelectionAlignment = HorizontalAlignment.Right;
                listMess.ReadOnly = false;
                Image image1 = Image.FromFile(path);
                Clipboard.SetImage(image1);
                listMess.SelectionFont = new Font("Times New Roman", 12, FontStyle.Regular);
                listMess.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n");
                listMess.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
                listMess.Paste();
                listMess.AppendText("\n");
                listMess.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tin nhắn !");

            }
            try
            {
                for(int i = 0; i < cbListClient.Items.Count; i++)
                {
                    if(cbListClient.GetItemCheckState(i) == CheckState.Checked)
                    {
                        SendMess(listClient[i]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống lỗi !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        getListClient(client.LocalEndPoint.ToString());
                        // Get status all client send mess to sever or client
                        getStatusAllClient(client);
                        //
                        //Send list client connected to all client
                        string strListClient = "";
                        foreach(Socket item in listClient)
                        {
                            strListClient += item.LocalEndPoint.ToString() + "&";
                        }
                        foreach (Socket item in listClient)
                        {
                            item.Send(EnCode(strListClient + ";"));
                            Console.WriteLine(strListClient + ";");
                        }
                        //
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
            threadListen.SetApartmentState(ApartmentState.STA);
            threadListen.IsBackground = true;
            threadListen.Start();

        }
        private void SendMess(Socket client)
        {
            if (txtMess.Text != String.Empty && icon == null && path == "")
            {
                byte[] data = new byte[1024 * 5000];
                string str = txtMess.Text;
                data = EnCode(str);
                client.Send(EnCode(str));

            }
            else if (icon != null && path == "")
            {
                byte[] data = new byte[1024 * 5000];
                data = ImageToByteArray(icon);
                client.Send(data);
            }
            else if (path != "" && icon == null)
            {
                Image image = Image.FromFile(path);
                byte[] data = new byte[1024 * 5000];
                data = ImageToByteArray(image);
                client.Send(data);
            }


        }

        private void ReceiveMess(object obj)
        {
            Socket client = obj as Socket;
            string ipSendTo = "";
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    //Check Client want send messages to Sever or Client
                    string[] strCheck = DeCode(data).Split(' ');

                    if (strCheck[0].Contains("!client"))
                    {
                        string[] addressClient = strCheck[0].Split('&');
                        ipSendTo = addressClient[1];
                        for(int i = 0; i < cbStatusListClient.Items.Count; i++)
                        {
                            if (cbStatusListClient.Items[i].ToString().Equals(client.LocalEndPoint.ToString()))
                            {
                                cbStatusListClient.SetItemCheckState(i, CheckState.Checked);

                            }
                        }
                    }
                    else if (strCheck[0].Contains("!sever"))
                    {
                        for (int i = 0; i < cbStatusListClient.Items.Count; i++)
                        {
                            if (cbStatusListClient.Items[i].ToString().Equals(client.LocalEndPoint.ToString()))
                            {
                                cbStatusListClient.SetItemCheckState(i, CheckState.Unchecked);
                            }
                        }
                    }
                    else
                    {
                        bool check = true;
                        for (int i = 0; i < cbStatusListClient.Items.Count; i++)
                        {
                            if (cbStatusListClient.Items[i].ToString().Equals(client.LocalEndPoint.ToString()) && cbStatusListClient.GetItemChecked(i) == true)
                            {
                                string[] ip = ipSendTo.Split(':');
   
                                IPEndPoint addressClient = new IPEndPoint(IPAddress.Parse(ip[0]), 5161);
                                foreach (Socket item in listClient)
                                {               
                                    if (item.LocalEndPoint.ToString() == addressClient.ToString())
                                    {
                                        check = false;
                                        item.Send(EnCode("!NameClient&" + client.LocalEndPoint + ";"));
                                        item.Send(data);
                                    }
                                }
                            }
                        }
                        if (check)
                        {
                            if (IsValidImage(data))
                            {
                                listMess.SelectionAlignment = HorizontalAlignment.Left;
                                listMess.ReadOnly = false;
                                Image image = byteArrayToImage(data);
                                Clipboard.SetImage(image);
                                listMess.SelectionFont = new Font("Times New Roman", 12, FontStyle.Regular);
                                listMess.AppendText("Client " + client.LocalEndPoint + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "):  \n");
                                listMess.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
                                listMess.Paste();
                                listMess.AppendText("\n");
                                listMess.ReadOnly = true;
                            }
                            else
                            {
                                listMess.SelectionAlignment = HorizontalAlignment.Left;
                                listMess.ReadOnly = false;
                                listMess.SelectionFont = new Font("Times New Roman", 12, FontStyle.Regular);
                                string str = DeCode(data);
                                if (str != null || str != String.Empty)

                                    listMess.AppendText("Client " + client.LocalEndPoint + " " + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n");
                                    listMess.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
                                    listMess.AppendText(str);
                                listMess.AppendText("\n");
                                listMess.ReadOnly = true;
                            }
                        }
                    }                   
                }
            }
            catch
            {
                client.Close();
                string strListClient = "";
                for(int i = 0; i < listClient.Count; i++)
                {
                    if(client == listClient[i])
                    {
                        listClient.Remove(listClient[i]);
                        cbListClient.Items.Remove(cbListClient.Items[i]);
                        cbStatusListClient.Items.Remove(cbStatusListClient.Items[i]);
                    }
                }

                foreach (Socket item in listClient)
                {
                    strListClient += item.LocalEndPoint.ToString() + "&";

                }
                foreach (Socket item in listClient)
                {
                    item.Send(EnCode(strListClient + ";"));
                }
                Console.WriteLine("Một Client đã ngắt kết nối");
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

        private static String getPathIcon()
        {
            string pathIcon = Environment.CurrentDirectory.ToString(); 
            var url = Directory.GetParent(Directory.GetParent(pathIcon).ToString()); 

            return url.ToString();

        }
        private void btnIcon_Click(object sender, EventArgs e)
        {
            string filePath = getPathIcon() + @"\Icons";
            string[] files = Directory.GetFiles(filePath);
            foreach (String f in files)
            {
                Image img = Image.FromFile(f);  
                imageList.Images.Add(img); 
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

        private void getListClient(string nameClient)
        {
            this.cbListClient.Items.Add("Client " + nameClient, CheckState.Checked);
    
        }
        private void getStatusAllClient(Socket item)
        {
            cbStatusListClient.Items.Add(item.LocalEndPoint.ToString());
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa tất cả tin nhắn ", "Thông báo !", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                listMess.ReadOnly = false;
                listMess.SelectAll();
                if (listMess.SelectionLength > 0)
                    listMess.SelectedText = listMess.SelectedText.Replace(listMess.SelectedText, "");
                listMess.ReadOnly = true;
            }
        }
    }
}
