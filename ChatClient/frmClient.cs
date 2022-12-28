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
using static System.Net.WebRequestMethods;

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
        int ip = rnd.Next(243) +1;
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
                listMess.SelectionAlignment = HorizontalAlignment.Right;
                listMess.ReadOnly = false;
                string str = txtMess.Text.ToString();
                byte[] data = new byte[1024 * 5000];
                data = EnCode(str);
                client.Send(data);
                string name = getNameSendTo();
                listMess.SelectionFont = new Font("Times New Roman", 12, FontStyle.Regular);
                listMess.AppendText(name + "(" + DateTime.Now.ToString("h:mm:ss tt")+ "): \n" );
                listMess.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
                listMess.AppendText(txtMess.Text + "\n");
                txtMess.Text = "";
                listMess.ReadOnly = true;
            }
            else if (icon != null)
            {
                listMess.SelectionAlignment = HorizontalAlignment.Right;
                listMess.ReadOnly = false;
                byte[] data = new byte[1024 * 5000];
                data = ImageToByteArray(icon);
                client.Send(data);
                string name = getNameSendTo();
                listMess.SelectionFont = new Font("Times New Roman", 12, FontStyle.Regular);
                listMess.AppendText(name + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n");
                listMess.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
                listMess.Paste();
                listMess.AppendText("\n");
                icon = null;
                txtMess.Text = "";
                listMess.ReadOnly = true;
            }
            else if (path != "")
            {
                listMess.SelectionAlignment = HorizontalAlignment.Right;
                listMess.ReadOnly = false;
                Image image = Image.FromFile(path);
                byte[] data = new byte[1024 * 5000];
                data = ImageToByteArray(image);
                client.Send(data);
                string name = getNameSendTo();
                listMess.SelectionFont = new Font("Times New Roman", 12, FontStyle.Regular);
                listMess.AppendText(name + "(" + DateTime.Now.ToString("h:mm:ss tt") + "): \n");
                listMess.SelectionFont = new Font("Times NewRoman", 14, FontStyle.Bold);
                listMess.Paste();
                listMess.AppendText("\n");
                path = "";
                txtMess.Text = "";
                listMess.ReadOnly =true;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tin nhắn !");
            }
        }
        private void ReceiveMess()
        {
            string nameClientTmp = "";
            string name = "Sever ";
            bool checkNameClient = false;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string[] str1 = DeCode(data).Split(';');
                    string[] strCheck = str1[0].Split('&');

                    if (strCheck.Contains("!NameClient"))
                    {
                        nameClientTmp = "Client " + strCheck[1];
                        checkNameClient = true;
                        
                    }

                    if (IsValidImage(data))
                    {
                        if (checkNameClient)
                        {
                            name = nameClientTmp;
                            nameClientTmp = "Sever";
                        }
                        listMess.SelectionAlignment = HorizontalAlignment.Left;
                        listMess.ReadOnly = false;
                        Image image = byteArrayToImage(data);
                        Clipboard.SetDataObject(image, false, 1, 200);
                        listMess.SelectionFont = new Font("Times New Roman", 12, FontStyle.Regular);
                        listMess.AppendText(name + " "+"(" + DateTime.Now.ToString("h:mm:ss tt")+ "): \n");
                        listMess.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
                        listMess.Paste();
                        listMess.AppendText("\n");
                        listMess.ReadOnly = true;
                    }

                    else if (strCheck[0].Contains("127.0.0"))
                    {
                        int pos = -1;
                        if(cbListClient.Items.Count > 0 && getIndexItemChecked(cbListClient) != -1 && getIndexItemChecked(cbListClient) < strCheck.Length)
                        {
                            pos = getIndexItemChecked(cbListClient);
                        }
                        cbListClient.Items.Clear();

                        for (int i = 0; i < strCheck.Length; i++)
                        {
                            if (!Equals(strCheck[i], endPoint.ToString()) && strCheck[i] != String.Empty)
                            {
                                cbListClient.Items.Add(strCheck[i]);
                            }
                        }
                        if (cbListClient.Items.Count == 0)
                        {
                            rdSever.Checked = true;
                        }
                        try
                        {
                            if (cbListClient.Items.Count > 0 && pos >= 0)
                            {
                                cbListClient.SetItemChecked(pos, true);
                            }
                        }
                        catch
                        {
                            cbListClient.SetItemChecked(pos - 1 , true);
                        }
                    }
                    else if(!IsValidImage(data) && !DeCode(data).Contains("!NameClient"))
                    {
                        if (checkNameClient)
                        {
                            name = nameClientTmp;
                            nameClientTmp = "Server";
                        }
                        string str = DeCode(data);
                        if (str != null || str != String.Empty)
                        {
                            listMess.SelectionAlignment = HorizontalAlignment.Left;
                            listMess.ReadOnly = false;
                            listMess.SelectionFont = new Font("Times New Roman", 12, FontStyle.Regular);
                            listMess.AppendText(name + " " + "(" + DateTime.Now.ToString("h:mm:ss tt")+ "): \n" );
                            listMess.SelectionFont = new Font("Times New Roman", 14, FontStyle.Bold);
                            listMess.AppendText(str);
                            listMess.AppendText("\n");
                            listMess.ReadOnly = true;
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi !");
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
        private static String getPathIcon()
        {
            string duongDan = Environment.CurrentDirectory.ToString(); // lấy đường dẫn thư mục
            var url = Directory.GetParent(Directory.GetParent(duongDan).ToString()); // lấy thư mục cha

            return url.ToString();

        }
        private void btnIcon_Click(object sender, EventArgs e)
        {
            string filePath = getPathIcon() + @"\Icons";
            string[] files = Directory.GetFiles(filePath);
            foreach (String f in files)
            {
                Image img = Image.FromFile(f);  // từ cái file đó chuyển qua định dạng ảnh
                imageList.Images.Add(img); // bỏ vào img list
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
        private void menuDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa tất cả tin nhắn ", "Thông báo !", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                listMess.ReadOnly = false;
                listMess.SelectAll();
                if (listMess.SelectionLength > 0)

                    listMess.SelectedText = listMess.SelectedText.Replace(listMess.SelectedText, "");
                listMess.ReadOnly = true;
            }

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
                    lblListClient.Visible = true;
                    cbListClient.Visible = true;
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
                lblListClient.Visible = false;
                cbListClient.Visible = false;
                for (int ix = 0; ix < cbListClient.Items.Count; ++ix)
                    cbListClient.SetItemChecked(ix, false);
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
        private int getIndexItemChecked(CheckedListBox clb)
        {
            int i = 0;
            bool check = false;
            for(i = 0;i < clb.Items.Count; i++)
            {
                if (clb.GetItemChecked(i))
                {
                    check = true;
                    break;
                }
            }
            if (check)
            {
                return i;
            }
            else
            {
                return -1;
            }
        }
        private string getNameSendTo()
        {
            string str = "";
            if (rdSever.Checked)
            {
                str = "Tôi đến Sever ";
            }
            else
            {
                for(int i = 0; i < cbListClient.Items.Count; i++)
                {
                    if (cbListClient.GetItemChecked(i))
                    {
                        str = "Tôi đến " + cbListClient.Items[i].ToString() + " ";
                    }
                }
            }
            return str;
        }

        private void btnChuyenTiep_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn chuyển tiếp tin nhắn !!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)
            {
                RichTextBox tmp = new RichTextBox();
                int firstcharindex = listMess.GetFirstCharIndexOfCurrentLine();
                int currentline = listMess.GetLineFromCharIndex(firstcharindex);
                string currentlinetext = listMess.Lines[currentline];
                listMess.Select(firstcharindex, currentlinetext.Length);
                tmp.Text = "Bạn đã chuyển tiếp tin nhắn ";
                tmp.ForeColor = Color.Red;
                tmp.SelectionAlignment = listMess.SelectionAlignment;
                listMess.SelectedRtf = tmp.Rtf;
                txtMess.Text = currentlinetext;

                SendMess();


            }
            if (dialog == DialogResult.Cancel)
            {
                return;
            }
        }
    }
}
