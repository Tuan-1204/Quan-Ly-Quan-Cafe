using Quan_Ly_Quan_Cafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_Cafe.DAO
{
    public class TableDAO
    {
        // sigleton
        private static TableDAO instance;
        // hàm khởi tạo
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        // kích thước bàn
        public static int TableWidth = 80;
        public static int TableHeight = 80;
        // hạn chế khởi tạo đối tượng từ bên ngoài class
        private TableDAO() { }

        //hỗ trợ load bàn
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery(" EXEC USP_GetTableList");
            // dùng foreach để duyệt qua từng dòng dữ liệu trong DataTable
            //danh sách bàn
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }
    }
}
