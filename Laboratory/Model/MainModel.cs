using Laboratory.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory.Model
{
    public class MainModel 
    {
        static private readonly DataBase _dataBase;
        static private readonly Views _views;
        static MainModel() 
        {
           _dataBase = new DataBase("Server=.\\SQLEXPRESS;Database=Luzan;Trusted_Connection=True;");
            _views = new Views();
        }
        static public DataBase GetDataBase()
        {
            return _dataBase;
        }
        static public Views GetViews()
        {
            return _views;
        }
    }
}
