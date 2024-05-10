using BLL;
using DTO;
using Microsoft.Reporting.WinForms;
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
    public partial class ReportHoaDon : Form
    {
        public static int MaHD;
        QuanLyCTHoaDonDTO chiTiet = new QuanLyCTHoaDonDTO();
        QuanLyChiTietHoaDonBLL ChiTietBLL = new QuanLyChiTietHoaDonBLL();
        public ReportHoaDon()
        {
            InitializeComponent();
        }
      

        private void ReportHoaDon_Load(object sender, EventArgs e)
        {
            LayCTHD(chiTiet);
            this.reportViewer1.RefreshReport();
        }
      
        public  void LayCTHD(QuanLyCTHoaDonDTO chiTiet)
        {
            frmBanHang frm = new frmBanHang();
            frm.SendId += Frm_SendId;
            MaHD = chiTiet.MaHD;
            List<QuanLyCTHoaDonDTO> LayDs = ChiTietBLL.LayCTHDTheoMa(chiTiet.MaHD);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "self-discipline.Resources.Report.HoaDon.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CTHD", LayDs));
            this.reportViewer1.RefreshReport();
        }
        private void Frm_SendId(string value)
        {
            MaHD = Convert.ToInt32(value);
        }


    }
}
