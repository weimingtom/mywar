﻿namespace my_var
{
    partial class ConnectToServerForm
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
            this.Label_IP = new System.Windows.Forms.Label();
            this.TextBox_IP = new System.Windows.Forms.TextBox();
            this.Button_Connect = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Label_Nick = new System.Windows.Forms.Label();
            this.TextBox_Nick = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label_IP
            // 
            this.Label_IP.AutoSize = true;
            this.Label_IP.Location = new System.Drawing.Point(13, 13);
            this.Label_IP.Name = "Label_IP";
            this.Label_IP.Size = new System.Drawing.Size(86, 13);
            this.Label_IP.TabIndex = 0;
            this.Label_IP.Text = "Адрес сервера:";
            // 
            // TextBox_IP
            // 
            this.TextBox_IP.Location = new System.Drawing.Point(105, 10);
            this.TextBox_IP.Name = "TextBox_IP";
            this.TextBox_IP.Size = new System.Drawing.Size(100, 20);
            this.TextBox_IP.TabIndex = 1;
            // 
            // Button_Connect
            // 
            this.Button_Connect.Location = new System.Drawing.Point(67, 217);
            this.Button_Connect.Name = "Button_Connect";
            this.Button_Connect.Size = new System.Drawing.Size(81, 23);
            this.Button_Connect.TabIndex = 2;
            this.Button_Connect.Text = "Соединиться";
            this.Button_Connect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Connect.UseVisualStyleBackColor = true;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Location = new System.Drawing.Point(163, 217);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 3;
            this.Button_Cancel.Text = "Отмена";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Label_Nick
            // 
            this.Label_Nick.AutoSize = true;
            this.Label_Nick.Location = new System.Drawing.Point(13, 40);
            this.Label_Nick.Name = "Label_Nick";
            this.Label_Nick.Size = new System.Drawing.Size(70, 13);
            this.Label_Nick.TabIndex = 4;
            this.Label_Nick.Text = "Имя игрока:";
            // 
            // TextBox_Nick
            // 
            this.TextBox_Nick.Location = new System.Drawing.Point(105, 37);
            this.TextBox_Nick.Name = "TextBox_Nick";
            this.TextBox_Nick.Size = new System.Drawing.Size(100, 20);
            this.TextBox_Nick.TabIndex = 5;
            // 
            // ConnectToServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.TextBox_Nick);
            this.Controls.Add(this.Label_Nick);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_Connect);
            this.Controls.Add(this.TextBox_IP);
            this.Controls.Add(this.Label_IP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectToServerForm";
            this.Text = "ConnectToServerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_IP;
        private System.Windows.Forms.TextBox TextBox_IP;
        private System.Windows.Forms.Button Button_Connect;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Label Label_Nick;
        private System.Windows.Forms.TextBox TextBox_Nick;
    }
}