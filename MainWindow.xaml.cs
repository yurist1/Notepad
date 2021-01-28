using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YuristNodepad.Model;
using YuristNodepad.ViewModel;

namespace YuristNodepad
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MainViewModel.GetInstance(this);
            //tetete.ItemsSource = new List<string> { "1", "2", "3", "4" };
            //tetete.Header = "파일";


       
         
          
        }
        
    }
}
