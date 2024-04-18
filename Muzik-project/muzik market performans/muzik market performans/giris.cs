using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzik_market_performans
{
    public static class giris
    {
        public static bool giris_kontrol(string sifre, string kullanici_adi)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string sifrelenmis_sifre;
            SqlCommand login = new SqlCommand("select * from Kullanici_Kayit where Kullanici_Ad=@kullanici and Sifre=@sifre", con);
            sifrelenmis_sifre = Sha256convertor.sha256hash_(sifre);
            login.Parameters.AddWithValue("@kullanici", kullanici_adi);
            login.Parameters.AddWithValue("@sifre", sifrelenmis_sifre);

            SqlDataAdapter da = new SqlDataAdapter(login);

            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            if (dt.Rows.Count > 0)
            {
                System.Windows.Forms.MessageBox.Show("Başarılı", "Giriş Yapıldı", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.None);
                Ana_panel frm = new Ana_panel();
                frm.Show();
                return true;
            }
            else
            {
                return false;
            }


        }

        public static void kullanici_bilgiAl(string kullanici_ad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand bilgi = new SqlCommand("select * from Kullanici_Kayit where Kullanici_Ad like '%"+kullanici_ad+"%' ",con);
            SqlDataReader read = bilgi.ExecuteReader();
            while (read.Read())
            {
                string isim = read[1].ToString();
                string soyad = read[2].ToString();

                kullanici_bilgileri.Ad = isim;
                kullanici_bilgileri.Soyad = soyad;
            }          
            con.Close();
        }
    }
}
