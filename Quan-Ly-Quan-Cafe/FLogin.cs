using Quan_Ly_Quan_Cafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Quan_Cafe
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent(); // Khởi tạo các thành phần giao diện của form đăng nhập
        }

        // Sự kiện khi nhấn nút "Đăng Nhập"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text; // Lấy tên đăng nhập từ TextBox
            string password = txtPassWord.Text; // Lấy mật khẩu từ TextBox

            if (AccountDAO.Instance.Login(userName, password)) // Kiểm tra đăng nhập
            {
                // Đăng nhập thành công, mở form quản lý
                FTableManager f = new FTableManager(); // Tạo form quản lý bàn
                                                       // Ẩn form đăng nhập trước khi hiển thị form quản lý
                this.Hide();
                f.ShowDialog(); // Hiển thị form quản lý bàn dưới dạng dialog (modal)
                                // Khi form quản lý bị đóng sẽ hiển thị lại form đăng nhập
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!"); // Hiển thị thông báo lỗi nếu đăng nhập không thành công
            }

        }


        // nhiệm vụ xử ký tầng hiển thị
        bool Login(string userName, string password)
        {
           return AccountDAO.Instance.Login(userName,password);
        }

        // Sự kiện khi nhấn nút "Thoát"
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo hỏi người dùng có muốn thoát không, nếu đồng ý thì thoát ứng dụng
            Application.Exit();
        }

        // Sự kiện khi đóng form đăng nhập
        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hiển thị thông báo xác nhận trước khi thoát chương trình
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true; // Nếu chọn Cancel thì không đóng form
            }
        }
    }
}
