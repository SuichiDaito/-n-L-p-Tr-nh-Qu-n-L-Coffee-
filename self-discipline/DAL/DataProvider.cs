using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProvider
    {
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

    }
}
