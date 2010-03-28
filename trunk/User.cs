using Service;

namespace my_war
{
    public class User
    {
        private string m_name = "";
        private bool isConnect = false;
        private bool isReady = false;
        private bool isGo = false;
        private bool isDisconnect = false;
        private serverServiceCallback m_callback;

        public string getUserName()
        {
            return m_name;
        }

        public void setUserName(string name)
        {
            m_name = name;
        }

        public void setUserCallback(serverServiceCallback callback)
        {
            m_callback = callback;
        }
    }
}