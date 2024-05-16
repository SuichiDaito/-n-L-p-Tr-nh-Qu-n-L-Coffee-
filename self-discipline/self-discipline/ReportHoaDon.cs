using BLL;
using DTO;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace self_discipline
{
    public partial class ReportHoaDon : Form
    {
        public ReportHoaDon()
        {
            InitializeComponent();
        }
      

        private void ReportHoaDon_Load(object sender, EventArgs e)
        {
           
                
            DT_ThongKeSanPham SanPhamThongKe = new DT_ThongKeSanPham();
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
       



            this.reportViewer1.RefreshReport();
          
        }
      
        


    }
}
