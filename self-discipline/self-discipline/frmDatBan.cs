using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace self_discipline
{
    public partial class frmDatBan : Form
    {
        public frmDatBan()
        {
            InitializeComponent();
        }

        private void btnTroVveTrangQuanLy_Click(object sender, EventArgs e)
        {
            frmQuanLy frm = new frmQuanLy();
            frm.Show();
        }

        private void btnTroVeTrangBanHang_Click(object sender, EventArgs e)
        {
            frmBanHang frm = new frmBanHang();
            frm.Show();
        }
    }
}
