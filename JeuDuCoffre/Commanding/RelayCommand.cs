using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace JeuDuCoffre.Commanding
{
    public class RelayCommand : ICommand
    {
        private Action _execute;
        private Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute is not null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute is not null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException();
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return (_canExecute is null) ? true : _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
