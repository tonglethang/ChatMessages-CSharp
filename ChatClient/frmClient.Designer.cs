﻿namespace ChatClient
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
            this.panelClient = new System.Windows.Forms.FlowLayoutPanel();
            this.txtMess = new System.Windows.Forms.RichTextBox();
            this.listMess = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnIcon = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelClient
            // 
            this.panelClient.BackColor = System.Drawing.Color.White;
            this.panelClient.Location = new System.Drawing.Point(12, 12);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(247, 643);
            this.panelClient.TabIndex = 5;
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
            // listMess
            // 
            this.listMess.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMess.Location = new System.Drawing.Point(265, 12);
            this.listMess.Name = "listMess";
            this.listMess.Size = new System.Drawing.Size(905, 657);
            this.listMess.TabIndex = 11;
            this.listMess.Text = "";
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
            this.btnFile.Location = new System.Drawing.Point(501, 675);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(55, 49);
            this.btnFile.TabIndex = 9;
            this.btnFile.UseVisualStyleBackColor = true;
            // 
            // btnIcon
            // 
            this.btnIcon.BackgroundImage = global::ChatClient.Properties.Resources.icon;
            this.btnIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIcon.Location = new System.Drawing.Point(387, 675);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(55, 49);
            this.btnIcon.TabIndex = 8;
            this.btnIcon.UseVisualStyleBackColor = true;
            // 
            // btnImage
            // 
            this.btnImage.BackgroundImage = global::ChatClient.Properties.Resources.iconimage1;
            this.btnImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImage.Location = new System.Drawing.Point(265, 675);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(67, 49);
            this.btnImage.TabIndex = 6;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // frmClient
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 864);
            this.Controls.Add(this.listMess);
            this.Controls.Add(this.txtMess);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnIcon);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.panelClient);
            this.Controls.Add(this.btnSend);
            this.Name = "frmClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.FlowLayoutPanel panelClient;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnIcon;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.RichTextBox txtMess;
        private System.Windows.Forms.RichTextBox listMess;
    }
}
