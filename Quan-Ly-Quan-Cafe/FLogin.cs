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
            InitializeComponent();
        }
        //nút đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            FTableManager f = new FTableManager();
            //Ẩn form đăng nhập trước khi hiển thị form quản lý
            this.Hide();
            f.ShowDialog();
            //Khi form quản lý bị đóng sẽ hiển thị lại form đăng nhập
            this.Show();
        }

        //nút thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            //hiển thị thông báo hỏi người dùng có muốn thoát không
            Application.Exit();
        }

        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //hiển thị thông báo hỏi người dùng có muốn thoát không . Ok || Cancel
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
