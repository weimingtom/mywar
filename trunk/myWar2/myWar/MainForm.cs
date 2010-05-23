using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MyWar.ClientService;

namespace MyWar
{
    public partial class MainForm : Form
    {
        private ServiceHost _host;
        private int _usedResource = 0;

        public MainForm(ServiceHost host)
        {
            Game.Server = new Server();
            this._host = host;
            InitializeComponent();
            InitEmptyGameFields();
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
            this.TextBox_ResourceCounter.Text = Const.RESOURCE_LIMIT.ToString();
            this.TextBox_ResourceCounter.Enabled = false;
            this.Button_Ready.Enabled = true;
        }

        private void ToolStripMenuItem_CreateServer_Click(object sender, EventArgs e)
        {
            CreateServerForm form = new CreateServerForm(this._host);
            form.ShowDialog(this);
            StartGame();
        }

        private void ToolStripMenuItem_ConnectToServer_Click(object sender, EventArgs e)
        {
            ConnectToServerForm form = new ConnectToServerForm();
            form.ShowDialog(this);
            StartGame();
        }

        private void StartGame()
        {
            IClientService server = Game.ClientService;
            if (server != null && server.IsGameStarted())
            {
                InitControlsOnGameStart();
                UpdatePlayerList();
                if (server.IsAutomaticMode())
                {
                    AutoSetBuildings();
                }
            }
        }

        private void UpdatePlayerList()
        {
            Player current = Game.CurrentPlayer;
            Player target = Game.Target;

            IClientService server = Game.ClientService;
            this.ListBox_TournamentList.Items.Clear();
            foreach (Player player in server.GetPlayers())
            {
                string itemText = player.Name;
                if (current != null && player.Name == current.Name)
                {
                    itemText += (Game.Player.Name == player.Name ? " [вы атакуете]" : " [атакует]");
                }
                else if (target != null && player.Name == target.Name)
                {
                    itemText += (Game.Player.Name == player.Name ? " [вас атакуют]" : " [цель]");
                }
                this.ListBox_TournamentList.Items.Add(itemText);
            }
        }

        private void DataGridView_PlayerField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.DataGridView_PlayerField[e.ColumnIndex, e.RowIndex].Value as string != Const.BUILDING_ICON)
            {
                if (_usedResource < Const.RESOURCE_LIMIT)
                {
                    this.DataGridView_PlayerField[e.ColumnIndex, e.RowIndex].Value = Const.BUILDING_ICON;
                    _usedResource++;
                }
            }
            else
            {
                this.DataGridView_PlayerField[e.ColumnIndex, e.RowIndex].Value = "";
                _usedResource--;
            }

            TextBox_ResourceCounter.Text = (Const.RESOURCE_LIMIT - _usedResource).ToString();
        }

        private void TextBox_ResourceCounter_TextChanged(object sender, EventArgs e)
        {
            bool resourcesIsOver = (TextBox_ResourceCounter.Text == "0");
            this.TextBox_ResourceCounter.BackColor = resourcesIsOver ? Color.Red : Color.White;
            this.Button_Ready.Enabled = resourcesIsOver;
        }

        private void Button_Fire_Click(object sender, EventArgs e)
        {
            int col = this.DataGridView_CompetitorField.SelectedCells[0].ColumnIndex;
            int row = this.DataGridView_CompetitorField.SelectedCells[0].RowIndex;
            this.DataGridView_CompetitorField[col, row].Value = Const.FIRE_ICON;
            Fire(col, row);
        }

        private void UpdateFireButton()
        {
            int col = this.DataGridView_CompetitorField.SelectedCells[0].ColumnIndex;
            int row = this.DataGridView_CompetitorField.SelectedCells[0].RowIndex;
            Button_Fire.Enabled = this.DataGridView_CompetitorField[col, row].Value as string != Const.FIRE_ICON && Game.CurrentPlayer.Name == Game.Player.Name;
        }

        private void DataGridView_CompetitorField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateFireButton();
        }

        private void Button_Ready_Click(object sender, EventArgs e)
        {
            Ready();
        }

        private void AutoSetBuildings()
        {
            Random rnd = new Random();
            for (int i = 0; i < Const.RESOURCE_LIMIT; i++)
            {
                int col, row;
                do
                {
                    col = rnd.Next(10);
                    row = rnd.Next(10);
                }
                while (this.DataGridView_PlayerField[col, row].Value as string == "");
                this.DataGridView_PlayerField[col, row].Value = Const.BUILDING_ICON;
                _usedResource++;
            }
            TextBox_ResourceCounter.Text = "0";
            Ready();
        }

        private void Ready()
        {
            Player me = Game.Player;

            Field field = me.Field;
            field.BuildingCount = 0;
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (this.DataGridView_PlayerField[col, row].Value as string == Const.BUILDING_ICON)
                    {
                        field.Cells[row][col] = Field.Building;
                        field.Scores[row][col] = Const.BUILDING_COST;
                        field.BuildingCount++;
                    }
                    else
                    {
                        field.Cells[row][col] = Field.Empty;
                    }
                }
            }
            Game.ClientService.SetField(me.Name, field);

            ClientServiceCallback callback = Game.Player.Callback as ClientServiceCallback;
            callback.OnTurn += (Player player, Player target) =>
            {
                Game.CurrentPlayer = player;
                Game.Target = target;

                UpdatePlayerList();
                UpdatePlayerField();

                if (me.Name == target.Name)
                {
                    this.Label_Me.Text = me.Name + "  (вас атакуют)";
                    this.Label_Competitor.Text = player.Name;
                    UpdateCompetitorField(player);
                }
                else
                {
                    this.Label_Me.Text = me.Name + (player.Name == me.Name ? " (вы атакуете)" : "");
                    this.Label_Competitor.Text = target.Name;
                    UpdateCompetitorField(target);
                }
                UpdateFireButton();
            };

            callback.OnFire += (Player player, int col, int row) =>
            {
                if (player.Name == Game.Player.Name)
                {
                    Game.Player = player;
                    UpdatePlayerField();
                }
                else
                {
                    UpdateCompetitorField(player);
                }
            };

            this.DataGridView_PlayerField.Enabled = false;
            this.DataGridView_CompetitorField.Enabled = true;
            this.Button_Fire.Enabled = false;
            this.Button_Ready.Enabled = false;

            Game.ClientService.Ready(me.Name);
        }

        private void UpdatePlayerField()
        {
            Field field = Game.Player.Field;
            UpdateField(this.DataGridView_PlayerField, field, true);
        }

        private void UpdateCompetitorField(Player player)
        {
            Field field = player.Field;
            UpdateField(this.DataGridView_CompetitorField, field, false);
        }

        private void UpdateField(DataGridView grid, Field field, bool showAll)
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    byte cellType = field.Cells[row][col];
                    string icon = "";
                    if (cellType == Field.Building && showAll)
                        icon = Const.BUILDING_ICON;
                    else if (cellType == Field.Fire)
                        icon = Const.FIRE_ICON;
                    else if (cellType == Field.Miss)
                        icon = Const.MISS_ICON;
                    grid[col, row].Value = icon;
                }
            }
        }

        private void Fire(int col, int row)
        {
            Game.ClientService.Fire(Game.Target.Name, col, row);
        }
    }
}
