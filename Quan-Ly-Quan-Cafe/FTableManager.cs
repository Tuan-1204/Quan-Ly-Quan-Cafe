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
            InitializeComponent();
        }

        private void đăngXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAdmin fAdmin = new FAdmin();
            fAdmin.ShowDialog();
        }

        private void thôngTinCaNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAccountProfile fAccountProfile = new FAccountProfile();
            fAccountProfile.ShowDialog();
        }
    }
}
