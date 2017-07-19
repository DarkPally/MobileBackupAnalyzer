using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;  
namespace MobileBackup.Configs
{
    public class ConfigOptionBase
    {
        [XmlAttribute("id")]  
        public int ID { get; set; }

        [XmlAttribute("required")]
        public int IsRequired { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("description")]
        public string Description { get; set; }
    }
}
