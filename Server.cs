using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SAMPClient.Tests.Utility.SAMP;

namespace SAMPClient
{
    [XmlRoot("server")]
    public class Server
    {
        [XmlElement("hostname")]
        public string HostName;
        [XmlElement("ip")]
        public string Ip;
        [XmlElement("port")] 
        public int Port;
        [XmlIgnore] 
        public ServerInfo ServerInfo;

        public Server(string hostname, string completeAddress)
            : this(hostname, completeAddress.Substring(0, completeAddress.IndexOf(':')), int.Parse(completeAddress.Substring(completeAddress.IndexOf(':') + 1)))
        {
        }

        public Server(string hostname, string ip, int port)
        {
            HostName = hostname;
            Ip = ip;
            Port = port;

            ServerInfo = new ServerInfo(this);
        }

        /* utilizzato solo dal serializer */

        private Server()
        {
            ServerInfo = new ServerInfo(this);
        }
    }

    public class ServerInfo
    {
        public string MapName;
        public string Version;
        public string Weburl;
        public string WorldTime;
        public string Gamemode;
        public int Weather;
        public int Lagcomp;
        public List<Player> Players;
        public Server Server;
        public bool Online;

        private bool locked;
        public bool Locked
        {
            get { return locked; }
            set
            {
                var oldLocked = Locked;
                if (oldLocked != value)
                {
                    Updated = true;
                }

                locked = value;
            }
        }

        public bool Updated;

        public ServerInfo(Server server)
        {
            Server = server;
        }

        public Task<bool> ReadData()
        {
            return Task<bool>.Factory.StartNew(() =>
            {
                var query = new Query(Server.Ip, Server.Port);
                query.Send('i');

                var count = query.Receive();
                var info = query.Store(count);

                if (info.Length == 0)
                {
                    /* qualcosa è andato storto? */
                    return false;
                }

                Locked = int.Parse(info[0]) == 1;
                Players = new List<Player>(int.Parse(info[2]));
                Server.HostName = info[3];
                Gamemode = info[4];
                MapName = info[5];

                return true;
            });
        }

        public override string ToString()
        {
            return "Mapname: " + MapName + Environment.NewLine +
                   "Gamemode: " + Gamemode + Environment.NewLine +
                   "Weburl: " + Weburl + Environment.NewLine +
                   "WorldTime: " + WorldTime + Environment.NewLine;
        }
    }
}
