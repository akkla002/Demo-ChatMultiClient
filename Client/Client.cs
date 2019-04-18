using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public class Client
    {
        TheUser user;
        private string userName;
        private string passWord;


        public TheUser User
        {
            get { return user; }
            set { user = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9889);
        Socket serverSocket;

        public Client()
        {
            user = new TheUser();
        }

        public bool Login()
        {
            try
            {
                serverSocket.Connect(serverEP);
                
            }
            return false;
        }
    }
}
