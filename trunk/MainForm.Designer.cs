namespace my_var
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_Game = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_CreateServer = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ConnectToServer = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGridView_CompetitorField = new System.Windows.Forms.DataGridView();
            this.DataGridView_PlayerField = new System.Windows.Forms.DataGridView();
            this.Button_Ready = new System.Windows.Forms.Button();
            this.Label_Competitor = new System.Windows.Forms.Label();
            this.Label_Me = new System.Windows.Forms.Label();
            this.MenuStrip_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CompetitorField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_PlayerField)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip_Main
            // 
            this.MenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Game,
            this.ToolStripMenuItem_Help});
            this.MenuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip_Main.Name = "MenuStrip_Main";
            this.MenuStrip_Main.Size = new System.Drawing.Size(479, 24);
            this.MenuStrip_Main.TabIndex = 0;
            this.MenuStrip_Main.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_Game
            // 
            this.ToolStripMenuItem_Game.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_CreateServer,
            this.ToolStripMenuItem_ConnectToServer});
            this.ToolStripMenuItem_Game.Name = "ToolStripMenuItem_Game";
            this.ToolStripMenuItem_Game.Size = new System.Drawing.Size(46, 20);
            this.ToolStripMenuItem_Game.Text = "Игра";
            // 
            // ToolStripMenuItem_Help
            // 
            this.ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
            this.ToolStripMenuItem_Help.Size = new System.Drawing.Size(65, 20);
            this.ToolStripMenuItem_Help.Text = "Справка";
            // 
            // ToolStripMenuItem_CreateServer
            // 
            this.ToolStripMenuItem_CreateServer.Name = "ToolStripMenuItem_CreateServer";
            this.ToolStripMenuItem_CreateServer.Size = new System.Drawing.Size(166, 22);
            this.ToolStripMenuItem_CreateServer.Text = "Создать";
            this.ToolStripMenuItem_CreateServer.Click += new System.EventHandler(this.ToolStripMenuItem_CreateServer_Click);
            // 
            // ToolStripMenuItem_ConnectToServer
            // 
            this.ToolStripMenuItem_ConnectToServer.Name = "ToolStripMenuItem_ConnectToServer";
            this.ToolStripMenuItem_ConnectToServer.Size = new System.Drawing.Size(166, 22);
            this.ToolStripMenuItem_ConnectToServer.Text = "Присоединиться";
            this.ToolStripMenuItem_ConnectToServer.Click += new System.EventHandler(this.ToolStripMenuItem_ConnectToServer_Click);
            // 
            // DataGridView_CompetitorField
            // 
            this.DataGridView_CompetitorField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_CompetitorField.Location = new System.Drawing.Point(249, 55);
            this.DataGridView_CompetitorField.Name = "DataGridView_CompetitorField";
            this.DataGridView_CompetitorField.Size = new System.Drawing.Size(214, 217);
            this.DataGridView_CompetitorField.TabIndex = 1;
            // 
            // DataGridView_PlayerField
            // 
            this.DataGridView_PlayerField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_PlayerField.Location = new System.Drawing.Point(12, 55);
            this.DataGridView_PlayerField.Name = "DataGridView_PlayerField";
            this.DataGridView_PlayerField.Size = new System.Drawing.Size(214, 217);
            this.DataGridView_PlayerField.TabIndex = 2;
            // 
            // Button_Ready
            // 
            this.Button_Ready.Location = new System.Drawing.Point(388, 278);
            this.Button_Ready.Name = "Button_Ready";
            this.Button_Ready.Size = new System.Drawing.Size(75, 23);
            this.Button_Ready.TabIndex = 3;
            this.Button_Ready.Text = "Готов";
            this.Button_Ready.UseVisualStyleBackColor = true;
            // 
            // Label_Competitor
            // 
            this.Label_Competitor.AutoSize = true;
            this.Label_Competitor.Location = new System.Drawing.Point(336, 39);
            this.Label_Competitor.Name = "Label_Competitor";
            this.Label_Competitor.Size = new System.Drawing.Size(56, 13);
            this.Label_Competitor.TabIndex = 4;
            this.Label_Competitor.Text = "Соперник";
            // 
            // Label_Me
            // 
            this.Label_Me.AutoSize = true;
            this.Label_Me.Location = new System.Drawing.Point(115, 39);
            this.Label_Me.Name = "Label_Me";
            this.Label_Me.Size = new System.Drawing.Size(15, 13);
            this.Label_Me.TabIndex = 5;
            this.Label_Me.Text = "Я";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 314);
            this.Controls.Add(this.Label_Me);
            this.Controls.Add(this.Label_Competitor);
            this.Controls.Add(this.Button_Ready);
            this.Controls.Add(this.DataGridView_PlayerField);
            this.Controls.Add(this.DataGridView_CompetitorField);
            this.Controls.Add(this.MenuStrip_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip_Main;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "My WAR";
            this.MenuStrip_Main.ResumeLayout(false);
            this.MenuStrip_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CompetitorField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_PlayerField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Game;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_CreateServer;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ConnectToServer;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Help;
        private System.Windows.Forms.DataGridView DataGridView_CompetitorField;
        private System.Windows.Forms.DataGridView DataGridView_PlayerField;
        private System.Windows.Forms.Button Button_Ready;
        private System.Windows.Forms.Label Label_Competitor;
        private System.Windows.Forms.Label Label_Me;

    }
}

