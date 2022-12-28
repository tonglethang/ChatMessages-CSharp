namespace ChatClient
{
    partial class frmClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtMess = new System.Windows.Forms.RichTextBox();
            this.listIcon = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panelOption = new System.Windows.Forms.FlowLayoutPanel();
            this.radioSever = new System.Windows.Forms.RadioButton();
            this.radioClient = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblListClient = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnIcon = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.flowOption = new System.Windows.Forms.FlowLayoutPanel();
            this.rdSever = new System.Windows.Forms.RadioButton();
            this.rdClient = new System.Windows.Forms.RadioButton();
            this.cbListClient = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listMess = new System.Windows.Forms.RichTextBox();
            this.btnChuyenTiep = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.panelOption.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowOption.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMess
            // 
            this.txtMess.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMess.Location = new System.Drawing.Point(240, 581);
            this.txtMess.Name = "txtMess";
            this.txtMess.Size = new System.Drawing.Size(616, 60);
            this.txtMess.TabIndex = 10;
            this.txtMess.Text = "";
            // 
            // listIcon
            // 
            this.listIcon.HideSelection = false;
            this.listIcon.Location = new System.Drawing.Point(85, 456);
            this.listIcon.Name = "listIcon";
            this.listIcon.Size = new System.Drawing.Size(456, 131);
            this.listIcon.TabIndex = 12;
            this.listIcon.UseCompatibleStateImageBehavior = false;
            this.listIcon.Visible = false;
            this.listIcon.SelectedIndexChanged += new System.EventHandler(this.listIcon_SelectedIndexChanged);
            this.listIcon.MouseLeave += new System.EventHandler(this.listView_MouseLeave);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 30);
            // 
            // menuDelete
            // 
            this.menuDelete.Image = global::ChatClient.Properties.Resources.iconclear;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(165, 26);
            this.menuDelete.Text = "Xóa tin nhắn";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(47, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 35);
            this.label1.TabIndex = 21;
            this.label1.Text = "Danh mục";
            // 
            // panelOption
            // 
            this.panelOption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOption.BackColor = System.Drawing.Color.White;
            this.panelOption.Controls.Add(this.radioSever);
            this.panelOption.Controls.Add(this.radioClient);
            this.panelOption.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelOption.Location = new System.Drawing.Point(41, 61);
            this.panelOption.Name = "panelOption";
            this.panelOption.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.panelOption.Size = new System.Drawing.Size(0, 0);
            this.panelOption.TabIndex = 24;
            // 
            // radioSever
            // 
            this.radioSever.Location = new System.Drawing.Point(43, 3);
            this.radioSever.Name = "radioSever";
            this.radioSever.Size = new System.Drawing.Size(104, 24);
            this.radioSever.TabIndex = 0;
            // 
            // radioClient
            // 
            this.radioClient.Location = new System.Drawing.Point(153, 3);
            this.radioClient.Name = "radioClient";
            this.radioClient.Size = new System.Drawing.Size(104, 24);
            this.radioClient.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.checkBox1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(41, 215);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 231);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(33, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Client 1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblListClient
            // 
            this.lblListClient.AutoSize = true;
            this.lblListClient.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListClient.ForeColor = System.Drawing.Color.Blue;
            this.lblListClient.Location = new System.Drawing.Point(47, 180);
            this.lblListClient.Name = "lblListClient";
            this.lblListClient.Size = new System.Drawing.Size(144, 35);
            this.lblListClient.TabIndex = 26;
            this.lblListClient.Text = "List Client";
            this.lblListClient.Visible = false;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.LightCyan;
            this.btnSend.BackgroundImage = global::ChatClient.Properties.Resources.iconmess;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend.Location = new System.Drawing.Point(862, 581);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(60, 60);
            this.btnSend.TabIndex = 3;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnIcon
            // 
            this.btnIcon.BackgroundImage = global::ChatClient.Properties.Resources.icon;
            this.btnIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIcon.Location = new System.Drawing.Point(85, 583);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(55, 49);
            this.btnIcon.TabIndex = 8;
            this.btnIcon.UseVisualStyleBackColor = true;
            this.btnIcon.Click += new System.EventHandler(this.btnIcon_Click);
            // 
            // btnImage
            // 
            this.btnImage.BackgroundImage = global::ChatClient.Properties.Resources.iconimage1;
            this.btnImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImage.Location = new System.Drawing.Point(12, 583);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(67, 49);
            this.btnImage.TabIndex = 6;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // flowOption
            // 
            this.flowOption.BackColor = System.Drawing.Color.White;
            this.flowOption.Controls.Add(this.rdSever);
            this.flowOption.Controls.Add(this.rdClient);
            this.flowOption.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowOption.Location = new System.Drawing.Point(26, 61);
            this.flowOption.Name = "flowOption";
            this.flowOption.Padding = new System.Windows.Forms.Padding(40, 12, 0, 0);
            this.flowOption.Size = new System.Drawing.Size(184, 100);
            this.flowOption.TabIndex = 27;
            // 
            // rdSever
            // 
            this.rdSever.AutoSize = true;
            this.rdSever.Checked = true;
            this.rdSever.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSever.Location = new System.Drawing.Point(43, 15);
            this.rdSever.Name = "rdSever";
            this.rdSever.Size = new System.Drawing.Size(80, 27);
            this.rdSever.TabIndex = 0;
            this.rdSever.TabStop = true;
            this.rdSever.Text = "Sever";
            this.rdSever.UseVisualStyleBackColor = true;
            this.rdSever.CheckedChanged += new System.EventHandler(this.rdSever_CheckedChanged);
            // 
            // rdClient
            // 
            this.rdClient.AutoSize = true;
            this.rdClient.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdClient.Location = new System.Drawing.Point(43, 48);
            this.rdClient.Name = "rdClient";
            this.rdClient.Size = new System.Drawing.Size(82, 27);
            this.rdClient.TabIndex = 1;
            this.rdClient.Text = "Client";
            this.rdClient.UseVisualStyleBackColor = true;
            this.rdClient.CheckedChanged += new System.EventHandler(this.rdClient_CheckedChanged);
            // 
            // cbListClient
            // 
            this.cbListClient.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListClient.FormattingEnabled = true;
            this.cbListClient.Location = new System.Drawing.Point(31, 218);
            this.cbListClient.Name = "cbListClient";
            this.cbListClient.Size = new System.Drawing.Size(179, 334);
            this.cbListClient.TabIndex = 28;
            this.cbListClient.Visible = false;
            this.cbListClient.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cbListClient_ItemCheck);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.listMess);
            this.panel1.Location = new System.Drawing.Point(240, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 572);
            this.panel1.TabIndex = 29;
            // 
            // listMess
            // 
            this.listMess.BackColor = System.Drawing.Color.White;
            this.listMess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listMess.ContextMenuStrip = this.contextMenuStrip1;
            this.listMess.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMess.Location = new System.Drawing.Point(13, 3);
            this.listMess.Name = "listMess";
            this.listMess.ReadOnly = true;
            this.listMess.Size = new System.Drawing.Size(632, 566);
            this.listMess.TabIndex = 0;
            this.listMess.Text = "";
            // 
            // btnChuyenTiep
            // 
            this.btnChuyenTiep.Location = new System.Drawing.Point(146, 583);
            this.btnChuyenTiep.Name = "btnChuyenTiep";
            this.btnChuyenTiep.Size = new System.Drawing.Size(80, 49);
            this.btnChuyenTiep.TabIndex = 1;
            this.btnChuyenTiep.Text = "Chuyển tiếp";
            this.btnChuyenTiep.UseVisualStyleBackColor = true;
            this.btnChuyenTiep.Click += new System.EventHandler(this.btnChuyenTiep_Click);
            // 
            // frmClient
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 653);
            this.Controls.Add(this.btnChuyenTiep);
            this.Controls.Add(this.listIcon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbListClient);
            this.Controls.Add(this.flowOption);
            this.Controls.Add(this.lblListClient);
            this.Controls.Add(this.panelOption);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMess);
            this.Controls.Add(this.btnIcon);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelOption.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowOption.ResumeLayout(false);
            this.flowOption.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnIcon;
        private System.Windows.Forms.RichTextBox txtMess;
        private System.Windows.Forms.ListView listIcon;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.FlowLayoutPanel panelOption;
        private System.Windows.Forms.RadioButton radioSever;
        private System.Windows.Forms.RadioButton radioClient;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblListClient;
        private System.Windows.Forms.FlowLayoutPanel flowOption;
        private System.Windows.Forms.RadioButton rdSever;
        private System.Windows.Forms.RadioButton rdClient;
        private System.Windows.Forms.CheckedListBox cbListClient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox listMess;
        private System.Windows.Forms.Button btnChuyenTiep;
    }
}

