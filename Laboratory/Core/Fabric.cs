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
        public static string GetSelect(string type)
        {
            string SelectCommand = "";
            switch (type)
            {
                case "Laboratory.Tables.Roles":
                    SelectCommand = Roles.GetSelect();
                    break;
            }
            return SelectCommand;
        }
        public static string GetCurrentId(string type)
        {
            string SelectCommand = "";
            switch (type)
            {
                case "Laboratory.Tables.Roles":
                    SelectCommand = Roles.GetCurrentId();
                    break;
            }
            return SelectCommand;
        }
        public static Func<SqlDataReader, ITableElement> GetObject(string type)
        {
            Func<SqlDataReader, ITableElement> action = null;
            switch (type)
            {
                case "Laboratory.Tables.Roles":
                    action = Roles.GetObject;
                    break;
            }
            return action;
        }
    }
}
