using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace SAMPClient
{
    [XmlRoot("settings")]
    public class Settings
    {
        [XmlElement("gtalocation")]
        public string GTALocation;
        [XmlElement("basepath")] 
        public string GTABasePath;
        [XmlElement("nickname")]
        public string UserNickname;
        [XmlElement("saveserverpsw")]
        public bool AutoSaveServerPassword;
        [XmlElement("saverconpsw")]
        public bool AutoSaveRconPassword;

        private Settings() { }

        public void Save()
        {
//            Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("SAMP").SetValue("PlayerName", UserNickname);

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
            var key = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("SAMP");
            /* l'utente deve chiudere almeno una volta sa-mp per far salvare i dati */

            var settings = new Settings
            {
                GTALocation = (string)key.GetValue("gta_sa_exe") ?? "Unknow",
                UserNickname = (string)key.GetValue("PlayerName") ?? "User" + new Random().Next(0, 10),
                AutoSaveRconPassword = false,
                AutoSaveServerPassword = false,
            };
            settings.GTABasePath = Path.GetDirectoryName(settings.GTALocation);

            settings.Save();
            return settings;
        }
    }
}
