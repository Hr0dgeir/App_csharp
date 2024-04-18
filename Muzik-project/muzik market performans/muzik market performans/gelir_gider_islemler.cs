using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzik_market_performans
{
    public static class gelir_gider_islemler
    {
        public static DataTable satilan_urunler()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand urunler = new SqlCommand("select * from Satilan_urunler",con);
            SqlDataReader read = urunler.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
                
        }
    }
}
