using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Laboratory.Core
{
    internal class SingInCommand : ICommand
    {
        private string _login;
        private Action<string, string> _execute;
        public SingInCommand(string login, Action<string, string> execute)
        {
            this._execute = execute;
            this._login = login;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(_login,(parameter as PasswordBox).Password);
        }
    }
}
