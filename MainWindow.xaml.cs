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
        private List<ToolbarMenu> toolbarText;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MainViewModel.GetInstance();
            //tetete.ItemsSource = new List<string> { "1", "2", "3", "4" };
            //tetete.Header = "파일";

            SetToolbarMenu();

            foreach (var item in toolbarText)
            {
                MenuItem menu = new MenuItem();
                menu.Header = item.Header;
                menu.ItemsSource = item.Menu;
                ToolbarMenu.Items.Add(menu);
            }
         
          
        }
        private void SetToolbarMenu() 
        {
            toolbarText = new List<ToolbarMenu>();
            toolbarText.Add(new ToolbarMenu("파일",new List<string>() { "새로 만들기","새 창", "열기", "저장", "다른 이름으로 저장", "페이지 설정", "인쇄", "끝내기"}));
            toolbarText.Add(new ToolbarMenu("편집",new List<string>() { "실행 취소","잘라내기", "복사", "붙여놓기", "삭제", "찾기"}));
            toolbarText.Add(new ToolbarMenu("보기",new List<string>() { "확대하기/축소하기","상태 표시줄"}));
            toolbarText.Add(new ToolbarMenu("도움말",new List<string>() { "메모장 정보"}));
        }
    }
}
