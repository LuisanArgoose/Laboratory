using Laboratory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory.Tables
{
    public abstract class TableElement : BindableBase, ITableElement
    {
        public string Delete()
        {
            return ""; //Delete command
        }

        public string Insert(int index)
        {
            return ""; //InsertCommand
        }

        public string Update()
        {
            return ""; //UpdateCommand
        }
    }
}
