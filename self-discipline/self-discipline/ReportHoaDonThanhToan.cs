using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace self_discipline
{
    public partial class ReportHoaDonThanhToan : Form
    {
        public ReportHoaDonThanhToan()
        {
            InitializeComponent();
        }

        public ReportHoaDonThanhToan(string value1, string value2, string value5)
        {
            InitializeComponent();
           this.value3 = value1;
           this.value4 = value2;
            this.value6 = value5;


        }
        public string value3 { get; set; } 
        public string value4 { get; set; }  
        public string value6 { get; set; }

        private void ReportHoaDonThanhToan_Load(object sender, EventArgs e)
        {
            string conncetion = @"Data Source=QuangDuc\SQLSERVER;Initial Catalog=COFFEE_HOUSE;Integrated Security=True;Encrypt=False";
            HoaDonThanhToan HoaDonThanhToan = new HoaDonThanhToan();

            string hd = value3;
            string maban = value4;
            string phantram = value6;

            int MaHD = Convert.ToInt32(hd);
            
            string query = string.Format(@"SELECT CTHD.MaHD, HOADON.MaBan, SANPHAM.TenSP, CTHD.SL, CTHD.GiaBan, NHANVIEN.Ho, NHANVIEN.Ten, KHUYENMAI.PhanTram
                    FROM HOADON INNER JOIN
                         CTHD ON HOADON.MaHD = CTHD.MaHD INNER JOIN
                         KHUYENMAI ON HOADON.MaKhuyenMai = KHUYENMAI.MaGiamGia INNER JOIN
                         NHANVIEN ON HOADON.MaNV = NHANVIEN.MaNV INNER JOIN
                         SANPHAM ON CTHD.MaSP = SANPHAM.MaSP
                   WHERE (HOADON.MaHD = {0})",MaHD);   

            SqlConnection conn = new SqlConnection(conncetion);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(HoaDonThanhToan, HoaDonThanhToan.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("ThanhToanHoaDon", HoaDonThanhToan.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();

            ReportParameter soBan = new ReportParameter("Param_SoBan", maban);
            this.reportViewer1.LocalReport.SetParameters(soBan);
            ReportParameter sohoadon = new ReportParameter("Param_HoaDon", hd);
            this.reportViewer1.LocalReport.SetParameters(sohoadon);
            ReportParameter sophantram = new ReportParameter("Param_PhanTram", phantram);
            this.reportViewer1.LocalReport.SetParameters(sophantram);


            this.reportViewer1.RefreshReport();
        }
    }
}
