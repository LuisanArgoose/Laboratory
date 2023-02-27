using Laboratory.Core;
using Laboratory.Tables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laboratory.Model
{
    public class DataBase : BindableBase
    {
        private static string _connectionString;
        public static string GetConnectionString()
        {
            return _connectionString;
        }
        private string _commandStack;
        public DataBase( string connectionString) 
        {
            _commandStack = "";
            _connectionString = connectionString;

            Init();
            //ReloadDataBase();

        }
        private void Init()
        {
            SetProperty(ref _roles, new MyBindingList<Roles>());
        }
        
        public void Reload()
        {
            _roles.Reload();

        }
        public void SaveChanges()
        {

        }
        private MyBindingList<Roles> _roles;
        public MyBindingList<Roles> GetRoles() 
        { 
            return _roles; 
        }

    }
}
