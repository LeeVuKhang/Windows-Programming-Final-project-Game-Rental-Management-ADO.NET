using Game_Rental_Management.DB_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rental_Management.BS_layer
{
    class BLCustomer
    {
        DBMain db = null;

        public BLCustomer()
        {
            db = new DBMain();
        }

        public DataSet GetCustomers()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Customer", CommandType.Text);
        }

        public bool AddCustomer(string customerID, string name, string phone, string email, string address, ref string err)
        {
            string sqlString = "INSERT INTO Customer (CustomerID, Name, Phone, Email, Address) VALUES (" +
                "'" + customerID + "', N'" + name + "', N'" + phone + "', N'" + email + "', N'" + address + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool DeleteCustomer(ref string err, string customerID)
        {
            string sqlString = "DELETE FROM Customer WHERE CustomerID = '" + customerID + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool UpdateCustomer(string customerID, string name, string phone, string email, string address, ref string err)
        {
            string sqlString = "UPDATE Customer SET " +
                "Name = N'" + name + "', " +
                "Phone = N'" + phone + "', " +
                "Email = N'" + email + "', " +
                "Address = N'" + address + "' " +
                "WHERE CustomerID = '" + customerID + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }

}
