using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using YuristNotepad.Common;

namespace Edit_Notepad
{
    public class FunctionEdit
    {
        public FunctionEdit() 
        {
            ct.CreateLabels(AllMenu());
        }
         CommonToolbar ct = new CommonToolbar();
        //ct.CreateLabels(Constants.MENU.CREATE);
        
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

        public List<Label> GetLabels()
        {
            return ct.CreateLabels(AllMenu());
        }
    }
}
