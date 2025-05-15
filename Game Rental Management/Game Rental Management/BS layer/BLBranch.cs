using Game_Rental_Management.DB_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rental_Management.BS_layer
{
    class BLBranch
    {
        DBMain db = null;

        public BLBranch()
        {
            db = new DBMain();
        }

        // Lấy tất cả chi nhánh
        public DataSet LayBranch()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Branch", CommandType.Text);
        }

        // Thêm chi nhánh mới
        public bool ThemBranch(string branchName, string address, string phone, ref string err)
        {
            string sqlString = "INSERT INTO Branch (BranchName, Address, Phone) VALUES (N'" +
                branchName + "', N'" +
                address + "', '" +
                phone + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        // Xóa chi nhánh theo BranchID
        public bool XoaBranch(ref string err, int branchID)
        {
            string sqlString = "DELETE FROM Branch WHERE BranchID = " + branchID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        // Cập nhật thông tin chi nhánh theo BranchID
        public bool CapNhatBranch(int branchID, string branchName, string address, string phone, ref string err)
        {
            string sqlString = "UPDATE Branch SET " +
                "BranchName = N'" + branchName + "', " +
                "Address = N'" + address + "', " +
                "Phone = '" + phone + "' " +
                "WHERE BranchID = " + branchID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
