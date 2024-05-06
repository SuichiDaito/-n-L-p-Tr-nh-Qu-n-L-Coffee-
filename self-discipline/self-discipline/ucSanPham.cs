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
    public partial class ucSanPham : UserControl
    {
        public ucSanPham()
        {
            InitializeComponent();
        }
        public event EventHandler onSelect = null;
        public int id { get; set; }
        public string Price { get; set; }
        public string PCategory { get; set; }
        public string TenMon
        {
            get { return btnTenMon.Text; }
            set { btnTenMon.Text = value; }
        }
        public Image AnhMon
        {
            get { return picAnhMonAn.Image; }
            set { picAnhMonAn.Image = value; }
        }

        private void picAnhMonAn_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}
