using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SAMPClient
{
    [XmlRoot("server")]
    public class Server
    {
        [XmlElement("hostname")]
        public string HostName;
        [XmlElement("ip")]
        public string Ip;

        public Server(string hostname, string ip)
        {
            HostName = hostname;
            Ip = ip;
        }

        private Server() { }
    }

    public class ServerInfo
    {
        public Server Server;
        public string MapName;
        public string Version;
        public string Weburl;
        public string WorldTime;
        public int Weather;
        public int Lagcomp;
        public List<Player> Players;



    }
}
