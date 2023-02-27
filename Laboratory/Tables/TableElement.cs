using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory.Tables
{
    public interface ITableElement
    {
        string Insert(int index);
        string Delete();
        string Update();
    }
}
