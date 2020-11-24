using Common.YuristNodepad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuristNodepad.ViewModel
{
    public class MainViewModel:Observer
    {
        private static MainViewModel _mainViewModel;
        public static MainViewModel GetInstance() 
        {
            if (_mainViewModel == null) 
            {
                _mainViewModel = new MainViewModel();
            }
            return _mainViewModel;
        }

        private string richFullText;

        public string RichFullText 
        {
            get 
            {
                return richFullText;
            }
            set 
            {
                richFullText = value;
                OnPropertyChanged("RichFullText");
            }
        }

        
    }
}
