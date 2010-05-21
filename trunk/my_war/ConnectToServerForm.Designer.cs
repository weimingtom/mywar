namespace my_war
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
            this.TextBox_Status = new System.Windows.Forms.TextBox();
            this.Label_Status = new System.Windows.Forms.Label();
            this.Button_ListGamer = new System.Windows.Forms.Button();
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
            this.Button_Connect.Location = new System.Drawing.Point(18, 88);
            this.Button_Connect.Name = "Button_Connect";
            this.Button_Connect.Size = new System.Drawing.Size(81, 23);
            this.Button_Connect.TabIndex = 2;
            this.Button_Connect.Text = "Соединиться";
            this.Button_Connect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Connect.UseVisualStyleBackColor = true;
            this.Button_Connect.Click += new System.EventHandler(this.Button_Connect_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Enabled = false;
            this.Button_Cancel.Location = new System.Drawing.Point(107, 88);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 3;
            this.Button_Cancel.Text = "Отмена";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
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
            // TextBox_Status
            // 
            this.TextBox_Status.Location = new System.Drawing.Point(105, 62);
            this.TextBox_Status.Name = "TextBox_Status";
            this.TextBox_Status.Size = new System.Drawing.Size(100, 20);
            this.TextBox_Status.TabIndex = 6;
            this.TextBox_Status.Text = "Отсотединен";
            // 
            // Label_Status
            // 
            this.Label_Status.AutoSize = true;
            this.Label_Status.Location = new System.Drawing.Point(13, 65);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(44, 13);
            this.Label_Status.TabIndex = 7;
            this.Label_Status.Text = "Статус:";
            // 
            // Button_ListGamer
            // 
            this.Button_ListGamer.Enabled = false;
            this.Button_ListGamer.Location = new System.Drawing.Point(188, 88);
            this.Button_ListGamer.Name = "Button_ListGamer";
            this.Button_ListGamer.Size = new System.Drawing.Size(75, 23);
            this.Button_ListGamer.TabIndex = 8;
            this.Button_ListGamer.Text = "Игроки";
            this.Button_ListGamer.UseVisualStyleBackColor = true;
            this.Button_ListGamer.Click += new System.EventHandler(this.Button_ListGamer_Click);
            // 
            // ConnectToServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 118);
            this.Controls.Add(this.Button_ListGamer);
            this.Controls.Add(this.Label_Status);
            this.Controls.Add(this.TextBox_Status);
            this.Controls.Add(this.TextBox_Nick);
            this.Controls.Add(this.Label_Nick);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_Connect);
            this.Controls.Add(this.TextBox_IP);
            this.Controls.Add(this.Label_IP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectToServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectToServerForm";
            this.Load += new System.EventHandler(this.ConnectToServerForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectToServerForm_FormClosed);
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
        private System.Windows.Forms.TextBox TextBox_Status;
        private System.Windows.Forms.Label Label_Status;
        private System.Windows.Forms.Button Button_ListGamer;
    }
}