using System;
using System.Windows.Input;

namespace Shared.ViewModels
{
    internal class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<object> _open;


        public DelegateCommand(Action<object> open)
        {
            _open = open;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _open?.Invoke(parameter);
        }
    }
}