using Laboratory.Core;
using Laboratory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Laboratory.ViewModel
{
    public class SingUpVM :BindableBase
    {
        public SingUpVM() 
        {
            
            MainModel.GetDataBase().PropertyChanged += (s, a) => { RaisePropertyChanged(nameof(Errors)); };
        }
        /*public ICollection Collection { get => MainModel.GetDataBase().GetUsers(); }
        public DelegateCommand ReloadCommand 
        { 
            get =>new DelegateCommand( MainModel.GetDataBase().GetUsers().Reload); 
        }
        public DelegateCommand SaveCommand
        {
            get => new DelegateCommand(MainModel.GetDataBase().GetUsers().SaveChanges);
        }*/
        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                string clean = string.Join("", value.Split(' ','.'));
                SetProperty(ref _login, clean);
                RaisePropertyChanged(nameof(SingInCommand));
            }
        }
        public ICommand SingInCommand
        {
            get
            {
                ICommand command = new SingInCommand(Login, MainModel.GetDataBase().SingIn);
                return command;
            }
        }
        public string Errors
        {
            get => MainModel.GetDataBase().SingInError();
        }



    }
}
