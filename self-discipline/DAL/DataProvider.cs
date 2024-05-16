using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DataProvider
    {
        QuanLyHoaDonDTO hd = new QuanLyHoaDonDTO();
        SqlConnection conn = new SqlConnection(@"Data Source=QuangDuc\SQLSERVER;Initial Catalog=COFFEE_HOUSE;Integrated Security=True;Encrypt=False");


        public DataTable ExecuteSelect(string query)
        {
            DataTable result = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(result);
                conn.Close();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
            return result;
        }
        public int ExecuteScalar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(MAHD) FROM HOADON", conn);
                conn.Open();
                Int32 id = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                return id;
            }
            catch (Exception e) { return 0; }
        }
        public Double ExecuteScalar_KhuyenMai(int makm)
        {
            string query = $"SELECT PhanTram FROM KHUYENMAI WHERE KHUYENMAI.MaGiamGia = ${makm}";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                Double phantram = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                return phantram;
            }
            catch (Exception e) { return 0; }
        }

    }
}
