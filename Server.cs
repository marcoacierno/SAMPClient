using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMPClient
{
    class Server
    {
        public string HostName;
        public string ip;

        public Server(string hostname, string ip)
        {
            HostName = hostname;
            this.ip = ip;
        }
    }
}
