using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string DiskName { get; set; }


        public MainViewModel()
        {
            DiskName = Environment.SystemDirectory;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
