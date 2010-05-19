namespace my_war
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
            this.ToolStripMenuItem_CreateServer = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ConnectToServer = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGridView_PlayerField = new System.Windows.Forms.DataGridView();
            this.Button_Ready = new System.Windows.Forms.Button();
            this.Label_Competitor = new System.Windows.Forms.Label();
            this.Label_Me = new System.Windows.Forms.Label();
            this.ListBox_TournamentList = new System.Windows.Forms.ListBox();
            this.Label_TournamentList = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridView_CompetitorField = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label_ResourceCounter = new System.Windows.Forms.Label();
            this.TextBox_ResourceCounter = new System.Windows.Forms.TextBox();
            this.MenuStrip_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_PlayerField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CompetitorField)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip_Main
            // 
            this.MenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Game,
            this.ToolStripMenuItem_Help});
            this.MenuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip_Main.Name = "MenuStrip_Main";
            this.MenuStrip_Main.Size = new System.Drawing.Size(625, 24);
            this.MenuStrip_Main.TabIndex = 0;
            this.MenuStrip_Main.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_Game
            // 
            this.ToolStripMenuItem_Game.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_CreateServer,
            this.ToolStripMenuItem_ConnectToServer,
            this.ToolStripMenuItem_Disconnect});
            this.ToolStripMenuItem_Game.Name = "ToolStripMenuItem_Game";
            this.ToolStripMenuItem_Game.Size = new System.Drawing.Size(46, 20);
            this.ToolStripMenuItem_Game.Text = "Игра";
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
            // ToolStripMenuItem_Disconnect
            // 
            this.ToolStripMenuItem_Disconnect.Name = "ToolStripMenuItem_Disconnect";
            this.ToolStripMenuItem_Disconnect.Size = new System.Drawing.Size(166, 22);
            this.ToolStripMenuItem_Disconnect.Text = "Отсоединиться";
            // 
            // ToolStripMenuItem_Help
            // 
            this.ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
            this.ToolStripMenuItem_Help.Size = new System.Drawing.Size(65, 20);
            this.ToolStripMenuItem_Help.Text = "Справка";
            // 
            // DataGridView_PlayerField
            // 
            this.DataGridView_PlayerField.AllowUserToAddRows = false;
            this.DataGridView_PlayerField.AllowUserToDeleteRows = false;
            this.DataGridView_PlayerField.AllowUserToResizeColumns = false;
            this.DataGridView_PlayerField.AllowUserToResizeRows = false;
            this.DataGridView_PlayerField.ColumnHeadersHeight = 10;
            this.DataGridView_PlayerField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridView_PlayerField.ColumnHeadersVisible = false;
            this.DataGridView_PlayerField.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.DataGridView_PlayerField.Location = new System.Drawing.Point(12, 55);
            this.DataGridView_PlayerField.MultiSelect = false;
            this.DataGridView_PlayerField.Name = "DataGridView_PlayerField";
            this.DataGridView_PlayerField.ReadOnly = true;
            this.DataGridView_PlayerField.RowHeadersVisible = false;
            this.DataGridView_PlayerField.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataGridView_PlayerField.RowTemplate.Height = 21;
            this.DataGridView_PlayerField.RowTemplate.ReadOnly = true;
            this.DataGridView_PlayerField.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_PlayerField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DataGridView_PlayerField.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridView_PlayerField.Size = new System.Drawing.Size(213, 213);
            this.DataGridView_PlayerField.TabIndex = 2;
            this.DataGridView_PlayerField.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_PlayerField_CellClick);
            // 
            // Button_Ready
            // 
            this.Button_Ready.Location = new System.Drawing.Point(254, 279);
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
            // ListBox_TournamentList
            // 
            this.ListBox_TournamentList.FormattingEnabled = true;
            this.ListBox_TournamentList.Location = new System.Drawing.Point(485, 55);
            this.ListBox_TournamentList.Name = "ListBox_TournamentList";
            this.ListBox_TournamentList.Size = new System.Drawing.Size(128, 212);
            this.ListBox_TournamentList.TabIndex = 6;
            // 
            // Label_TournamentList
            // 
            this.Label_TournamentList.AutoSize = true;
            this.Label_TournamentList.Location = new System.Drawing.Point(496, 39);
            this.Label_TournamentList.Name = "Label_TournamentList";
            this.Label_TournamentList.Size = new System.Drawing.Size(107, 13);
            this.Label_TournamentList.TabIndex = 7;
            this.Label_TournamentList.Text = "Список соперников";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 21;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 21;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 21;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 21;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 21;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 21;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 21;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 21;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Column9";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 21;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Column10";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 21;
            // 
            // DataGridView_CompetitorField
            // 
            this.DataGridView_CompetitorField.AllowUserToAddRows = false;
            this.DataGridView_CompetitorField.AllowUserToDeleteRows = false;
            this.DataGridView_CompetitorField.AllowUserToResizeColumns = false;
            this.DataGridView_CompetitorField.AllowUserToResizeRows = false;
            this.DataGridView_CompetitorField.ColumnHeadersHeight = 10;
            this.DataGridView_CompetitorField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridView_CompetitorField.ColumnHeadersVisible = false;
            this.DataGridView_CompetitorField.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.DataGridView_CompetitorField.Location = new System.Drawing.Point(254, 55);
            this.DataGridView_CompetitorField.MultiSelect = false;
            this.DataGridView_CompetitorField.Name = "DataGridView_CompetitorField";
            this.DataGridView_CompetitorField.ReadOnly = true;
            this.DataGridView_CompetitorField.RowHeadersVisible = false;
            this.DataGridView_CompetitorField.RowTemplate.Height = 21;
            this.DataGridView_CompetitorField.RowTemplate.ReadOnly = true;
            this.DataGridView_CompetitorField.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_CompetitorField.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DataGridView_CompetitorField.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridView_CompetitorField.Size = new System.Drawing.Size(213, 213);
            this.DataGridView_CompetitorField.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 21;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 21;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Column3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 21;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Column4";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 21;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Column5";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 21;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Column6";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 21;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Column7";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 21;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Column8";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 21;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Column9";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 21;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Column10";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 21;
            // 
            // Label_ResourceCounter
            // 
            this.Label_ResourceCounter.AutoSize = true;
            this.Label_ResourceCounter.Location = new System.Drawing.Point(9, 284);
            this.Label_ResourceCounter.Name = "Label_ResourceCounter";
            this.Label_ResourceCounter.Size = new System.Drawing.Size(109, 13);
            this.Label_ResourceCounter.TabIndex = 9;
            this.Label_ResourceCounter.Text = "Доступно ресурсов:";
            // 
            // TextBox_ResourceCounter
            // 
            this.TextBox_ResourceCounter.Location = new System.Drawing.Point(121, 281);
            this.TextBox_ResourceCounter.Name = "TextBox_ResourceCounter";
            this.TextBox_ResourceCounter.ReadOnly = true;
            this.TextBox_ResourceCounter.Size = new System.Drawing.Size(23, 20);
            this.TextBox_ResourceCounter.TabIndex = 10;
            this.TextBox_ResourceCounter.TextChanged += new System.EventHandler(this.TextBox_ResourceCounter_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 314);
            this.Controls.Add(this.TextBox_ResourceCounter);
            this.Controls.Add(this.Label_ResourceCounter);
            this.Controls.Add(this.DataGridView_CompetitorField);
            this.Controls.Add(this.Label_TournamentList);
            this.Controls.Add(this.ListBox_TournamentList);
            this.Controls.Add(this.Label_Me);
            this.Controls.Add(this.Label_Competitor);
            this.Controls.Add(this.Button_Ready);
            this.Controls.Add(this.DataGridView_PlayerField);
            this.Controls.Add(this.MenuStrip_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip_Main;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "My WAR";
            this.MenuStrip_Main.ResumeLayout(false);
            this.MenuStrip_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_PlayerField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CompetitorField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Game;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_CreateServer;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ConnectToServer;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Help;
        private System.Windows.Forms.DataGridView DataGridView_PlayerField;
        private System.Windows.Forms.Button Button_Ready;
        private System.Windows.Forms.Label Label_Competitor;
        private System.Windows.Forms.Label Label_Me;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Disconnect;
        private System.Windows.Forms.ListBox ListBox_TournamentList;
        private System.Windows.Forms.Label Label_TournamentList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridView DataGridView_CompetitorField;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Label Label_ResourceCounter;
        private System.Windows.Forms.TextBox TextBox_ResourceCounter;

    }
}

