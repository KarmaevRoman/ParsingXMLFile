using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ParsingXMLFile.ViewModel.Base
{
    abstract class BaisViewModel : INotifyPropertyChanged
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
