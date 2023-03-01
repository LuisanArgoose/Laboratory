using Laboratory.Core;
using Laboratory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laboratory.ViewModel
{
    public class SingUpVM :BindableBase
    {
        public SingUpVM() 
        {
            MainModel.GetDataBase().PropertyChanged += (s, a) => { RaisePropertyChanged(nameof(Collection)); };
        }
        public ICollection Collection { get => MainModel.GetDataBase().GetUsers(); }
        public DelegateCommand ReloadCommand 
        { 
            get =>new DelegateCommand( MainModel.GetDataBase().GetUsers().Reload); 
        }
        public DelegateCommand SaveCommand
        {
            get => new DelegateCommand(MainModel.GetDataBase().GetUsers().SaveChanges);
        }
    }
}
