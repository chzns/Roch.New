using System.Configuration;

namespace Roch.Framework.Configuration
{
    public class ConfigFileSection : ConfigurationSection
    {
        //FileMarks节点
        [ConfigurationProperty("FileMarks")]
        public FileMarksSection FileMarksSetting { get { return (FileMarksSection)base["FileMarks"]; } }
    }
}