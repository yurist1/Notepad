using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace YuristNodepad.Model
{
    public class ToolbarMenu
    {
        public string Header { get; set; }
        public List<Label> Menu { get; set; }
        public ToolbarMenu(string header, List<Label> menu) 
        {
            Header = header;
            Menu = menu;
        }
    }
}
