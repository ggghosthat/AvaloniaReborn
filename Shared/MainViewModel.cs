using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

namespace Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields
        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } = new ObservableCollection<DirectoryTabItemViewModel>();
        public DirectoryTabItemViewModel CurrentDirectoryItem { get; set; }
        #endregion

        #region Commands
        public ICommand AddTabItemCommand { get; }
        #endregion

        #region constructor
        public MainViewModel()
        {
            AddTabItemCommand = new DelegateCommand(AddTabItem);

            AddTabItemViewModel();

            CurrentDirectoryItem = DirectoryTabItems.FirstOrDefault();
        }

        
        #endregion

        #region methods
        private void AddTabItem(object obj)
        {
            AddTabItemViewModel();
        }
        private void AddTabItemViewModel()
        {
            var tabVM = new DirectoryTabItemViewModel();

            tabVM.Closed += TabVM_Closed;

            DirectoryTabItems.Add(tabVM);

            CurrentDirectoryItem = tabVM;
        }

        private void TabVM_Closed(object sender, EventArgs e)
        {
            if (sender is DirectoryTabItemViewModel directoryTabItem)
                CollapseTabViewModel(directoryTabItem);
        }

        private void CollapseTabViewModel(DirectoryTabItemViewModel directoryTabItem)
        {
            var index = DirectoryTabItems.IndexOf(directoryTabItem);
            directoryTabItem.Closed -= TabVM_Closed;

            DirectoryTabItems.Remove(directoryTabItem);

            if (index > 0)
                CurrentDirectoryItem = DirectoryTabItems[index - 1];
            
        }

        public void AppClosing()
        {

        }
        #endregion
    }
}
