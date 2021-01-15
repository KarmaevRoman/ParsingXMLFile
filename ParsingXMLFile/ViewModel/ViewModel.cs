using ParsingXMLFile.ViewModel.Base;
using System;
using System.Windows.Input;
using System.Xml;
using System.Windows;
using System.IO;
using ParsingXMLFile.Models;
using System.Collections.ObjectModel;

namespace ParsingXMLFile.ViewModel
{
    class ViewModel : MainViewModel
    {
        private string _link;
        
        public string Link
        {
            get => _link;
            set => Set(ref _link, value);
        }

        private ObservableCollection<TreeElement> _treeElements;

        public ObservableCollection<TreeElement> TreeElements
        {
            get => _treeElements;
            set => Set(ref _treeElements, value);
        }

        public ICommand LoadXmlFile { get; }
        private bool CanLoadXmlFileExecute(object p) => true;
        private void OnLoadXmlFileExecute(object p)
        {
            var xmlFile = new XmlDocument();
            if (Link == null)
                MessageBox.Show("Ссылка отсутствует.");
            else
            {
                try
                {
                    xmlFile.Load(Link);
                    xmlFile.Save("myfile.xml");
                    MessageBox.Show("Файл успешно загружен.");                    
                }

                catch (Exception)
                {
                    MessageBox.Show("Неверная ссылка или некорректный XML файл.\nВведите еще раз.");
                }
            }
        }

        public ICommand ParcingFile { get; }
        private bool CanParcingFileExecute (object p)
        {
            return File.Exists("myfile.xml");
        }

        private void OnParcingFileExecute(object p)
        {
            var xmlFile = new XmlDocument();
            TreeElements = new ObservableCollection<TreeElement>();
            xmlFile.Load("myfile.xml");
            var treeElement = new TreeElement();
            treeElement.AddTreeElementFromXml(xmlFile.DocumentElement);
            TreeElements.Add(treeElement);
            File.Delete("myfile.xml");
        }

        public ViewModel()
        {
            LoadXmlFile = new LambdaCommand(OnLoadXmlFileExecute, CanLoadXmlFileExecute);
            ParcingFile = new LambdaCommand(OnParcingFileExecute, CanParcingFileExecute);
        }
    }
}
