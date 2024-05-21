using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTableTest.Common
{
    public class Command : ICommand
    {
        private readonly Action<object> mAction;
        private readonly bool mCanExecute;

        public Command(Action<object> action, bool canExecute)
        {
            mAction = action;
            mCanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return mCanExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            mAction(parameter);
        }
    }
}
