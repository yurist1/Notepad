using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuristNodepad.Model
{
    public class ToolbarMenu
    {
        public string Header { get; set; }
        public List<string> Menu { get; set; }
        public ToolbarMenu(string header, List<string> menu) 
        {
            Header = header;
            Menu = menu;
        }
    }
}
