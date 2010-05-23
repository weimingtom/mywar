using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ServiceModel;
using System.Threading;
using System.Linq;
using MyWar.ClientService;

namespace MyWar
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class Server : IClientService
    {
        private static Player _serverPlayer;
        private static bool _isGameStarted = false;
        private static bool _automaticMode = false;
        private static List<Player> _players = new List<Player>();
        private static IDictionary<string, Player> _playerSessionMap = new Dictionary<string, Player>();

        private static int _currentPlayerIndex, _targetIndex;
        private static Player _currentPlayer, _target;
        private static int _fireCount;

        //ф-ия подключения клиента к серверу
        public bool Connect(string name)
        {
            if (!ValidateUserName(name))
            {
                return false;
            }

            Player player = new Player(name);
            player.Callback = OperationContext.Current.GetCallbackChannel<IClientServiceCallback>();

            NotifyPlayers(player, true);

            string sessionId = OperationContext.Current.SessionId;
            OperationContext.Current.Channel.Closing += (object sender, EventArgs args) =>
            {
                Player p = GetPlayerBySessionId(sessionId);
                if (p != null)
                {
                    _players.Remove(p);
                    _playerSessionMap.Remove(sessionId);
                    NotifyPlayers(p, false);
                }
            };
            
            _playerSessionMap[sessionId] = player;
            _players.Add(player);

            return true;
        }

        private Player GetPlayerBySessionId(string sessionId)
        {
            Player player;
            _playerSessionMap.TryGetValue(sessionId, out player);
            return player;
        }

        //ф-ия отключения клиента от сервера
        public void Disconnect()
        {
            string sessionId = OperationContext.Current.SessionId;
            Player player = GetPlayerBySessionId(sessionId);
            if (player != null)
            {
                _players.Remove(player);
                _playerSessionMap.Remove(sessionId);
                NotifyPlayers(player, false);
            }
            OperationContext.Current.Channel.Close();
        }

        public Player GetServer()
        {
            return _serverPlayer;
        }

        public List<Player> GetPlayers()
        {
            return _players;
        }

        public void SetField(string playerName, Field field)
        {
            Player player = _players.First<Player>((Player p) => { return p.Name == playerName; });
            player.Field = field;
        }

        //установка флага начала игры
        public void SetStartGame(bool state)
        {
            _isGameStarted = state;
        }

        //возвращает флаг начала игры клиенту
        public bool IsGameStarted()
        {
            return _isGameStarted;
        }

        public void SetAutomaticMode(bool auto)
        {
            _automaticMode = auto;
        }

        public bool IsAutomaticMode()
        {
            return _automaticMode;
        }

        public void Ready(string playerName)
        {
            Player player = _players.First<Player>((Player p) => { return p.Name == playerName; });
            player.IsReady = true;
            if (_players.All<Player>((Player p) => { return p.IsReady; }))
            {
                StartGame();
            }
        }

        public void SetServerPlayer(string name)
        {
            Player player = new Player(name);
            player.Callback = new ClientServiceCallback();
            _players.Add(player);
            _serverPlayer = player;
        }

        //проверка валидности никнейма игрока
        private bool ValidateUserName(String name)
        {
            name = name.ToLower();
            return _players.All<Player>((Player p) => { return p.Name.ToLower() != name; });
        }

        //оповещаем всех пользователей о входе нового игрока
        private void NotifyPlayers(Player player, bool isEnter)
        {
            foreach (Player p in _players)
            {
                if (p.Name != _serverPlayer.Name && p.Name != player.Name)
                {
                    IClientServiceCallback callback = p.Callback;
                    callback.Message("Игрок " + player.Name + (isEnter ? " присоединился" : " отсоединился"));
                }
            }
        }

        public void StartGame()
        {
            _currentPlayerIndex = -1;
            NextPlayer();

            foreach (Player player in _players)
            {
                player.Callback.Turn(_currentPlayer, _target);
            }
        }

        public void Fire(string playerName, int col, int row)
        {
            Player player = _players.First<Player>((Player p) => { return p.Name == playerName; });
            Field field = player.Field;
            int cellType = field.Cells[row][col];
            if (cellType == Field.Building)
            {
                field.Cells[row][col] = Field.Fire;
                field.BuildingCount--;
            }
            else if (cellType == Field.Empty)
            {
                field.Cells[row][col] = Field.Miss;
            }

            _fireCount++;

            foreach (Player p in _players)
            {
                p.Callback.Fire(player, col, row);
            }

            if (player.IsDead)
            {
                int lc = 0;
                Player lp = null;
                foreach (Player p in _players)
                {
                    if (player == p)
                    {
                        p.Callback.Message("Вы проиграли. У вас уничтожили все объекты.");
                    }
                    else
                    {
                        p.Callback.Message("У игрока " + player.Name + " уничтожены все объекты. Он проиграл.");
                    }
                    if (!p.IsDead)
                    {
                        lc++;
                        lp = p;
                    }
                }
                if (lc == 1)
                {
                    foreach (Player p in _players)
                    {
                        if (p == lp)
                        {
                            p.Callback.Message("Вы уничтожили все объекты у противников. Вы выиграли!");
                        }
                        else
                        {
                            p.Callback.Message("Игрок " + lp.Name + " выиграл.");
                        }
                    }
                }
            }

            if (!NextTarget())
            {
                NextPlayer();
            }

            foreach (Player p in _players)
            {
                p.Callback.Turn(_currentPlayer, _target);
            }
        }

        private bool NextTarget()
        {
            _targetIndex++;
            while (_targetIndex < _players.Count)
            {
                if (_targetIndex == _currentPlayerIndex)
                {
                    _targetIndex++;
                }
                if (_targetIndex < _players.Count)
                {
                    _target = _players[_targetIndex];
                    if (!_target.IsDead)
                    {
                        return true;
                    }
                }
                _targetIndex++;
            }
            return false;
        }

        private void NextPlayer()
        {
            do
            {
                _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
                _currentPlayer = _players[_currentPlayerIndex];
            }
            while (_currentPlayer.IsDead);
            _targetIndex = -1;
            NextTarget();
        }
    }
}