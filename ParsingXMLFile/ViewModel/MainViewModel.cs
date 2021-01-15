using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;

namespace ParsingXMLFile.ViewModel
{
    abstract class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyNamy = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyNamy));
        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string Property = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(Property);
            return true;
        }
    }

}
