using System.Configuration;

namespace Roch.Framework.Configuration
{
    public class FileSection : ConfigurationElement
    {
        //name属性
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string name { get { return (string)this["name"]; } set { name = value; } }
        //path属性
        [ConfigurationProperty("path", IsRequired = true)]
        public string path { get { return (string)this["path"]; } set { path = value; } }
        //size属性
        [ConfigurationProperty("processClass", IsRequired = true)]
        public string processClass { get { return (string)this["processClass"]; } set { processClass = value; } }
    }
}