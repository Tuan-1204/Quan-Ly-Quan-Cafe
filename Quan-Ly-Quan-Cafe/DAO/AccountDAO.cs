using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_Cafe.DAO
{
    public class AccountDAO
    {
        // chuyển đổi sang kiến trúc singleton
        private static AccountDAO instance; // biến instance chứa đối tượng DataProvider

        public static AccountDAO Instance 
        { 
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
            private set { instance = value; } // chỉ cho phép set trong class
        }

        private AccountDAO() { } // hạn chế việc khởi tạo đối tượng từ bên ngoài class
        //hàm đăng nhập
        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord";
            object[] parameters = new object[] { userName, passWord };
            DataTable result = DataProvider.Instance.ExecuteQuery(query, parameters);
            return result.Rows.Count > 0;
        }
    }
}
