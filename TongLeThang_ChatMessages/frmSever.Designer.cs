namespace TongLeThang_ChatMessages
{
    partial class frmSever
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
            this.txtMess = new System.Windows.Forms.RichTextBox();
            this.imageList = new System.Windows.Forms.ImageList();
            this.listMess = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.menuSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.listIcon = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnIcon = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.cbListClient = new System.Windows.Forms.CheckedListBox();
            this.cbStatusListClient = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMess
            // 
            this.txtMess.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMess.Location = new System.Drawing.Point(256, 582);
            this.txtMess.Name = "txtMess";
            this.txtMess.Size = new System.Drawing.Size(522, 59);
            this.txtMess.TabIndex = 13;
            this.txtMess.Text = "";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listMess
            // 
            this.listMess.ContextMenuStrip = this.contextMenuStrip1;
            this.listMess.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMess.Location = new System.Drawing.Point(258, 12);
            this.listMess.Name = "listMess";
            this.listMess.Size = new System.Drawing.Size(586, 564);
            this.listMess.TabIndex = 18;
            this.listMess.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSelect,
            this.menuCopy,
            this.menuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 82);
            // 
            // menuSelect
            // 
            this.menuSelect.Image = global::ChatSever.Properties.Resources.iconselect;
            this.menuSelect.Name = "menuSelect";
            this.menuSelect.Size = new System.Drawing.Size(157, 26);
            this.menuSelect.Text = "Chọn tất cả";
            this.menuSelect.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.Image = global::ChatSever.Properties.Resources.iconcopy;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(157, 26);
            this.menuCopy.Text = "Sao chép";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Image = global::ChatSever.Properties.Resources.iconclear;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(157, 26);
            this.menuDelete.Text = "Xóa";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // listIcon
            // 
            this.listIcon.HideSelection = false;
            this.listIcon.Location = new System.Drawing.Point(120, 459);
            this.listIcon.Name = "listIcon";
            this.listIcon.Size = new System.Drawing.Size(456, 131);
            this.listIcon.TabIndex = 19;
            this.listIcon.UseCompatibleStateImageBehavior = false;
            this.listIcon.Visible = false;
            this.listIcon.SelectedIndexChanged += new System.EventHandler(this.listIcon_SelectedIndexChanged);
            this.listIcon.MouseLeave += new System.EventHandler(this.listIcon_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(42, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 35);
            this.label1.TabIndex = 20;
            this.label1.Text = "LIST CLIENT";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.LightGray;
            this.btnSend.BackgroundImage = global::ChatSever.Properties.Resources.iconmess;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend.Location = new System.Drawing.Point(784, 582);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(60, 59);
            this.btnSend.TabIndex = 14;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnFile
            // 
            this.btnFile.BackgroundImage = global::ChatSever.Properties.Resources.iconfile;
            this.btnFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFile.Location = new System.Drawing.Point(195, 587);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(55, 49);
            this.btnFile.TabIndex = 17;
            this.btnFile.UseVisualStyleBackColor = true;
            // 
            // btnIcon
            // 
            this.btnIcon.BackgroundImage = global::ChatSever.Properties.Resources.icon;
            this.btnIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIcon.Location = new System.Drawing.Point(120, 587);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(55, 49);
            this.btnIcon.TabIndex = 16;
            this.btnIcon.UseVisualStyleBackColor = true;
            this.btnIcon.Click += new System.EventHandler(this.btnIcon_Click);
            // 
            // btnImage
            // 
            this.btnImage.BackgroundImage = global::ChatSever.Properties.Resources.iconimage;
            this.btnImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImage.Location = new System.Drawing.Point(29, 587);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(67, 49);
            this.btnImage.TabIndex = 15;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // cbListClient
            // 
            this.cbListClient.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListClient.FormattingEnabled = true;
            this.cbListClient.Location = new System.Drawing.Point(12, 59);
            this.cbListClient.Name = "cbListClient";
            this.cbListClient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbListClient.Size = new System.Drawing.Size(227, 400);
            this.cbListClient.TabIndex = 22;
            // 
            // cbStatusListClient
            // 
            this.cbStatusListClient.FormattingEnabled = true;
            this.cbStatusListClient.Location = new System.Drawing.Point(12, 321);
            this.cbStatusListClient.Name = "cbStatusListClient";
            this.cbStatusListClient.Size = new System.Drawing.Size(120, 89);
            this.cbStatusListClient.TabIndex = 23;
            this.cbStatusListClient.Visible = false;
            // 
            // frmSever
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 653);
            this.Controls.Add(this.cbStatusListClient);
            this.Controls.Add(this.cbListClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listIcon);
            this.Controls.Add(this.listMess);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnIcon);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSever";
            this.Text = "Sever";
            this.Load += new System.EventHandler(this.frmSever_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtMess;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnIcon;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.RichTextBox listMess;
        private System.Windows.Forms.ListView listIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSelect;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.CheckedListBox cbListClient;
        private System.Windows.Forms.CheckedListBox cbStatusListClient;
    }
}

