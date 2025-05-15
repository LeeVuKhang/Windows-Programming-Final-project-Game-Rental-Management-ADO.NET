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

        public DataSet LayCustomer()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Customer", CommandType.Text);
        }

        public bool ThemCustomer(string name, string phone, string email, string address, ref string err)
        {
            string sqlString = "INSERT INTO Customer (Name, Phone, Email, Address) VALUES (N'" +
                name + "', '" + phone + "', '" + email + "', N'" + address + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaCustomer(ref string err, int customerID)
        {
            string sqlString = "DELETE FROM Customer WHERE CustomerID = " + customerID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatCustomer(int customerID, string name, string phone, string email, string address, ref string err)
        {
            string sqlString = "UPDATE Customer SET " +
                "Name = N'" + name + "', " +
                "Phone = '" + phone + "', " +
                "Email = '" + email + "', " +
                "Address = N'" + address + "' " +
                "WHERE CustomerID = " + customerID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
