using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzik_market_performans
{
    public static class bilgileri_kontrol_et
    {

        public static List<string> tel = new List<string>();
        public static List<string> email = new List<string>();
        public static List<string> kullaniciad = new List<string>();
        public static void bilgi_kontrol()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand select = new SqlCommand("select * from Kullanici_Kayit",con);
            SqlDataReader read = select.ExecuteReader();
            while (read.Read())
            {
                tel.Add(read[3].ToString());
                kullaniciad.Add(read[6].ToString());
                email.Add(read[4].ToString());
            }
            con.Close();
        }
    }
}
