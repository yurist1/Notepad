using Common.YuristNodepad;
using Edit_Notepad;
using File_Notepad;
using Help_Notepad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xml.Linq;
using Template_Notepad;
using View_Notepad;
using YuristNodepad.Model;

namespace YuristNodepad.ViewModel
{
    public class MainViewModel : Observer
    {
        private static MainViewModel _mainViewModel;
        private static Window _window;
        public MainViewModel() 
        {
            Init();
        }

        private List<MenuItem> menuItems;
        private void Init()
        {
            SetToolbar();

        }

        public static MainViewModel GetInstance(Window window)
        {
            if (_window == null) 
            {
                _window = window;
              
            
            }
            if (_mainViewModel == null)
            {
                _mainViewModel = new MainViewModel();
            }
            return _mainViewModel;
        }


        private string richFullText;
        private string richSeletedText;
        private string richCursorLine;
        private string richCursorCol;
        private string richZoom;
        private string richEncoding;
        private RichTextBox rtb;

        public List<MenuItem> ToolbarMenu
        {
            get
            {
                return menuItems;
            }
            set
            {
                menuItems = value;
                OnPropertyChanged("ToolbarMenu");
            }
        }

 
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
        public string RichSeletedText
        {
            get
            {
                return richSeletedText;
            }
            set
            {
                richSeletedText = value;
                OnPropertyChanged("RichSeletedText");
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
        public RichTextBox RichTextBox
        {
            get
            {
                return rtb;
            }
            set
            {
                rtb = value;
                OnPropertyChanged("RichTextBox");
            }
        }


        private void SetToolbar() 
        {
            menuItems = new List<MenuItem>();
            foreach (var item in SetToolbarMenu())
            {
                MenuItem menu = new MenuItem();
                menu.Header = item.Header;
                menu.ItemsSource = item.Menu;
                menuItems.Add(menu);
            }
        }
        private List<ToolbarMenu> SetToolbarMenu()
        {
            List<ToolbarMenu> toolbarText;
            toolbarText = new List<ToolbarMenu>();
            toolbarText.Add(new ToolbarMenu("파일", new FunctionFile().GetLabels(_window)));
            toolbarText.Add(new ToolbarMenu("편집", new FunctionEdit().GetLabels(_window)));
            toolbarText.Add(new ToolbarMenu("서식", new FunctionTemp().GetLabels()));
            toolbarText.Add(new ToolbarMenu("보기", new FunctionView().GetLabels()));
            toolbarText.Add(new ToolbarMenu("도움말", new FunctionHelp().GetLabels()));

            return toolbarText;
        }
        private List<Label> CreateLabels(params string[] names)
        {
            List<Label> labels = new List<Label>();
            foreach (var item in names)
            {
                labels.Add(CreateLabel(item));
            }
          
            return labels;

        }
        private Label CreateLabel(string name) 
        {
            Label lb = new Label();
            lb.Content = name;

            return lb;

        }
        public MainWindow CopyWindow() 
        {
            MainWindow ms = new MainWindow();
            SetToolbar();

            return ms;
        }
    }
}
