using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MobileBackup.Configs
{
    [XmlRoot("root")]  
    public class DataCollectConfig
    {
        [XmlAttribute("id")]
        public int ID { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("CollectOption")]
        public List<ConfigOptionBase> CollectOptions { get; set; }

        [XmlElement("IMOption")]
        public List<ConfigeAppOption> IMOptions { get; set; }

        [XmlElement("BLOGOption")]
        public List<ConfigeAppOption> BLOGOptions { get; set; }

        [XmlElement("MailOption")]
        public List<ConfigeAppOption> MailOptions { get; set; }

        [XmlElement("LocationOption")]
        public List<ConfigeAppOption> LocationOptions { get; set; }

        [XmlElement("BrowserOption")]
        public List<ConfigeAppOption> BrowserOptions { get; set; }

        [XmlElement("CloudOption")]
        public List<ConfigeAppOption> CloudOptions { get; set; }

        [XmlElement("CollectExtendOption")]
        public List<ConfigOptionBase> CollectExtendOptions { get; set; }
    }

    
}
