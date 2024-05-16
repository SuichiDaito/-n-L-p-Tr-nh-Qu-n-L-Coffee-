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
using System.Windows.Forms;

namespace self_discipline
{
    public partial class ReportPhieuNhap : Form
    {
        public ReportPhieuNhap()
        {
            InitializeComponent();
        }

        private void ReportPhieuNhap_Load(object sender, EventArgs e)
        {
           ThongKePhieuNhap PhieuNhapThongKe = new ThongKePhieuNhap();
            string conncetion = @"Data Source=QuangDuc\SQLSERVER;Initial Catalog=COFFEE_HOUSE;Integrated Security=True;Encrypt=False";
            string query = @"SELECT DONNHAPHANG.MaNV, NHANVIEN.Ho, NHANVIEN.Ten, NGUYENLIEU.TenNL, CTPHIEUNHAP.SL, CTPHIEUNHAP.GiaNhap, CTPHIEUNHAP.DVT, NCC.TenNCC, DONNHAPHANG.NgayLap
                  FROM   CTPHIEUNHAP INNER JOIN
                         NGUYENLIEU ON CTPHIEUNHAP.MaNL = NGUYENLIEU.MaNL INNER JOIN
                         NCC ON NGUYENLIEU.MaNCC = NCC.MaNCC INNER JOIN
                         DONNHAPHANG ON CTPHIEUNHAP.MaDon = DONNHAPHANG.MaDon INNER JOIN
                         NHANVIEN ON DONNHAPHANG.MaNV = NHANVIEN.MaNV";
            SqlConnection conn = new SqlConnection(conncetion);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(PhieuNhapThongKe, PhieuNhapThongKe.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("ThongKeTheoPhieuNhap", PhieuNhapThongKe.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();

            /*   DT_ThongKeSanPham SanPhamThongKe = new DT_ThongKeSanPham();
            string conncetion = @"Data Source=QuangDuc\SQLSERVER;Initial Catalog=COFFEE_HOUSE;Integrated Security=True;Encrypt=False";
            string query = @"SELECT  CTHD.MaSP, SANPHAM.TenSP, CTHD.SL, CTHD.GiaBan
                                    FROM  CTHD INNER JOIN SANPHAM ON CTHD.MaSP = SANPHAM.MaSP";
            SqlConnection conn = new SqlConnection(conncetion);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(SanPhamThongKe, SanPhamThongKe.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("ThongKeTheoSanPham", SanPhamThongKe.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
       */


            this.reportViewer1.RefreshReport();
        }
    }
}
