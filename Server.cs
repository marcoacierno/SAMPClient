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
        public readonly string Ip;
        [XmlElement("port")] 
        public readonly int Port;
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

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (!(obj is Server)) return false;
            
            var sObj = (Server) obj;
            return sObj.Ip == Ip && sObj.Port == Port;
        }

        public static bool operator ==(Server s1, Server s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(Server s1, Server s2)
        {
            return !(s1 == s2);
        }

        public override int GetHashCode()
        {
            // when deserializer ip is null?
            return base.GetHashCode();
//            return Ip.GetHashCode() + Port.GetHashCode();
        }
    }

    public class ServerInfo
    {
        private string mapName;
        private string version;
        private string weburl;
        private string worldTime;
        private string gamemode;
        private int weather;
        private int lagcomp;
        public List<Player> Players;
        private bool online;

        public int Lagcomp
        {
            get { return lagcomp; }
            set
            {
                var old = lagcomp;
                if (old != value)
                {
                    updated = true;
                }
                
                lagcomp = value;
            }
        }

        public string Gamemode
        {
            get { return gamemode; }
            set
            {
                var old = gamemode;
                if (old != value)
                {
                    updated = true;
                }
                
                gamemode = value;
            }
        }

        public string MapName
        {
            get { return mapName; }
            set
            {
                var old = mapName;
                if (old != value)
                {
                    updated = true;
                }
                
                mapName = value;
            }
        }

        public bool Online
        {
            get { return online; }
            set
            {
                var old = online;
                if (old != value)
                {
                    updated = true;
                }
                
                online = value;
            }
        }

        public Server Server { get; set; }

        public string Version
        {
            get { return version; }
            set
            {
                var old = version;
                if (old != value)
                {
                    updated = true;
                }
                
                version = value;
            }
        }

        public int Weather
        {
            get { return weather; }
            set
            {
                var old = weather;
                if (old != value)
                {
                    updated = true;
                }
                
                weather = value;
            }
        }

        public string WorldTime
        {
            get { return worldTime; }
            set
            {
                var old = worldTime;
                if (old != value)
                {
                    updated = true;
                }
                
                worldTime = value;
            }
        }

        public string Weburl
        {
            get { return weburl; }
            set
            {
                var old = Weburl;
                if (old != value)
                {
                    updated = true;
                }

                weburl = value;
            }
        }

        private bool locked;
        public bool Locked
        {
            get { return locked; }
            set
            {
                var old = Locked;
                if (old != value)
                {
                    updated = true;
                }

                locked = value;
            }
        }
        private bool updated;

        public ServerInfo(Server server)
        {
            Server = server;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventServerInfoChanged">Invocato se il download dei dati ha causato una modifica ai dati</param>
        /// <returns></returns>
        public Task ReadData(EventHandler<EventArgs> eventServerInfoChanged = null)
        {
            return Task.Factory.StartNew(() =>
            {
                var query = new Query(Server.Ip, Server.Port);
                query.Send('i');

                var count = query.Receive();
                var info = query.Store(count);

                if (info.Length == 0)
                {
                    /* qualcosa è andato storto? */
                    return;
                }

                Locked = int.Parse(info[0]) == 1;
                Players = new List<Player>(int.Parse(info[2]));
                Server.HostName = info[3];
                Gamemode = info[4];
                MapName = info[5];

                if (updated && eventServerInfoChanged != null)
                {
                    eventServerInfoChanged(Server, null);
                }

                updated = false;
            });
        }

        public override string ToString()
        {
            return "Mapname: " + mapName + Environment.NewLine +
                   "Gamemode: " + gamemode + Environment.NewLine +
                   "Weburl: " + weburl + Environment.NewLine +
                   "WorldTime: " + worldTime + Environment.NewLine;
        }
    }
}
