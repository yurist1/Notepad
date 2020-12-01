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

namespace YuristNodepad.UcItems
{
    /// <summary>
    /// UcToolbarItem.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UcToolbarItem : UserControl
    {
        private bool isOpen = false;
        public UcToolbarItem()
        {
            InitializeComponent();

            lbMenu.MouseLeftButtonUp += LbMenu_MouseLeftButtonUp;
            if (isOpen)
            {
                lbMenuList.Visibility = Visibility.Visible;
            }
            else 
            {
                lbMenuList.Visibility = Visibility.Hidden;
            }
        }

        private void LbMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isOpen = !isOpen;
            
        }
    }
}
