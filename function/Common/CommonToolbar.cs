using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace YuristNotepad.Common
{
    public class CommonToolbar
    {
        public List<Button> CreateButtons(params string[] names)
        {
            List<Button> buttons = new List<Button>();
            foreach (var item in names)
            {
                buttons.Add(CreateButton(item));
            }

            return buttons;

        }
        public Button CreateButton(string name)
        {
            Button btn = new Button();
            btn.Content = name;
            

            return btn;

        }
    }
}
