using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace Shared.ViewModels
{
    public class DirectoryTabItemViewModel : BaseViewModel
    {
        #region Fields
        public string FilePath { get; set; }
        public string Name { get; set; }
        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } = new ObservableCollection<FileEntityViewModel>();
        public FileEntityViewModel SelectedFileEntity { get; set; }


        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } = new ObservableCollection<DirectoryTabItemViewModel>();
        public DirectoryTabItemViewModel CurrentDirectoryItem { get; set; }
        #endregion


        #region Command
        public ICommand OpenCommand { get; }
        public ICommand CloseCommand { get; }
        #endregion



        #region constructor
        public DirectoryTabItemViewModel()
        {
            OpenCommand = new DelegateCommand(Open);
            CloseCommand = new DelegateCommand(OnClose);
            Name = "My machine";

            foreach (var logicalDrive in Directory.GetLogicalDrives())
                DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
        }
        #endregion


        #region Events
        public event EventHandler Closed;
        #endregion

        #region Commandmethods
        private void Open(object parameter)
        {
            if (parameter is DirectoryViewModel directoryViewModel)
            {
                FilePath = directoryViewModel.FullName;
                Name = directoryViewModel.FullName;

                DirectoriesAndFiles.Clear();

                var directoryinfo = new DirectoryInfo(FilePath);

                foreach (var directoryItem in directoryinfo.GetDirectories())
                    DirectoriesAndFiles.Add(new DirectoryViewModel(directoryItem));

                foreach (var fileItem in directoryinfo.GetFiles())
                    DirectoriesAndFiles.Add(new FileViewModel(fileItem));
            }
        }

        private void OnClose(object obj)
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}