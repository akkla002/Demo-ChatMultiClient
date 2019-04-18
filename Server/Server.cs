using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class Server
    {
        IPEndPoint serverEndPoint;
        Socket serverSocket;
        List<Socket> Clients;
        LogFile theLogFile;
        public Server()
        {
            serverEndPoint = new IPEndPoint(IPAddress.Any, 9889);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Clients = new List<Socket>();
            theLogFile = new LogFile();
        }
        public void Start()
        {

        }
        private void Listen()
        {
            serverSocket.Bind(serverEndPoint);
            serverSocket.Listen(10);
            Thread t = new Thread(ControlsClient);
            t.Start();
        }
        private void ControlsClient()
        {
            while (true)
            {
                if (Clients.Count < 10)
                {
                    Socket client = serverSocket.Accept();
                    Clients.Add(client);
                    theLogFile.WriteLog(client.LocalEndPoint.ToString() + " -- " + " have connect");
                    try
                    {
                        byte[] buffReceive = new byte[1024];
                        int size = client.Receive(buffReceive, 0, buffReceive.Length, SocketFlags.None);

                    }
                    catch (SocketException e)
                    {
                        Clients.Remove(client);
                        theLogFile.WriteLog(client.LocalEndPoint.ToString() + " -- " + e.ToString());
                    }
                }
            }
        }
    }
}
