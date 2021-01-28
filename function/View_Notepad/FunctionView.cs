using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using YuristNotepad.Common;

namespace View_Notepad
{
    public class FunctionView
    {
        private List<Button> _buttons;
        public FunctionView()
        {
            _buttons = ct.CreateButtons(AllMenu());
            
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
        private void SetEvent() 
        {
        
        }

        public List<Button> GetLabels()
        {
            return _buttons;
        }
    }
}
