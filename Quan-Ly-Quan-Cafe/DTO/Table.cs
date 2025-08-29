using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Quan_Cafe.DTO
{
    public class Table
    {   
        //hàm dựng
        public Table(int id, string name, string status)
        {
            this .ID = id;
            this.Name = name;
            this.Status = status;

        }

        // hàm dựng để xử lý dữ liệu từ database DAO
        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
        }




        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
