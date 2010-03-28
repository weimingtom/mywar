using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

using Service;

namespace my_war
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Server : serverService
    {
        private static List<User> m_gameUsers = new List<User>();
        private User m_user;
        private string m_userName = "artem";

        public bool Join(string name)
        {
            serverServiceCallback callback = OperationContext.Current.GetCallbackChannel<serverServiceCallback>();
            User newUser = new User();
            newUser.setUserName(name);
            newUser.setUserCallback(callback);
            m_user = newUser;
            Console.WriteLine("User {0} is connect", m_user.getUserName());
            return true;
        }

        public void Leave()
        {
            m_user = null;
            OperationContext.Current.Channel.Abort();
        }
    }
}