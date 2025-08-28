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
    public partial class FTableManager : Form
    {
        public FTableManager()
        {
            InitializeComponent(); // Khởi tạo các thành phần giao diện của form
        }

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
    }
}
