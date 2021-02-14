using Common.YuristNodepad;
using Edit_Notepad;
using File_Notepad;
using Help_Notepad;
using System;
using System.Collections.Generic;
using System.IO;
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
            //RichTextBoxData = new FlowDocument();

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
        private FlowDocument rtb;

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
        public FlowDocument RichTextBoxData
        {
            get
            { 
                return rtb;
            }
            set
            {
                rtb = value;
                OnPropertyChanged("RichTextBoxData");
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
        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
     
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

    public class RichTextHelper : DependencyObject
    {
        public static string GetDocumentXaml(DependencyObject obj)
        {
            return (string)obj.GetValue(DocumentXamlProperty);
            //return "안녕";
        }

        public static void SetDocumentXaml(DependencyObject obj, string value)
        {
            obj.SetValue(DocumentXamlProperty, value);
        }





        public static readonly DependencyProperty DocumentXamlProperty =
            DependencyProperty.RegisterAttached(
                "TestXaml",
                typeof(string),
                typeof(RichTextBoxHelper),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextChangePropertyChanged)));



        private static void OnTextChangePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)

        {

            var richTextBox = (RichTextBox)d;

            // Parse the XAML to a document (or use XamlReader.Parse())
            var xaml = GetDocumentXaml(richTextBox);
            var doc = new FlowDocument();
            var range = new TextRange(doc.ContentStart, doc.ContentEnd);

            //range.Load(new MemoryStream(Encoding.UTF8.GetBytes(xaml)),
            //           DataFormats.Xaml); 
            range.Load(new MemoryStream(Encoding.UTF8.GetBytes(xaml)),
                       DataFormats.Text);



            // Set the document
            richTextBox.Document = doc;

            // When the document changes update the source
            range.Changed += (obj2, e2) =>
            {
                if (richTextBox.Document == doc)
                {
                    MemoryStream buffer = new MemoryStream();
                    //range.Save(buffer, DataFormats.Xaml);
                    range.Save(buffer, DataFormats.Text);
                    SetDocumentXaml(richTextBox,
                        Encoding.UTF8.GetString(buffer.ToArray()));
                }
            };


        }
    }
}
