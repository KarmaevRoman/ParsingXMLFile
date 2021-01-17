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
    class MainViewModel : BaisViewModel
    {
        private string _link;

        private ObservableCollection<TreeElement> _treeElements;

        public string Link
        {
            get => _link;
            set => Set(ref _link, value);
        }        

        public ObservableCollection<TreeElement> TreeElements
        {
            get => _treeElements;
            set => Set(ref _treeElements, value);
        }

        public ICommand LoadXmlFile { get; }

        public MainViewModel()
        {
            LoadXmlFile = new LambdaCommand(OnLoadXmlFileExecute, CanLoadXmlFileExecute);
            ParcingFile = new LambdaCommand(OnParcingFileExecute, CanParcingFileExecute);
            TreeElements = new ObservableCollection<TreeElement>();
        }

        public ICommand ParcingFile { get; }

        private bool CanLoadXmlFileExecute(object p) => true;

        private void OnLoadXmlFileExecute(object p)
        {
            var xmlFile = new XmlDocument();
            if (Link == null)
                MessageBox.Show("Ссылка отсутствует.");
            else
            {
                TryLoadXmlFile(xmlFile);
            }
        }
        
        private bool CanParcingFileExecute (object p)
        {
            return File.Exists("temp_file.xml");
        }

        private void OnParcingFileExecute(object p)
        {
            var xmlFile = new XmlDocument();            
            xmlFile.Load("temp_file.xml");
            var treeElement = new TreeElement();
            treeElement.AddTreeElementFromXml(xmlFile.DocumentElement);
            TreeElements.Add(treeElement);
            File.Delete("temp_file.xml");
        }        

        private void TryLoadXmlFile(XmlDocument xmlFile)
        {
            try
            {
                xmlFile.Load(Link);
                xmlFile.Save("temp_file.xml");
                MessageBox.Show("Файл успешно загружен.");
            }

            catch (Exception)
            {
                MessageBox.Show("Неверная ссылка или некорректный XML файл.\nВведите еще раз.");
            }
        }         
    }
}
