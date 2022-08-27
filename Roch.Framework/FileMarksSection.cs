using System.Configuration;

namespace Roch.Framework.Configuration
{
    [ConfigurationCollection(typeof(FileSection), AddItemName = "File")]
    public class FileMarksSection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FileSection();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FileSection)element).name;
        }

        public FileSection this[int index]
        {
            get { return (FileSection)base.BaseGet(index); }
        }

        new public FileSection this[string name]
        {
            get { return (FileSection)base.BaseGet(name); }
        }
    }
}