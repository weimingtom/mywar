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
        private int m_usedResource = 0;
        public static IClientService m_iClientService = null;

        public MainForm(ServiceHost _host)
        {
            this.m_host = _host;
            InitializeComponent();
            InitEmptyGameFields();
            this.TextBox_ResourceCounter.Text = Consts.RESOURCE_LIMIT.ToString();
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
        }

        private void ToolStripMenuItem_ConnectToServer_Click(object sender, EventArgs e)
        {
            ConnectToServerForm form = new ConnectToServerForm();
            form.ShowDialog(this);
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
