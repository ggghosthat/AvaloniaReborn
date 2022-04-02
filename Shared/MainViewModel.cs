using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public string FilePath { get; set; }
        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } = new ObservableCollection<FileEntityViewModel>();
        public FileEntityViewModel SelectedFileEntity { get; set; }



        #region Command
        public ICommand OpenCommand { get; }
        #endregion

        public MainViewModel()
        {
            OpenCommand = new DelegateCommand(Open);

            foreach(var logicalDrive in Directory.GetLogicalDrives())
                DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
        }


        private void Open(object parameter)
        {
            if(parameter is DirectoryViewModel directoryViewModel)
            {
                FilePath = directoryViewModel.FullName;

                DirectoriesAndFiles.Clear();

                var directoryinfo = new DirectoryInfo(FilePath);

                foreach (var directoryItem in directoryinfo.GetDirectories())
                    DirectoriesAndFiles.Add(new DirectoryViewModel(directoryItem));

                foreach (var fileItem in directoryinfo.GetFiles())
                    DirectoriesAndFiles.Add(new FileViewModel(fileItem));
            }
        }
    }
}
