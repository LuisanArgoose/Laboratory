using Laboratory.Model;
using Laboratory.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory.Core
{
    public class MyBindingList<T> :  BindingList<T>, IMyBindingList where T : ITableElement
    {
        private string _commandStack;
        private int _currentId;
        private bool _isReload;
        public MyBindingList(){
            Reload();
            ListChanged += IsListChanged;
        }
        protected override void RemoveItem(int index)
        {
            ITableElement one = this[index];
            _commandStack += one.Delete();
            base.RemoveItem(index);
        }
        protected override void InsertItem(int index, T item)
        {
            if (!_isReload) 
            {
                _commandStack += item.Insert(++_currentId);
            }           
            base.InsertItem(index,item);
        }

        public void Reload()
        {
            _isReload = true;
            Clear();
            using (SqlConnection connection = new SqlConnection(DataBase.GetConnectionString()))
            {
                string collectionType = this.GetType().GetGenericArguments().Single().ToString();
                string selectCommand = Fabric.GetSelect(collectionType);
                Func<SqlDataReader, ITableElement> GetObject = Fabric.GetObject(collectionType);
                SqlCommand sqlCommand = new SqlCommand(selectCommand, connection);
                connection.Open();
                try
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Add((T)GetObject(reader));
                    }
                    reader.Close();
                }
                catch { }
                selectCommand = Fabric.GetCurrentId(collectionType);
                sqlCommand = new SqlCommand(selectCommand, connection);
                try
                {
                    SqlDataReader reader2 = sqlCommand.ExecuteReader();
                    while (reader2.Read())
                    {
                        _currentId = (int)reader2.GetDecimal(0);
                    }
                    reader2.Close();
                }
                catch { }
                
                connection.Close();
            }
            _isReload=false;
            _commandStack = "";
        }
        private void IsListChanged(object sender, ListChangedEventArgs e)
        {
            ITableElement tableElement;

            switch (e.ListChangedType)
            {
                case ListChangedType.ItemChanged:
                    tableElement = (((IMyBindingList)sender)[e.NewIndex] as ITableElement);
                    _commandStack += tableElement.Update();
                    break;


            }

        }
        public void SaveChanges()
        {
            if (_commandStack == "")
                return;
            using (SqlConnection connection = new SqlConnection(DataBase.GetConnectionString()))
            {
                connection.Open();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(_commandStack, connection);
                    sqlCommand.ExecuteNonQuery();
                }
                catch( Exception e)
                {

                }
                connection.Close();
                _commandStack = "";
            }
        }
    }
}
