using Shared.History;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace Shared.ViewModels
{
    public class DirectoryTabItemViewModel : BaseViewModel
    {
        #region Private Fields
        private readonly IDirectoryHistory directoryHistory;
        #endregion

        #region Public Fields
        public string FilePath { get; set; }
        public string Name { get; set; }
        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } = new ObservableCollection<FileEntityViewModel>();
        public FileEntityViewModel SelectedFileEntity { get; set; }


        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } = new ObservableCollection<DirectoryTabItemViewModel>();
        public DirectoryTabItemViewModel CurrentDirectoryItem { get; set; }
        #endregion

        #region Command
        public DelegateCommand OpenCommand { get; }
        public DelegateCommand MoveBackCommand { get; }
        public DelegateCommand MoveForwardCommand { get; }
        public DelegateCommand RefreshCommand { get; }
        #endregion

        #region constructor
        public DirectoryTabItemViewModel()
        {
            directoryHistory = new DirectoryHistory("My machine", "My machine");

            OpenCommand = new DelegateCommand(Open);
            MoveBackCommand = new DelegateCommand(OnMoveBack, OnCanMoveBack);
            MoveForwardCommand = new DelegateCommand(OnMoveForward, OnCanMoveForward);


            Name = directoryHistory.Current.DirectoryPathName;
            FilePath = directoryHistory.Current.DirectoryPath;

            OpenDirectory();


            directoryHistory.HistoryChanged += HistoryChanged;
        }

        
        #endregion

        #region Methods
        private void OpenDirectory()
        {
            DirectoriesAndFiles.Clear();

            if (Name == "My machine")
            {
                foreach (var logicalDrive in Directory.GetLogicalDrives())
                    DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));

                return;
            }

            var directoryinfo = new DirectoryInfo(FilePath);

            foreach (var directoryItem in directoryinfo.GetDirectories())
                DirectoriesAndFiles.Add(new DirectoryViewModel(directoryItem));

            foreach (var fileItem in directoryinfo.GetFiles())
                DirectoriesAndFiles.Add(new FileViewModel(fileItem));
        }

        private void HistoryChanged(object sender, EventArgs e)
        {
            MoveBackCommand?.RaiseCanExecute();
            MoveForwardCommand?.RaiseCanExecute();
        }
        #endregion

        #region Commandmethods
        private void Open(object parameter)
        {
            if (parameter is DirectoryViewModel directoryViewModel)
            {
                FilePath = directoryViewModel.FullName;
                Name = directoryViewModel.FullName;

                directoryHistory.Add(FilePath, Name);

                OpenDirectory();
            }
        }

        private bool OnCanMoveBack(object obj)
        {
            return directoryHistory.CanMoveBack;
        }
        private void OnMoveBack(object obj)
        {
            directoryHistory.MoveBack();

            var current = directoryHistory.Current;

            FilePath = current.DirectoryPath;
            Name = current.DirectoryPathName;

            OpenDirectory();
        }


        private bool OnCanMoveForward(object obj)
        {
            return directoryHistory.CanMoveForward;
        }
        private void OnMoveForward(object obj)
        {
            directoryHistory.MoveForward();

            var current = directoryHistory.Current;

            FilePath = current.DirectoryPath;
            Name = current.DirectoryPathName;

            OpenDirectory();
        }

        #endregion
    }
}