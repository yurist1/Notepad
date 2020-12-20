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
        public List<Label> CreateLabels(params string[] names)
        {
            List<Label> labels = new List<Label>();
            foreach (var item in names)
            {
                labels.Add(CreateLabel(item));
            }

            return labels;

        }
        public Label CreateLabel(string name)
        {
            Label lb = new Label();
            lb.Content = name;

            return lb;

        }
    }
}
