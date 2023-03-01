using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Laboratory.Core;
using Laboratory.Model;

namespace Laboratory.Tables
{
    public class Roles : TableElement
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        private byte[] _image;
        public byte[] Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }
        private bool _isDeleted;
        public bool IsDeleted
        {
            get => _isDeleted;
            set => SetProperty(ref _isDeleted, value);
        }
        public Roles() {
            Name = "";
            Image = null;
            IsDeleted= false;
        }
        static public Roles GetObject(int id)
        {
            using (SqlConnection connection = new SqlConnection(DataBase.GetConnectionString()))
            {
                string selectSingleCommand = GetSelect() + " Where Id =" + id;
                SqlCommand sqlCommand = new SqlCommand(selectSingleCommand, connection);
                connection.Open();
                try
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        return GetObject(reader);
                    }
                    reader.Close();
                }
                catch { }
                connection.Close();
                return null;
            }
        }

        static public string GetSelect()
        {
            string querry = "Select * from Roles";
            return querry;
        }
        static public Roles GetObject(SqlDataReader obj)
        {
            Roles one  = new Roles();
            try
            {
                one = new Roles()
                {
                    Id = int.Parse(obj["Id"].ToString()),
                    Name = obj["Name"].ToString(),
                    //Image = obj["Image"].ToString(),
                    IsDeleted = bool.Parse(obj["IsDeleted"].ToString())
                };
            }
            catch { }
            return one;
        }
        static public string GetCurrentId()
        {
            string querry = "select IDENT_CURRENT('Roles')";
            return querry;
        }

        public new string Insert(int index)
        {
            Id = index;
            string img;
            if (Image == null)
            {
                img = "null";
            }
            else
            {
                img = Image.ToString();
            }
            
            return string.Format("Insert into Roles values ('{0}',{1},{2});",Name, img, IsDeleted?1:0);
        }

        public new string Delete()
        {
            string temp = string.Format("delete from Roles where Id = {0};", Id);
            return temp;
        }

        public new string Update()
        {
            string img;
            if (Image == null)
            {
                img = "null";
            }
            else
            {
                img = Image.ToString();
            }
            return string.Format("Update Roles set Name = '{0}', Image ={1},IsDeleted = {2} where Id = {3};", Name, img, IsDeleted ? 1 : 0, Id);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
