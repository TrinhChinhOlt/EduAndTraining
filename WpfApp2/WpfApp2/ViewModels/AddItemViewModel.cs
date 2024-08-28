using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMCore;
using WpfApp2.Views.Dialogs;

namespace WpfApp2.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        public AddItemViewModel()
        {
            Name = "new Name";
            Description = string.Empty;

            OkDialogCmd = new RelayCommand(OkDialogCmdInvoke);
            CancelDialogCmd = new RelayCommand(CancelDialogCmdInvoke);

            ParentDlg = null;
        }

        public RelayCommand OkDialogCmd {  get; set; }
        public RelayCommand CancelDialogCmd { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public object? ParentDlg { get; set; }

        private void CancelDialogCmdInvoke(object obj)
        {
            if (ParentDlg is AddItem addItemDlg)
            {
                addItemDlg.Close();
            }
        }

        private void OkDialogCmdInvoke(object obj)
        {
            if (ParentDlg is AddItem addItemDlg)
            {
                addItemDlg.Close();
            }
        }

    }
}
