using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParsingXMLFile.ViewModel
{
    internal abstract class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        abstract public bool CanExecute(object parameter);

        abstract public void Execute(object parameter);
    }
}
