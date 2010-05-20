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
        private ServiceHost m_host;
        public static IClientService m_iClientService = null;
        public static CServer m_server = null;
        public static bool m_gameStart = false;
        public static string m_servername = "";

        private int m_usedResource = 0;
        private List<CUser> m_userListOnServer = null;
        private List<string> m_userListOnNet = null;

        public MainForm(ServiceHost _host)
        {
            this.m_userListOnServer = new List<CUser>();
            List<string> m_userListOnNet = new List<string>();
            MainForm.m_server = new CServer();
            this.m_host = _host;
            InitializeComponent();
            InitEmptyGameFields();
            this.TextBox_ResourceCounter.Text = Consts.RESOURCE_LIMIT.ToString();
        }

        private void getUserListOnServer()
        {
            this.m_userListOnServer = MainForm.m_server.getUserListOnServer();
        }

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

        private void ToolStripMenuItem_CreateServer_Click(object sender, EventArgs e)
        {
            CreateServerForm form = new CreateServerForm(this.m_host);
            form.ShowDialog(this);
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
            ConnectToServerForm form = new ConnectToServerForm();
            form.ShowDialog(this);
            if (MainForm.m_iClientService.getStart())
            {
                getUserListNet();
                MessageBox.Show(this.m_userListOnNet[0]);
                foreach (string user in this.m_userListOnNet)
                {
                    this.ListBox_TournamentList.Items.Add(user);
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
            }
            else
            {
                TextBox_ResourceCounter.BackColor = Color.White;
            }
        }
    }
}
