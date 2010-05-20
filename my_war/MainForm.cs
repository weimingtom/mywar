using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ClientService;

namespace my_war
{
    public partial class MainForm : Form
    {
        public static IClientService m_iClientService = null; // экземпляр клиенты, через него дергать методы
        public static CServer m_server = null; //это пользователь, который создал игру для него методы отдельные так он не в сети
        public static bool m_gameStart = false; //флаг начала игры
        public static string m_servername = ""; //никнейм сервака
        public static string m_userName = ""; //никнейм пользователя

        private ServiceHost m_host;
        private int m_usedResource = 0;
        private List<CUser> m_userListOnServer = null; //это для апликухи сервака
        private List<string> m_userListOnNet = null; //это для апоикухи клиенты, не забывай сервак обрабатывается по другому
        private int m_FireCounter = 0;

        public MainForm(ServiceHost _host)
        {
            this.m_userListOnServer = new List<CUser>();
            List<string> m_userListOnNet = new List<string>();
            MainForm.m_server = new CServer();
            this.m_host = _host;
            InitializeComponent();
            InitEmptyGameFields();
        }

        //список игроков для сервера
        private void getUserListOnServer()
        {
            this.m_userListOnServer = MainForm.m_server.getUserListOnServer();
        }

        //список игроков для клиента
        private void getUserListNet()
        {
            this.m_userListOnNet = MainForm.m_iClientService.getUserListOnNet();
        }

        private void InitEmptyGameFields()
        {
            for (int i = 0; i < 10; i++)
            {
                this.DataGridView_PlayerField.Rows.Add();
                this.DataGridView_CompetitorField.Rows.Add();
            }
        }

        private void InitControlsOnGameStart()
        {
            this.DataGridView_PlayerField.Enabled = true;
            this.TextBox_ResourceCounter.Text = Consts.RESOURCE_LIMIT.ToString();
            this.TextBox_ResourceCounter.Enabled = false;
            this.Button_Ready.Enabled = true;
        }


        private void ToolStripMenuItem_CreateServer_Click(object sender, EventArgs e)
        {
            CreateServerForm form = new CreateServerForm(this.m_host);
            form.ShowDialog(this);

            if (MainForm.m_gameStart)
            {
                InitControlsOnGameStart();
            }

            //обновление списка на формочке после старта игры на сервере
            if (MainForm.m_gameStart)
            {
                this.getUserListOnServer();
                foreach (CUser user in this.m_userListOnServer)
                {
                    if (MainForm.m_servername == user.getUserName())
                    {
                        continue;
                    }
                    this.ListBox_TournamentList.Items.Add(user.getUserName());
                }
            }
        }

        private void ToolStripMenuItem_ConnectToServer_Click(object sender, EventArgs e)
        {
            ConnectToServerForm form = new ConnectToServerForm(m_userName);
            form.ShowDialog(this);
            //обновление списка на формочке после старта игры на клиенте
            if (MainForm.m_iClientService != null && MainForm.m_iClientService.getStart())
            {
                InitControlsOnGameStart();
                getUserListNet();
                foreach (string username in this.m_userListOnNet)
                {
                    if (MainForm.m_userName == username)
                    {
                        continue;
                    }
                    this.ListBox_TournamentList.Items.Add(username);
                }
            }
        }

        private void DataGridView_PlayerField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.DataGridView_PlayerField.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != Consts.BUILDING_ICON)
            {
                if (m_usedResource < Consts.RESOURCE_LIMIT)
                {
                    this.DataGridView_PlayerField.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Consts.BUILDING_ICON;
                    m_usedResource++;
                }
            }
            else
            {
                this.DataGridView_PlayerField.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                m_usedResource--;
            }

            TextBox_ResourceCounter.Text = (Consts.RESOURCE_LIMIT - m_usedResource).ToString();
        }

        private void TextBox_ResourceCounter_TextChanged(object sender, EventArgs e)
        {
            if (TextBox_ResourceCounter.Text == "0")
            {
                TextBox_ResourceCounter.BackColor = Color.Red;
                this.Button_Ready.Enabled = true;
            }
            else
            {
                TextBox_ResourceCounter.BackColor = Color.White;
                this.Button_Ready.Enabled = false;
            }
        }

        private void Button_Fire_Click(object sender, EventArgs e)
        {
            int col = this.DataGridView_CompetitorField.SelectedCells[0].ColumnIndex;
            int row = this.DataGridView_CompetitorField.SelectedCells[0].RowIndex;

            this.DataGridView_CompetitorField.Rows[row].Cells[col].Value = Consts.FIRE_ICON;
        }

        private void DataGridView_CompetitorField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (this.DataGridView_CompetitorField.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != Consts.FIRE_ICON)
                {
                    if (m_FireCounter < Consts.FIRE_LIMIT)
                    {
                        m_FireCounter++;
                        this.DataGridView_CompetitorField.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Consts.FIRE_ICON;
                    }
                }
                else
                {
                    this.DataGridView_CompetitorField.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    m_FireCounter--;
                }
        }

        private void Button_Ready_Click(object sender, EventArgs e)
        {
            //this.DataGridView_CompetitorField.Enabled = false;
            this.DataGridView_PlayerField.Enabled = false;
            //this.Button_Fire.Enabled = true;
            this.Button_Ready.Enabled = false;
        }
    }
}
