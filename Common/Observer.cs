using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.YuristNodepad
{
    public class Observer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler _handler = PropertyChanged;
            if (_handler != null)
                _handler.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
