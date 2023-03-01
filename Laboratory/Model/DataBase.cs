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
        public DataBase( string connectionString) 
        {
            _connectionString = connectionString;
            Init();

        }
        private void Init()
        {
            SetProperty(ref _roles, new MyBindingList<Roles>());
            SetProperty(ref _users, new MyBindingList<Users>());
        }
        
        public void Reload()
        {
            _roles.Reload();
            _users.Reload();

        }
        public void SaveChanges()
        {
            _roles.SaveChanges();
        }
        private MyBindingList<Roles> _roles;
        public MyBindingList<Roles> GetRoles() 
        { 
            return _roles; 
        }
        private MyBindingList<Users> _users;
        public MyBindingList<Users> GetUsers()
        {
            return _users;
        }

    }
}
