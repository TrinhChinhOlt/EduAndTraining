using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class TreeItem
    {
        public TreeItem()
        {
            Children = [];
            Name = string.Empty;
        }

        public string Name { get; set; }
        public List<TreeItem> Children { get; set; }

        public virtual string GetDescription()
        {
            return string.Empty;
        }
    }
}
