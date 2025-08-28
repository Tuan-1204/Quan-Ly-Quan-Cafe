using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Quan_Ly_Quan_Cafe.DAO
{
    public class DataProvider
    {
        //Kết nối database
        private string connectionSTR = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanCafe;Integrated Security=True;TrustServerCertificate=True";
        //Hàm thực thi câu lệnh truy vấn
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            //khởi tạo 1 DataTable để chứa dữ liệu truy vấn
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR)) // sử dụng using để tự động giải phóng bộ nhớ

            {
                //mở kết nối
                connection.Open();
                //thực thi câu lệnh truy vấn
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' '); // tách các từ trong câu lệnh truy vấn
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@')) // nếu từ này chứa ký tự @ thì đó là tham số
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }


                SqlDataAdapter adapter = new SqlDataAdapter(command); // trung gian thực hiện câu lệnh truy vấn
                adapter.Fill(data); // đổ dữ liệu vào data table
                                    //đóng kết nối
                connection.Close();
            }
            return data;
        }

        //Hàm thực thi câu lệnh truy vấn trả về số dòng bị ảnh hưởng

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR)) // sử dụng using để tự động giải phóng bộ nhớ
            {
                //mở kết nối
                connection.Open();
                //thực thi câu lệnh truy vấn
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' '); // tách các từ trong câu lệnh truy vấn
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@')) // nếu từ này chứa ký tự @ thì đó là tham số
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery(); // trả về số dòng bị ảnh hưởng
                connection.Close(); //đóng kết nối
            }
            return data;
        }


        //Hàm thực thi câu lệnh truy vấn trả về giá trị đầu tiên của cột đầu tiên trong kết quả truy vấn
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR)) // sử dụng using để tự động giải phóng bộ nhớ
            {
                //mở kết nối
                connection.Open();
                //thực thi câu lệnh truy vấn
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' '); // tách các từ trong câu lệnh truy vấn
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@')) // nếu từ này chứa ký tự @ thì đó là tham số
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar(); // trả về giá trị đầu tiên của cột đầu tiên trong kết quả truy vấn
                connection.Close(); //đóng kết nối
            }
            return data;
        }
    }
}
