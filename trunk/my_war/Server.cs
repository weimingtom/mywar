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
        private static List<CUser> m_userInGame = new List<CUser>();

        public bool Connect(string name)
        {
            //Получаем интерфейс обратного вызова 
            IClientServiceCallback callback = OperationContext.Current.GetCallbackChannel<IClientServiceCallback>();
            foreach (CUser user in m_userInGame)
            {
                try
                {
                    IClientServiceCallback usercallback = user.getCallback();
                    usercallback.userEnter(name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //Создаем новый экземплар пользователя и заполняем все его поля
            CUser curUser = new CUser(name, callback);
            curUser.setStateConnect(true);
            //добавляем юзера
            m_userInGame.Add(curUser);
            this.m_user = curUser;
            return true;
        }

        public void Disconnect()
        {
            m_userInGame.Remove(this.m_user);
            foreach (CUser user in m_userInGame)
            {
                IClientServiceCallback callback = user.getCallback();
                callback.userLeave(this.m_user.getUserName());
            }
            this.m_user = null;
            //Закрываем канал связи с текущим пользователем
            OperationContext.Current.Channel.Close();
        }

        public List<CUser> getUserList()
        {
            return m_userInGame;
        }
    }
}