using Common.YuristNodepad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace YuristNodepad.ViewModel
{
    public class MainViewModel : Observer
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
        private string richCursorLine;
        private string richCursorCol;
        private string richZoom;
        private string richEncoding;
        private RichTextBox rtb;

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
        public string RichCursorLine
        {
            get
            {
                return richCursorLine;
            }
            set
            {
                richCursorLine = value;
                OnPropertyChanged("RichCursorLine");
            }
        }
        public string RichCursorCol
        {
            get
            {
                return richCursorCol;
            }
            set
            {
                richCursorCol = value;
                OnPropertyChanged("RichCursorCol");
            }
        }
        public string RichZoom
        {
            get
            {
                return richZoom;
            }
            set
            {
                richZoom = value;
                OnPropertyChanged("RichZoom");
            }
        }
        public string RichEncoding
        {
            get
            {
                return richEncoding;
            }
            set
            {
                richEncoding = value;
                OnPropertyChanged("RichEncoding");
            }
        }

    }
}
