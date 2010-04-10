using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace my_war
{
    public partial class MainForm : Form
    {
        private ServiceHost m_host;
        public MainForm(ServiceHost _host)
        {
            this.m_host = _host;
            InitializeComponent();
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
    }
}
