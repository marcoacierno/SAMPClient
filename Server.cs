using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Net.Sockets;
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
        public volatile bool dataAvaitable;
        public Server Server;
        public bool Online;

        public ServerInfo(Server server)
        {
            Server = server;
        }

        public void ReadData()
        {
            IPAddress ip;
            var success = IPAddress.TryParse(Server.Ip, out ip);

            if (!success)
            {
                ip = Dns.GetHostEntry(Server.Ip).AddressList[0];
            }

            var iPortNo = Convert.ToInt16(Server.Port);
            var ipEnd = new IPEndPoint(ip, iPortNo);

            var udpClient = new UdpClient();

            udpClient.Connect(ipEnd);

            var packet = SampSocket.CreatePacket(Server, "i");

            udpClient.Send(
                Encoding.ASCII.GetBytes(packet.ToCharArray()),
                packet.ToCharArray().Length
            );

            var response = udpClient.Receive(ref ipEnd);
            Debug.WriteLine("Response => " + Encoding.ASCII.GetString(response));
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
