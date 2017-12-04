using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTradeFX.Models {
    using System;
    using System.Windows.Input;
    public class DelegateCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public DelegateCommand(Action<object> execute) : this(execute, null) {
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public static void RaiseCanExecuteChanged() {
            CommandManager.InvalidateRequerySuggested();
        }

        #region ICommand member
        public bool CanExecute(object parameter) {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event System.EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        public void Execute(object parameter) {
            if (_execute != null) _execute(parameter);
        }
        #endregion ICommand member
    }
}
