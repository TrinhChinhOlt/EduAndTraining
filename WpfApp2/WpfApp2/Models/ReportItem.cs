using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class ReportItem
    {
        public ReportItem()
        {
            Title = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            TooltipText = string.Empty;
        }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TooltipText { get; set; }
    }
}
