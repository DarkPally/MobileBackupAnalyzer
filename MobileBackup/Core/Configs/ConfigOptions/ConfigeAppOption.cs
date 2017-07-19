using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;  
namespace MobileBackup.Configs
{
    
    public class ConfigeAppOption:ConfigOptionBase
    {

        [XmlAttribute("description_android")]
        public string Description_Android { get; set; }
        [XmlAttribute("description_ios")]
        public string Description_IOS { get; set; }

        [XmlIgnore()]
        public string PackageName_Android
        {
            get
            {
                var temp=Description_Android.Split('/');
                return temp[0];
            }
        }
    }
}
