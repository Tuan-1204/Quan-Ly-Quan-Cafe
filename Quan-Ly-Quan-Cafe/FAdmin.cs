using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Quan_Ly_Quan_Cafe.DAO;

namespace Quan_Ly_Quan_Cafe
{
    public partial class FAdmin : Form
    {
        public FAdmin()
        {
            InitializeComponent();
            LoadAccountList(); // Gọi hàm load danh sách tài khoản khi form khởi tạo
        }

        // Hàm lấy danh sách tài khoản và hiển thị lên DataGridView
        void LoadAccountList()
        {
            // Tạo câu truy vấn sử dụng stored procedure, có tham số @userName
            string query = "Exec USP_GetAccountByUserName  @userName"; // sử dụng stored procedure để truy vấn

            // Khởi tạo đối tượng DataProvider để thao tác với database
            DataProvider provider = new DataProvider();

            // Gọi hàm ExecuteQuery truyền vào câu truy vấn và mảng tham số (ở đây là "Admin")
            // Kết quả trả về là một DataTable, gán vào DataSource của DataGridView để hiển thị
            dtgvAccount.DataSource = provider.ExecuteQuery(query, new object[] { "Admin" });
        }
    }
}
