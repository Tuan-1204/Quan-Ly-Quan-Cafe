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
            LoadAccountList();
        }

       void LoadAccountList()
        {
            //Truy vấn dữ liệu 
            string query = "Exec USP_GetAccountByUserName  @userName"; // sử dụng stored procedure để truy vấn
            DataProvider provider = new DataProvider(); 
         dtgvAccount.DataSource = provider.ExecuteQuery(query, new object[] {"Admin"});
        }
    }
}
