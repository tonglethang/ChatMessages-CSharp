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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Imaging;
using TongLeThang_ChatMessages;

namespace ChatClient
{
    public partial class frmClient : Form
    {
        Socket client;
        IPEndPoint endPoint;
        int port = 5161;
        IPAddress ipAddress;
        Image icon;
        string path = "";
        static Random rnd = new Random();
        int ip = rnd.Next(100);
        public frmClient()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

        }
        private void Connect()
        {

            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ipAddress = IPAddress.Parse("127.0.0." + ip.ToString());
            endPoint = new IPEndPoint(ipAddress, port);
            this.Text = "Client (" + endPoint.ToString() + ")";
            try
            {
                client.Connect(endPoint);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối với Sever !");
            }
            Control.CheckForIllegalCrossThreadCalls = false;
            Thread thread = new Thread(ReceiveMess);
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMess();
        }
        private void SendMess()
        {
            if (txtMess.Text != String.Empty && path == "" && icon == null)
            {
                string str = txtMess.Text.ToString();
                byte[] data = new byte[1024 * 5000];
                data = EnCode(str);
                client.Send(data);
                listMess.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt")+ "): \n" + txtMess.Text + "\n");
                txtMess.Text = "";
            }
            else if (icon != null)
            {
                byte[] data = new byte[1024 * 5000];
                data = ImageToByteArray(icon);
                client.Send(data);

                listMess.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt")+ ") \n");
                listMess.Paste();
                listMess.AppendText("\n");
                icon = null;
                txtMess.Text = "";
            }
            else if (path != "")
            {
                Image image = Image.FromFile(path);
                byte[] data = new byte[1024 * 5000];
                data = ImageToByteArray(image);
                client.Send(data);
                listMess.AppendText("Tôi " + " " + "(" + DateTime.Now.ToString("h:mm:ss tt")+ "): \n");
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
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string[] str1 = DeCode(data).Split(';');
                    string[] strCheck = str1[0].Split('&');
                    if (IsValidImage(data))
                    {
                        Image image = byteArrayToImage(data);
                        Clipboard.SetDataObject(image, false, 1, 200);
                        listMess.AppendText("Sever "+ client.LocalEndPoint + " "+"(" + DateTime.Now.ToString("h:mm:ss tt")+ "): \n");
                        listMess.Paste();
                        listMess.AppendText("\n");
                    }
                    else if (strCheck[0].Contains("127.0.0"))
                    {
                        cbListClient.Items.Clear();
                        for (int i = 0; i < strCheck.Length; i++)
                        {
                            if (!Equals(strCheck[i], endPoint.ToString()) && strCheck[i] != String.Empty)
                            {
                                cbListClient.Items.Add(strCheck[i]);
                            }
                        }


                    }
                    else if(!IsValidImage(data))
                    {
                        string str = DeCode(data);
                        if (str != null || str != String.Empty)
                        {
                            listMess.AppendText("Sever" + client.LocalEndPoint + " " + "(" + DateTime.Now.ToString("h:mm:ss tt")+ "): \n" + str);
                            listMess.AppendText("\n");
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi !");
                listMess.AppendText(ex.ToString());
                this.Close();
            }

        }
        private static byte[] EnCode(string str)
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

        private void listView_MouseLeave(object sender, EventArgs e)
        {
            listIcon.Visible = false;
        }
        public byte[] ImageToByteArray(Image imageIn)
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
        private void selectAll_Click(object sender, EventArgs e)
        {
            listMess.SelectAll();
            listMess.SelectionBackColor = Color.Yellow;
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            if (listMess.SelectionLength > 0)
                listMess.Copy();
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            if (listMess.SelectionLength > 0)
                listMess.Cut();
        }


        private void rdClient_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdClient.Checked)
                {
                    byte[] data = new byte[1024 * 5000];
                    cbListClient.SetItemCheckState(0, CheckState.Checked);
                    for (int i = 0; i < cbListClient.Items.Count; i++)
                    {
                        if (cbListClient.GetItemCheckState(i) == CheckState.Checked)
                        {
                            string str = "!client&" + cbListClient.Items[i].ToString() + " ";
                            data = EnCode(str);
                            client.Send(data);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Chỉ có 1 client duy nhất ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rdClient.Checked = false;
                rdSever.Checked = true;
            }
        }

        private void rdSever_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSever.Checked)
            {
                byte[] data = new byte[1024 * 5000];
                string str = "!sever ";
                data = EnCode(str);
                client.Send(data);
            }
        }

        private void cbListClient_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < cbListClient.Items.Count; ++ix)
                if (ix != e.Index) cbListClient.SetItemChecked(ix, false);
                byte[] data = new byte[1024 * 5000];
                string str = "!client&" + cbListClient.Items[e.Index].ToString() + " ";
                data = EnCode(str);
                client.Send(data);

        }
    }
}
