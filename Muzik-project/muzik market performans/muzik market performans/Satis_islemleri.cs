using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace muzik_market_performans
{
    public static class Satis_islemleri
    {
        public static string sanatci { get; set; }
        public static string fiyat { get; set; }
        public static string tarih { get; set; }
        public static string fiyat_miktar { get; set; }
        public static DataTable muzikler()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand muzikler_liste = new SqlCommand("select Muzik_ad from Muzikler", con);
            SqlDataReader read = muzikler_liste.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }
        public static void secilen_sanatci(string sanatci)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sanatcı = new SqlCommand("select Sanatcı from Muzikler where Muzik_ad = @m_ad", con);
            sanatcı.Parameters.AddWithValue("@m_ad", sanatci);
            SqlDataReader read_tur = sanatcı.ExecuteReader();
            while (read_tur.Read())
            {
                string secilensanatci = read_tur[0].ToString();
                Satis_islemleri.sanatci = secilensanatci;
            }
            con.Close();
        }

        public static void fiyat_al(string sanatci)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sanatcı = new SqlCommand("select Fiyat from Muzikler where Muzik_ad = @muzik_ad", con);
            sanatcı.Parameters.AddWithValue("@muzik_ad", sanatci);
            SqlDataReader read_tur = sanatcı.ExecuteReader();
            while (read_tur.Read())
            {
                string secilensanatci = read_tur[0].ToString();
                Satis_islemleri.fiyat = secilensanatci;
                Satis_islemleri.fiyat_miktar = secilensanatci;
            }
            con.Close();
        }

        public static void tarih_al(string sanatci)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sanatcı = new SqlCommand("select Tarih from Muzikler where Muzik_ad = @muzik_ad", con);
            sanatcı.Parameters.AddWithValue("@muzik_ad", sanatci);
            SqlDataReader read_tur = sanatcı.ExecuteReader();
            while (read_tur.Read())
            {
                string secilensanatci = read_tur[0].ToString();
                Satis_islemleri.tarih = secilensanatci;
            }
            con.Close();
        }
    }
}
