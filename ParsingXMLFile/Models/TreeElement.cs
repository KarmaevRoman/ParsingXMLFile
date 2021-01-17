using System.Collections.ObjectModel;
using System.Xml;

namespace ParsingXMLFile.Models
{
    class TreeElement
    {
        public string Name { get; set; }

        public ObservableCollection<TreeElement> TreeElements { get; set; }
              
        public void AddTreeElementFromXml (XmlElement xmlElement)
        {
            TreeElements = new ObservableCollection<TreeElement>();
            Name = xmlElement.Name;                
           
            foreach (XmlAttribute SelectAtr in xmlElement.Attributes)
                Name += ($" {SelectAtr.Name} = '{SelectAtr.Value}'");

            foreach (var сhildElemennt in xmlElement.ChildNodes)
            {
                if (сhildElemennt is XmlElement)
                {                    
                    var SubElement = new TreeElement();
                    TreeElements.Add(SubElement);
                    SubElement.AddTreeElementFromXml((XmlElement)сhildElemennt);
                }

                if (сhildElemennt is XmlText text)
                {
                    Name += ($" - {text.Value}");
                }
            }
        }
    }
}
