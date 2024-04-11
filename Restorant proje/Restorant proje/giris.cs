using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Restorant_proje
{
    public static class giris
    {
        public static bool giris_kontrol(string sifre, string kullanici_adi)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string sifrelenmis_sifre;
            SqlCommand login = new SqlCommand("select * from Kullanici_Kayit where Kullanici_adi=@kullanici and sifre=@sifre", con);
            sifrelenmis_sifre = Sha256convertor.sha256hash_(sifre);
            login.Parameters.AddWithValue("@kullanici", kullanici_adi);
            login.Parameters.AddWithValue("@sifre", sifrelenmis_sifre);

            SqlDataAdapter da = new SqlDataAdapter(login);

            DataTable dt = new DataTable();
            da.Fill(dt);

            List<string> kullanici_liste = new List<string>();
            SqlCommand cmd = new SqlCommand("select * from Kullanici_Kayit", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                string kullanici_adlari = read[1].ToString();
                kullanici_liste.Add(kullanici_adlari);
            }

            con.Close();
            if (dt.Rows.Count > 0)
            {
                System.Windows.Forms.MessageBox.Show("Başarılı","Giriş Yapıldı",System.Windows.Forms.MessageBoxButtons.OK,MessageBoxIcon.None);
                return true;
            }
            else
            {
                if (kullanici_liste.Contains(kullanici_adi))
                {
                    System.Windows.Forms.MessageBox.Show("Şifreniz veya Kullanıcı adınız hatalı");
                    return false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Böyle bir hesap bulunamadı");
                    return false;
                }
                
            }

            
        } 
        public static void kullanici_bilgi_al(string kullanici_adi)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand kullanici_bilgier = new SqlCommand("select * from Kullanici_Kayit where Kullanici_Adi like'%"+kullanici_adi+"%' ", con);
            SqlDataReader read = kullanici_bilgier.ExecuteReader();
            while (read.Read())
            {
                string kullanici_mail = read[6].ToString();
                string yetki = read[8].ToString();


                kullanici_değiskenleri.kullanici_email = kullanici_mail.ToString();
                if (yetki == "Personel")
                {
                    Ana_panel frm = new Ana_panel();
                    frm.Show();
                }
                if (yetki == "Yönetici")
                {
                    yonetici_panel frm = new yonetici_panel();
                    frm.Show();
                }
            }
            con.Close();
        }
    }
}
