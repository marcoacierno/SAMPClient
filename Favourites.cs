using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SAMPClient
{
    [XmlRoot("favourites")]
    public class Favourites
    {
        [XmlIgnore]
        public const string ServersFile = "servers.xml";
        [XmlElement("server")]
        public List<Server> Servers = new List<Server>();

        private Favourites() { }

        public void AddToFavourites(Server server)
        {
            Servers.Add(server);
        }

        public void Save()
        {
            var serializer = new XmlSerializer(GetType());
            using (var writer = new StreamWriter(ServersFile))
            {
                serializer.Serialize(writer, this);
            }
        }

        public static Favourites Read()
        {
            if (!File.Exists(ServersFile))
            {
                File.Create(ServersFile).Close();
                return new Favourites();
            }

            Favourites favourites;
            var serializer = new XmlSerializer(typeof(Favourites));

            using (var reader = new StreamReader(ServersFile))
            {
                favourites = (Favourites)serializer.Deserialize(reader);
            }

            return favourites;
        }
    }
}
