using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laboratory.Core
{
    public class DelegateCommand :ICommand
    {
        Action execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action execute)
        {
            this.execute = execute;
        }

        // Методы, необходимые для ICommand
        public void Execute(object param)
        {
            execute();
        }

        public bool CanExecute(object param)
        {
            return true;
        }

    }
}
