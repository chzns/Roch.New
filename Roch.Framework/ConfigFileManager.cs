using System;
using System.Configuration;
using System.Text;

namespace Roch.Framework.Configuration
{
    public class ConfigFileManager
    {
        public static ConfigFileSection GetConfigFile()
        {
            return (ConfigFileSection)System.Configuration.ConfigurationManager.GetSection("ConfigFile");
        }
    }
}
