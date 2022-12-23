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
            this.btnSend = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnIcon = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.listIcon = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listMess = new System.Windows.Forms.RichTextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // txtMess
            // 
            this.txtMess.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMess.Location = new System.Drawing.Point(265, 730);
            this.txtMess.Name = "txtMess";
            this.txtMess.Size = new System.Drawing.Size(824, 71);
            this.txtMess.TabIndex = 10;
            this.txtMess.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.LightCyan;
            this.btnSend.BackgroundImage = global::ChatClient.Properties.Resources.iconmess;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend.Location = new System.Drawing.Point(1095, 730);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 71);
            this.btnSend.TabIndex = 3;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnFile
            // 
            this.btnFile.BackgroundImage = global::ChatClient.Properties.Resources.iconfile;
            this.btnFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFile.Location = new System.Drawing.Point(188, 741);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(55, 49);
            this.btnFile.TabIndex = 9;
            this.btnFile.UseVisualStyleBackColor = true;
            // 
            // btnIcon
            // 
            this.btnIcon.BackgroundImage = global::ChatClient.Properties.Resources.icon;
            this.btnIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIcon.Location = new System.Drawing.Point(95, 741);
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
            this.btnImage.Location = new System.Drawing.Point(12, 741);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(67, 49);
            this.btnImage.TabIndex = 6;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // listIcon
            // 
            this.listIcon.HideSelection = false;
            this.listIcon.Location = new System.Drawing.Point(95, 613);
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
            // listMess
            // 
            this.listMess.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMess.Location = new System.Drawing.Point(265, 12);
            this.listMess.Name = "listMess";
            this.listMess.Size = new System.Drawing.Size(893, 703);
            this.listMess.TabIndex = 13;
            this.listMess.Text = "";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 22);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(231, 259);
            this.checkedListBox1.TabIndex = 14;
            // 
            // frmClient
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 864);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.listIcon);
            this.Controls.Add(this.listMess);
            this.Controls.Add(this.txtMess);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnIcon);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.btnSend);
            this.Name = "frmClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClient_FormClosed);
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnIcon;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.RichTextBox txtMess;
        private System.Windows.Forms.ListView listIcon;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.RichTextBox listMess;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

