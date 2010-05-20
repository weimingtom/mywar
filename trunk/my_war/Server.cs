using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ServiceModel;
using System.Threading;
using ClientService;

namespace my_war
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class CServer : IClientService
    {
        private CUser m_user;
        private bool m_isStartGame = false;
        private static List<CUser> m_userInGame = new List<CUser>();

        private bool validateUselNickname(List<CUser> userInGame, String nickname)
        {
            for (int i = 0; i < userInGame.Count; i++)
            {
                if (nickname.Equals(userInGame[i].getUserName()))
                {
                    i = userInGame.Count;
                    return false;
                }
            }
            return true;
        }

        //оповещаем всех пользователей о входе нового игрока
        private void sendMessageAllUsers(List<CUser> userInGame, String nickname, bool isEnter)
        {
            foreach (CUser user in userInGame)
            {
                try
                {
                    if (MainForm.m_servername == user.getUserName())
                    {
                        continue;
                    }

                    IClientServiceCallback usercallback = user.getCallback();
                    if (isEnter)
                    {
                        usercallback.userEnter(nickname);
                    }
                    else
                    {
                        usercallback.userLeave(nickname);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public bool Connect(string name)
        {
            if (validateUselNickname(m_userInGame, name))
            {
                //Получаем интерфейс обратного вызова 
                IClientServiceCallback callback = OperationContext.Current.GetCallbackChannel<IClientServiceCallback>();
                sendMessageAllUsers(m_userInGame, name, true);
                //Создаем новый экземпляр пользователя и заполняем все его поля
                CUser curUser = new CUser(name, callback);
                curUser.setStateConnect(true);
                //добавляем юзера
                m_userInGame.Add(curUser);
                this.m_user = curUser;
                MessageBox.Show("Игрок " + name + " присоединился");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Disconnect()
        {
            m_userInGame.Remove(this.m_user);
            sendMessageAllUsers(m_userInGame, this.m_user.getUserName(), false);
            MessageBox.Show("Игрок " + this.m_user.getUserName() + " отсоединился");
            this.m_user = null;
            //Закрываем канал связи с текущим пользователем
            OperationContext.Current.Channel.Close();
        }

        public void setStartGame(bool state)
        {
            this.m_isStartGame = state;
        }

        public List<CUser> getUserListOnServer()
        {
            return m_userInGame;
        }

        public List<string> getUserListOnNet()
        {
            List<string> tmplist = new List<string>();
            foreach (CUser user in m_userInGame)
            {
                tmplist.Add(user.getUserName());
            }
            return tmplist;
        }

        public bool getStart()
        {
            return MainForm.m_gameStart;
        }

        public void addServerName(string servername)
        {
            CUser user = new CUser(servername, null);
            m_userInGame.Add(user);
        }

        public int getUserListSize()
        {
            return m_userInGame.Count;
        }
    }
}