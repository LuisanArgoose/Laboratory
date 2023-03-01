using Laboratory.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory.Tables
{
    public class Users : TableElement
    {
        private int _id;
        public int Id 
        { get => _id; set => SetProperty(ref _id, value); }
        private string _login;
        public string Login 
        {
            get => _login; 
            set => SetProperty(ref _login, value); 
        }
        private string _password;
        public string Password 
        { 
            get => _password; 
            set => SetProperty(ref _password, value); 
        }
        private Roles _roles;
        public Roles Roles
        { 
            get => _roles; 
            set => SetProperty(ref _roles, value); 
        }
        private int? _isWorkerId;
        public int? IsWorkerId
        {
            get => _isWorkerId;
            set => SetProperty(ref _isWorkerId, value);
        }
        private int? _isPatientId;
        public int? IsPatientId
        {
            get => _isPatientId;
            set => SetProperty(ref _isPatientId, value);
        }
        private bool _isDeleted;
        public bool IsDeleted
        {
            get => _isDeleted;
            set => SetProperty(ref _isDeleted, value);
        }
        public Users()
        {
            Login = "";
            Password = "";
            Roles = null;
            IsWorkerId = null;
            IsPatientId = null;
            IsDeleted = false;

        }

        static public string GetSelect()
        {
            string querry = "Select * from Users";
            return querry;
        }
        static public Users GetObject(SqlDataReader obj)
        {
            Users one = new Users();
            try
            {
                one = new Users()
                {
                    Id = int.Parse(obj["Id"].ToString()),
                    Login = obj["Login"].ToString(),
                    Password = obj["Password"].ToString(),
                    //,
                    IsDeleted = bool.Parse(obj["IsDeleted"].ToString())
                };
                one.Roles = Roles.GetObject(int.Parse(obj["RoleId"].ToString()));
                bool res = int.TryParse(obj["IsWorkerId"].ToString(), out int id);
                if (res)
                    one.IsWorkerId = id;
                res = int.TryParse(obj["IsPatientId"].ToString(), out id);
                if (res)
                    one.IsPatientId = id;


            }
            catch(Exception e)
            { 

            }
            return one;
        }
        static public string GetCurrentId()
        {
            
            string querry = "select IDENT_CURRENT('Users')"; 
            return querry;
        }

    }
}
