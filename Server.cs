using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMPClient
{
    sealed class Server
    {
        public readonly string HostName;
        public readonly string IP;

        public Server(string hostname, string ip)
        {
            HostName = hostname;
            IP = ip;
        }
    }
}
