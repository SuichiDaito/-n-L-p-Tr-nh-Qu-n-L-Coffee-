
using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace self_discipline
{
    public partial class frmBanHang : Form
    {
        QuanLySanPhamDTO quanLySanPhamDTO = new QuanLySanPhamDTO();
        QuanLySanPhamBLL quanLySanPhamBLL = new QuanLySanPhamBLL();

        public frmBanHang()
        {
            InitializeComponent();
        }
        private void frmBanHang_Load_1(object sender, EventArgs e)
        {
            LoadProducts();
        
        }
        private void AddItem(string id, string name, string cat, string price, Image Pimage)
        {
            double tot = 0;
            ucSanPham w = new ucSanPham()
            {
                TenMon = name,
                Price = price,
                PCategory = cat,
                id = Convert.ToInt32(id),
                AnhMon = Pimage
            };

            Products_panel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucSanPham)ss;

                foreach (DataGridViewRow item in dgvHoaDonBanHang.Rows)
                {
                    if (Convert.ToInt32(item.Cells["colId"].Value) == wdg.id)
                    {
                        item.Cells["colSoLuong"].Value = int.Parse(item.Cells["colSoLuong"].Value.ToString()) + 1;
                       
                        item.Cells["colThanhTien"].Value = int.Parse(item.Cells["colSoLuong"].Value.ToString()) * Double.Parse(item.Cells["colGia"].Value.ToString());
                        return;

                    }       
                }
                dgvHoaDonBanHang.Rows.Add(new object[] { 0, wdg.id, wdg.TenMon, 1, wdg.Price, wdg.Price });
                GetTotal();
            };
        }
        private void LoadProducts()
        {
            DataTable table = new DataTable();
            table = quanLySanPhamBLL.LayDS();

            foreach (DataRow item in table.Rows)
            {
                string path = Application.StartupPath + "//..//..//Resources//" + item["Avatar"].ToString();
                Image anh = Image.FromFile(path);

                AddItem(item["MaSP"].ToString(), item["TenSP"].ToString(), item["LoaiSP"].ToString(), item["GiaBan"].ToString(),anh);
            
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTimKiemMon_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in Products_panel.Controls)
            {
                var sp = (ucSanPham)item;
                sp.Visible = sp.TenMon.ToLower().Contains(txtTimKiemMon.Text.Trim().ToLower());
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvHoaDonBanHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvHoaDonBanHang.Rows)
            {
                if(row.Cells.Count > 0)
                {
                    count++;
                    row.Cells["colSTT"].Value = count;
                }
            }
        }
        private void GetTotal()
        {
            double tot = 0;

            foreach (DataGridViewRow item in dgvHoaDonBanHang.Rows)
            {
                if (item.Cells["colThanhTien"].Value != null)
                {


                    tot += Double.Parse(item.Cells["colThanhTien"].Value.ToString());
                }
            }

            lblTotal.Text  = tot.ToString();

        }

        private void dgvHoaDonBanHang_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void btnfrmQuanLy_Click(object sender, EventArgs e)
        {
            frmQuanLy frm = new frmQuanLy();
            frm.Show();
            this.Hide();
        }
    }
}
