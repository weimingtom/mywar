using System.ServiceModel;
using ClientService;

namespace ClientService
{
    public class CUser
    {
        private string m_userName = null;
        private IClientServiceCallback m_callback;
        private bool m_isConnect = false;

        public CUser(string userName, IClientServiceCallback userCallback)
        {
            this.m_userName = userName;
            this.m_callback = userCallback;
        }
       
        public string getUserName()
        {
            return this.m_userName;
        }

        public void setUserName(string name)
        {
            this.m_userName = name;
        }

        public IClientServiceCallback getCallback()
        {
            return this.m_callback;
        }

        public bool getStateConnect()
        {
            return this.m_isConnect;
        }

        public void setStateConnect(bool state)
        {
            this.m_isConnect = state;
        }
    }
}