using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Folder : TreeItem
    {
        public Folder(string folder)
        {
            if (Directory.Exists(folder))
            {
                FolderPath = folder;
                
                string fileName = Path.GetFileName(folder);
                Name = !string.IsNullOrEmpty(fileName) ? fileName : folder;
            }
        }
        public string FolderPath {  get; set; } = string.Empty;

        public override string GetDescription()
        {
            return FolderPath;
        }
    }
}
