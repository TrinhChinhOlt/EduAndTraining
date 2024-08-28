using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using MVVMCore;
using WpfApp2.ViewModels;
using WpfApp2.Views.Dialogs;

namespace WpfApp2
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ButtonChonThuMucCmd = new RelayCommand(ButtonChonThuMucCmdInvoke);
            TreeItems_ = [];
            SelectedTreeItem_ = new TreeItem();
            FolderName_ = string.Empty;
            IsTreeSelected_ = false;
            SelectedReportItem_ = new ReportItem();
            ReportItems_ = [];

            AddNodeCmd = new RelayCommand(AddNodeCmdInvoke);
            RemoveNodeCmd = new RelayCommand(RemoveNodeCmdInvoke);
        }

        public RelayCommand ButtonChonThuMucCmd { get; set; }
        public RelayCommand AddNodeCmd {  get; set; }
        public RelayCommand RemoveNodeCmd {  get; set; }

        private string FolderName_;
        public string FolderName
        {
            get => FolderName_;
            set
            {
                if (FolderName_ != value)
                {
                    FolderName_ = value;
                    RaisePropertyChanged("FolderName");
                }
            }
        }

        private bool IsTreeSelected_;
        public bool IsTreeSelected
        {
            get { return IsTreeSelected_; }
            set
            {
                if (IsTreeSelected_ != value)
                {
                    IsTreeSelected_ = value;
                }
            }
        }

        private bool IsExpanded_;
        public bool IsExpanded
        {
            get { return IsExpanded_; }
            set
            {
                if (IsExpanded_ != value)
                {
                    IsExpanded_ = value;
                }
            }
        }

        private List<TreeItem> TreeItems_;
        public List<TreeItem> TreeItems
        {
            get => TreeItems_;
            set
            {
                if (TreeItems_ != value)
                {
                    TreeItems_ = value;

                    RaisePropertyChanged("TreeItems");
                }
            }
        }

        private TreeItem SelectedTreeItem_;
        public TreeItem SelectedTreeItem
        {
            get => SelectedTreeItem_;
            set
            {
                if (SelectedTreeItem_ != value)
                {
                    SelectedTreeItem_ = value;

                    RaisePropertyChanged("SelectedTreeItem");
                    if (SelectedTreeItem != null)
                    {
                        ReportItems = TreeViewItemToReportList(SelectedTreeItem);
                    }
                }
            }
        }

        private List<ReportItem> ReportItems_;
        public List<ReportItem> ReportItems
        {
            get => ReportItems_;
            set
            {
                if (ReportItems_ != value)
                {
                    ReportItems_ = value;

                    RaisePropertyChanged("ReportItems");
                }
            }
        }

        private ReportItem SelectedReportItem_;
        public ReportItem SelectedReportItem
        {
            get => SelectedReportItem_;
            set
            {
                if (SelectedReportItem_ != value)
                {
                    SelectedReportItem_ = value;

                    RaisePropertyChanged("SelectedReportItem");
                }
            }
        }

        private void ButtonChonThuMucCmdInvoke(object obj)
        {
            var folderDialog = new OpenFolderDialog();

            if (folderDialog.ShowDialog() == true)
            {
                FolderName = folderDialog.FolderName;
                InitFolderTree(FolderName);
                // Do something with the result
            }
        }

        public void InitFolderTree(string folderName)
        {
            Folder folder = new Folder(folderName);
            InitFolderTree(folderName, folder);
            TreeItems = new List<TreeItem>() { folder };
        }

        public void InitFolderTree(string folderName, Folder folder)
        {
            string[] dirs = Directory.GetDirectories(folderName);
            foreach (string dir in dirs)
            {
                Folder subFolder = new Folder(dir);
                folder.Children.Add(subFolder);

                InitFolderTree(dir, subFolder);
            }

            string[] files = Directory.GetFiles(folderName);
            foreach(string file in files)
            {
                FileInf fileInf = new FileInf(file);
                folder.Children.Add(fileInf); 
            }
        }

        public List<ReportItem> TreeViewItemToReportList(TreeItem item)
        {
            List<ReportItem> reportItems = new List<ReportItem>()
            {
                new ReportItem()
                {
                    Name = item.Name,
                    Description = item.GetDescription(),
                },
            };

            return reportItems;
        }

        public static void RoutedPropertyChangedEventHandlerInvoke(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (sender is TreeView treeView &&
                treeView.DataContext is MainWindowViewModel windowViewModel &&
                treeView.SelectedItem is TreeItem treeItem)
            {
                windowViewModel.ReportItems = windowViewModel.TreeViewItemToReportList(treeItem);
            }
        }
        private void AddNodeCmdInvoke(object obj)
        {
            AddItemViewModel addItemViewModel = new AddItemViewModel();
            AddItem addItem = new()
            {
                DataContext = addItemViewModel,
            };

            addItemViewModel.ParentDlg = addItem;

            addItem.ShowDialog();
        }

        private void RemoveNodeCmdInvoke(object obj)
        {
            
        }

    }
}
