using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using YuristNotepad.Common;

namespace Edit_Notepad
{
    public class FunctionEdit
    {
        private List<Button> _buttons;
        private Window _window;
        public FunctionEdit() 
        {
            _buttons = ct.CreateButtons(AllMenu());
            SetEvent();
        }
         CommonToolbar ct = new CommonToolbar();
        
        private string[] AllMenu() 
        {
            //reflection으로 menu 다 담기
            var menu = new Constants.MENU();
            Type type = menu.GetType();
            FieldInfo[] name = type.GetFields();

            string[] result = new string[name.Length];
            for (int i = 0; i < name.Length; i++)
            {
                result[i] = name[i].GetValue(null).ToString();
            }

            return result;
        }

        public List<Button> GetLabels(Window window)
        {
            this._window = window;
            return _buttons;
        }

        private void SetEvent()
        {
            foreach (var item in _buttons)
            {
                item.Click += FunctionEdit_Click;
            }
        }
        private void FunctionEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content)
            {
                case "실행 취소":
                    Undo(_window);
                    break;
                case "잘라내기":
                    Cut(_window);
                    break;
                case "복사":
                    Copy(_window);
                    break;
                case "붙여놓기":
                    Paste(_window);
                    break;
                case "삭제":
                    Delete(_window);
                    break;
                case "찾기":
                    Find(_window);
                    break;
            }
        }
        private void Undo(object parm) 
        {
            dynamic mainViewModel = parm;
            //string tempMessage = mainViewModel.DataContext.RichFullText;
            //mainViewModel.Undo();

        }
        private void Cut(object parm) 
        {
            dynamic mainViewModel = parm;
            string tempMessage = mainViewModel.DataContext.RichSelectedText;
        }
        private void Copy(object parm)
        {
            dynamic mainViewModel = parm;
        }
        private void Paste(object parm)
        {
            dynamic mainViewModel = parm;
        }
        private void Delete(object parm)
        {
            dynamic mainViewModel = parm;
        }
        private void Find(object parm)
        {
            dynamic mainViewModel = parm;
        }
    }
}
