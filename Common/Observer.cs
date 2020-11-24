using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.YuristNodepad
{
    public class Observer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler _handler = PropertyChanged;
            if (_handler != null)
                _handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
