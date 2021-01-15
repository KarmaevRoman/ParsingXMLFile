using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Xml;

namespace ParsingXMLFile.Models
{
    class TreeElement
    {
        public string name { get; set; }

        public ObservableCollection<TreeElement> TreeElements { get; set; }

        public void Add (TreeElement ChildElement)
        {
            TreeElements = new ObservableCollection<TreeElement>();
            TreeElements.Add(ChildElement);
        }
        
        public void AddTreeElementFromXml (XmlElement xmlElement)
        {
            TreeElements = new ObservableCollection<TreeElement>();
            name = xmlElement.Name;                
           
            foreach (XmlAttribute SelectAtr in xmlElement.Attributes)
                name += ($" {SelectAtr.Name} = '{SelectAtr.Value}'");

            foreach (var ChildElemennt in xmlElement.ChildNodes)
            {
                if (ChildElemennt is XmlElement)
                {                    
                    var SubElement = new TreeElement();
                    TreeElements.Add(SubElement);
                    SubElement.AddTreeElementFromXml((XmlElement)ChildElemennt);
                }

                if (ChildElemennt is XmlText text)
                {
                    name += ($" - {text.Value}");
                }
            }
        }
    }
}
