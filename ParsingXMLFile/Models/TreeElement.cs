using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ParsingXMLFile.Models
{
    class TreeElement
    {
        public string name { get; set; }

        public ObservableCollection<TreeElement> TreeElements { get; set; }
    }
}
