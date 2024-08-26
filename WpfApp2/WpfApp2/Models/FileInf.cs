using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfApp2
{
    public class FileInf : TreeItem
    {
        public FileInf(string file) 
        {
            if (File.Exists(file))
            {
                FilePath = file;

                string fileName = Path.GetFileNameWithoutExtension(file);
                Name = !string.IsNullOrEmpty(fileName) ? fileName : file;
            }
        }
        public string FilePath { get; set; } = string.Empty;

        public override string GetDescription()
        {
            return FilePath;
        }
    }
}
