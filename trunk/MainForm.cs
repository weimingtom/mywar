using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace my_var
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItem_CreateServer_Click(object sender, EventArgs e)
        {
            CreateServerForm form = new CreateServerForm();
            form.ShowDialog(this);
        }

        private void ToolStripMenuItem_ConnectToServer_Click(object sender, EventArgs e)
        {
            ConnectToServerForm form = new ConnectToServerForm();
            form.ShowDialog(this);
        }
    }
}
