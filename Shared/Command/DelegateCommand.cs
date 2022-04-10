using System;
using System.Windows.Input;

namespace Shared.ViewModels
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<object> _open;
        private readonly Predicate<object> _canExecute;

        public DelegateCommand(Action<object> open, Predicate<object> canExecute = null)
        {
            _open = open;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute.Invoke(parameter);

        public void Execute(object parameter)
        {
            _open?.Invoke(parameter);
        }

        public void RaiseCanExecute() 
        {
            CanExecuteChanged.Invoke(this, EventArgs.Empty);
        }
    }
}