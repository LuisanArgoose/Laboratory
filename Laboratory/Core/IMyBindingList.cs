using Laboratory.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory.Core
{
    public interface IMyBindingList : IBindingList
    {
        string GetDeletedItem();
        void Reload();
    }
}
