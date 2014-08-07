using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SAMPClient
{
    public class Settings : IXmlSerializable
    {
        public string GTALocation;
        public string UserNickname;
        public bool AutoSaveServerPassword;
        public bool AutoSaveRconPassword;

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Settings");

            writer.WriteElementString("GTALocation", GTALocation);
            writer.WriteElementString("Nickname", UserNickname);
            writer.WriteElementString("AutoSaveRcon", AutoSaveRconPassword.ToString());
            writer.WriteElementString("AutoSaveServerPsw", AutoSaveServerPassword.ToString());

            writer.WriteEndElement();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("Settings");
            reader.ReadStartElement("Settings");

            GTALocation = reader.ReadElementString("GTALocation");
            UserNickname = reader.ReadElementString("Nickname");
            AutoSaveRconPassword = Boolean.Parse(reader.ReadElementString("AutoSaveRcon"));
            AutoSaveServerPassword = Boolean.Parse(reader.ReadElementString("AutoSaveServerPsw"));

            reader.ReadEndElement();
            reader.ReadEndElement();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void Save()
        {
            var serializer = new XmlSerializer(GetType());
            
            using (var settingsWriter = new StreamWriter("settings.xml"))
            {
                serializer.Serialize(settingsWriter, this);    
            }
        }

        public static Settings Read()
        {
            if (!File.Exists("settings.xml"))
            {
                return CreateDefault();
            }

            var unserializer = new XmlSerializer(typeof(Settings));

            using (var settingsReader = new StreamReader("settings.xml"))
            {
                return (Settings) unserializer.Deserialize(settingsReader);
            }
        }

        private static Settings CreateDefault()
        {
            var settings = new Settings
            {
                GTALocation = "unknow",
                UserNickname = "user" + new Random().Next(0, 500),
                AutoSaveRconPassword = false,
                AutoSaveServerPassword = false
            };

            settings.Save();
            return settings;
        }
    }
}
