using Laboratory.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory.Core
{
    public class Fabric
    {
        private static string _selectCommand;
        private static string _getCurrentIdCommand;
        private static Func<SqlDataReader, ITableElement> _getObject;
        private static void Switch(string type)
        {
            switch (type)
            {
                case "Laboratory.Tables.Roles":
                    _selectCommand = Roles.GetSelect();
                    _getCurrentIdCommand = Roles.GetCurrentId();
                    _getObject = Roles.GetObject;
                    break;
            }
        }
        public static string GetSelect(string type)
        {
            Switch(type);
            return _selectCommand;
        }
        
        public static string GetCurrentId(string type)
        {
            Switch(type);
            return _getCurrentIdCommand;
        }
        public static Func<SqlDataReader, ITableElement> GetObject(string type)
        {
            Switch(type);
            return _getObject;
        }
    }
}
