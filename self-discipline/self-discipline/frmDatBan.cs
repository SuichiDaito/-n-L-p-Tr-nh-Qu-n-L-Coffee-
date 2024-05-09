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
        public delegate void MaDatBan(string value);

        public event MaDatBan SendIdTable;
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

        private void btnBan6_Click(object sender, EventArgs e)
        {
            string ValueTable = "6";
            if (SendIdTable != null)
            {
                SendIdTable(ValueTable);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnBan1_Click(object sender, EventArgs e)
        {
            string ValueTable = "1";
            if (SendIdTable != null)
            {
                SendIdTable(ValueTable);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnBan2_Click(object sender, EventArgs e)
        {
            string ValueTable = "2";
            if (SendIdTable != null)
            {
                SendIdTable(ValueTable);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnBan3_Click(object sender, EventArgs e)
        {
            string ValueTable = "3";
            if (SendIdTable != null)
            {
                SendIdTable(ValueTable);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnBan4_Click(object sender, EventArgs e)
        {
            string ValueTable = "4";
            if (SendIdTable != null)
            {
                SendIdTable(ValueTable);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnBan5_Click(object sender, EventArgs e)
        {
            string ValueTable = "5";
            if (SendIdTable != null)
            {
                SendIdTable(ValueTable);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnBan7_Click(object sender, EventArgs e)
        {

            string ValueTable = "7";
            if (SendIdTable != null)
            {
                SendIdTable(ValueTable);
                this.Close();
            }
            else
            {
                this.Close();
            }

        }

        private void btnBan8_Click(object sender, EventArgs e)
        {
            string ValueTable = "8";
            if (SendIdTable != null)
            {
                SendIdTable(ValueTable);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void bnBan9_Click(object sender, EventArgs e)
        {
            string ValueTable = "9";
            if (SendIdTable != null)
            {
                SendIdTable(ValueTable);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }

}
