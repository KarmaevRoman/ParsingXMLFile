using System.Xml;

namespace ParsingXMLFile.Models
{
    class LoadXmlFile
    {
        private string _URLFile;

        private XmlDocument _XMLFile;

        public string URLFile 
        {
            get => _URLFile;
            set => URLFile = value;
        }

        public XmlDocument XMLFile
        {
            get => _XMLFile;
            set => _XMLFile = value;
        }

        public LoadXmlFile (XmlDocument _XMLFile, string _URLFile)
        {
            this._XMLFile = _XMLFile;
            this._URLFile = _URLFile;
            this._XMLFile.Load(this._URLFile);
        }

    }
}
