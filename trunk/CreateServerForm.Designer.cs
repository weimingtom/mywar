namespace my_war
{
    partial class CreateServerForm
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
            this.CheckBox_AutoMode = new System.Windows.Forms.CheckBox();
            this.DataGridView_Players = new System.Windows.Forms.DataGridView();
            this.GroupBox_Players = new System.Windows.Forms.GroupBox();
            this.Button_CreateServer = new System.Windows.Forms.Button();
            this.Button_Start = new System.Windows.Forms.Button();
            this.Label_Nick = new System.Windows.Forms.Label();
            this.TextBox_Nick = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Players)).BeginInit();
            this.GroupBox_Players.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBox_AutoMode
            // 
            this.CheckBox_AutoMode.AutoSize = true;
            this.CheckBox_AutoMode.Location = new System.Drawing.Point(77, 24);
            this.CheckBox_AutoMode.Name = "CheckBox_AutoMode";
            this.CheckBox_AutoMode.Size = new System.Drawing.Size(147, 17);
            this.CheckBox_AutoMode.TabIndex = 0;
            this.CheckBox_AutoMode.Text = "Автоматическйи режим";
            this.CheckBox_AutoMode.UseVisualStyleBackColor = true;
            // 
            // DataGridView_Players
            // 
            this.DataGridView_Players.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Players.Location = new System.Drawing.Point(6, 19);
            this.DataGridView_Players.Name = "DataGridView_Players";
            this.DataGridView_Players.Size = new System.Drawing.Size(240, 150);
            this.DataGridView_Players.TabIndex = 1;
            // 
            // GroupBox_Players
            // 
            this.GroupBox_Players.Controls.Add(this.DataGridView_Players);
            this.GroupBox_Players.Location = new System.Drawing.Point(12, 100);
            this.GroupBox_Players.Name = "GroupBox_Players";
            this.GroupBox_Players.Size = new System.Drawing.Size(252, 178);
            this.GroupBox_Players.TabIndex = 2;
            this.GroupBox_Players.TabStop = false;
            this.GroupBox_Players.Text = "Список игроков";
            // 
            // Button_CreateServer
            // 
            this.Button_CreateServer.Location = new System.Drawing.Point(324, 131);
            this.Button_CreateServer.Name = "Button_CreateServer";
            this.Button_CreateServer.Size = new System.Drawing.Size(75, 23);
            this.Button_CreateServer.TabIndex = 3;
            this.Button_CreateServer.Text = "Создать";
            this.Button_CreateServer.UseVisualStyleBackColor = true;
            this.Button_CreateServer.Click += new System.EventHandler(this.Button_CreateServer_Click);
            // 
            // Button_Start
            // 
            this.Button_Start.Location = new System.Drawing.Point(324, 160);
            this.Button_Start.Name = "Button_Start";
            this.Button_Start.Size = new System.Drawing.Size(75, 23);
            this.Button_Start.TabIndex = 4;
            this.Button_Start.Text = "Старт";
            this.Button_Start.UseVisualStyleBackColor = true;
            // 
            // Label_Nick
            // 
            this.Label_Nick.AutoSize = true;
            this.Label_Nick.Location = new System.Drawing.Point(74, 59);
            this.Label_Nick.Name = "Label_Nick";
            this.Label_Nick.Size = new System.Drawing.Size(70, 13);
            this.Label_Nick.TabIndex = 5;
            this.Label_Nick.Text = "Имя игрока:";
            // 
            // TextBox_Nick
            // 
            this.TextBox_Nick.Location = new System.Drawing.Point(164, 56);
            this.TextBox_Nick.Name = "TextBox_Nick";
            this.TextBox_Nick.Size = new System.Drawing.Size(100, 20);
            this.TextBox_Nick.TabIndex = 6;
            // 
            // CreateServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 315);
            this.Controls.Add(this.TextBox_Nick);
            this.Controls.Add(this.Label_Nick);
            this.Controls.Add(this.Button_Start);
            this.Controls.Add(this.Button_CreateServer);
            this.Controls.Add(this.GroupBox_Players);
            this.Controls.Add(this.CheckBox_AutoMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateServerForm";
            this.Text = "CreateServerForm";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Players)).EndInit();
            this.GroupBox_Players.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBox_AutoMode;
        private System.Windows.Forms.DataGridView DataGridView_Players;
        private System.Windows.Forms.GroupBox GroupBox_Players;
        private System.Windows.Forms.Button Button_CreateServer;
        private System.Windows.Forms.Button Button_Start;
        private System.Windows.Forms.Label Label_Nick;
        private System.Windows.Forms.TextBox TextBox_Nick;
    }
}