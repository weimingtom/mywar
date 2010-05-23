using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using MyWar.ClientService;

namespace MyWar
{
    public partial class CreateServerForm : Form
    {
        private Thread _playerListUpdateThread;
        private ServiceHost _host;
        private List<Player> _playerList = new List<Player>();

        public CreateServerForm(ServiceHost host)
        { 
            _host = host;
            _playerListUpdateThread = new Thread(new ThreadStart(UpdatePlayerList));
            InitializeComponent();
        }

        //работает в потоке и обновляет список если кто-то добавился или удалился
        private void UpdatePlayerList()
        {
            while (true)
            {
                if (this.DataGridView_Players.InvokeRequired)
                {
                    this.DataGridView_Players.Invoke(new UpdatePlayerListDelegate(UpdatePlayerListImpl));
                }
                else
                {
                    UpdatePlayerListImpl();
                }
                Thread.Sleep(500);
            }
        }

        private delegate void UpdatePlayerListDelegate();
        private void UpdatePlayerListImpl()
        {
            List<Player> userList = Game.Server.GetPlayers();
            if (userList.Count < _playerList.Count) //если кто-то отсоединился
            {
                this.DataGridView_Players.Rows.Clear();
                _playerList.Clear();
            }
            foreach (Player user in userList) //добавление нового игрока в список
            {
                bool isExists = _playerList.Any<Player>((Player p) => { return p.Name == user.Name; });
                if (!isExists)
                {
                    this.DataGridView_Players.Rows.Add(user.Name);
                    _playerList.Add(user);
                }
            }
        }

        private void Button_CreateServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_Nick.Text != "")
                {
                    _host.Open();
                    Game.Server.SetServerPlayer(this.TextBox_Nick.Text);
                    Game.Server.SetAutomaticMode(this.CheckBox_AutoMode.Checked);
                    Game.Player = Game.Server.GetServer();
                    Game.ClientService = Game.Server;

                    MessageBox.Show("Сервер создан");

                    this.Button_Start.Enabled = true;
                    this.Button_CreateServer.Enabled = false;
                    this.CheckBox_AutoMode.Enabled = false;
                    this.TextBox_Nick.Enabled = false;
                    _playerListUpdateThread.Start();
                }
                else
                {
                    MessageBox.Show("Укажите имя игрока");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            _playerListUpdateThread.Abort();
            Game.Server.SetStartGame(true);
            List<Player> userList = Game.Server.GetPlayers();
            if (userList.Count > 1)
            {
                Player serverPlayer = Game.Server.GetServer();
                foreach (Player user in userList)
                {
                    if (serverPlayer.Name != user.Name)
                    {
                        user.Callback.GameStart();
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Извините, игра не может быть начата, т.к к Вам никто не присоединился");
            }
        }

        private void button_getServerIP_Click(object sender, EventArgs e)
        {
            MessageBox.Show(NetHelper.GetHostAddress().ToString());
        }

        private void CreateServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _playerListUpdateThread.Abort();
        }

        private void CreateServerForm_Load(object sender, EventArgs e)
        {
            Player serverPlayer = Game.Server.GetServer();
            if (serverPlayer != null)
            {
                this.TextBox_Nick.Text = serverPlayer.Name;
                this.Button_CreateServer.Enabled = false;
                this.Button_Start.Enabled = true;
                this.CheckBox_AutoMode.Enabled = false;
                this.TextBox_Nick.Enabled = false;
            }

            List<Player> userList = Game.Server.GetPlayers();
            foreach (Player player in userList)
            {
                this.DataGridView_Players.Rows.Add(player.Name);
                _playerList.Add(player);
            }
        }
    }
}
