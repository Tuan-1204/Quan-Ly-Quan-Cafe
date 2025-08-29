using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Quan_Cafe.DTO; // Add this using directive for the Table class
using Quan_Ly_Quan_Cafe.DAO; // Add this using directive for TableDAO

namespace Quan_Ly_Quan_Cafe
{
    public partial class FTableManager : Form
    {
        public FTableManager()
        {
            InitializeComponent(); // Khởi tạo các thành phần giao diện của form
            LoadTable(); // Gọi phương thức để tải và hiển thị danh sách bàn
        }

        #region Methods
        void LoadTable()
        {
        List<Table> tableList = TableDAO.Instance.LoadTableList(); // Gọi phương thức LoadTableList từ lớp TableDAO để lấy danh sách bàn
            foreach (Table item in tableList)
            {
                Button btn = new Button(); // Tạo một nút Button mới để đại diện cho mỗi bàn
                btn.Width = TableDAO.TableWidth; // Đặt chiều rộng của nút dựa trên hằng số TableWidth từ TableDAO
                btn.Height = TableDAO.TableHeight; // Đặt chiều cao của nút dựa trên hằng số TableHeight từ TableDAO
                btn.Text = item.Name + Environment.NewLine + item.Status; // Đặt văn bản hiển thị trên nút, bao gồm tên và trạng thái của bàn
                switch (item.Status) // Thay đổi màu nền của nút dựa trên trạng thái của bàn
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua; // Màu xanh dương cho bàn trống
                        break;
                    default:
                        btn.BackColor = Color.LightPink; // Màu hồng cho bàn có người
                        break;
                }
                flpTable.Controls.Add(btn); // Thêm nút vào flpTable để hiển thị trên giao diện
            }
        }
        #endregion

        #region Events
        // Sự kiện khi chọn menu "Đăng Xuất"
        private void đăngXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form quản lý bàn
        }

        // Sự kiện khi chọn menu "Admin"
        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAdmin fAdmin = new FAdmin(); // Tạo form quản trị
            fAdmin.ShowDialog(); // Hiển thị form quản trị dưới dạng dialog (modal)
        }

        // Sự kiện khi chọn menu "Thông Tin Cá Nhân"
        private void thôngTinCaNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAccountProfile fAccountProfile = new FAccountProfile(); // Tạo form thông tin cá nhân
            fAccountProfile.ShowDialog(); // Hiển thị form thông tin cá nhân dưới dạng dialog (modal)
        }
        #endregion
    }
}
