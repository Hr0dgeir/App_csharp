using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restorant_proje
{
    public static class icecek_fiyat
    {
        public static DataTable data_grid_yenile()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand data = new SqlCommand("select * from icecek_fiyat", con);
            SqlDataReader read = data.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }

        public static DataTable data_grid2_yenile()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand data = new SqlCommand("select * from icecek_stok", con);
            SqlDataReader read = data.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }

        public static void urun_stok(string urun_ad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
        }

        public static bool urun_ekle(string urun_adi, string urun_fiyat, string urun_stok)
        {
            if (urun_kontrol(urun_adi, urun_fiyat) == true)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
                SqlCommand cmd = new SqlCommand($"Alter Table icecek_fiyat Add {urun_adi} nvarchar(50)", con);
                con.Open();
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand($"Alter Table icecek_stok Add {urun_adi} nvarchar(50)", con);
                cmd2.ExecuteNonQuery();

                SqlCommand stok_ekle = new SqlCommand($"update icecek_stok set {urun_adi}=@stok", con);
                stok_ekle.Parameters.AddWithValue("@stok", $"{urun_adi} : " + urun_stok);
                stok_ekle.ExecuteNonQuery();


                SqlCommand fiyat_ekle = new SqlCommand($"update icecek_fiyat set {urun_adi}=@fiyat", con);
                fiyat_ekle.Parameters.AddWithValue("@fiyat", $"{urun_adi} : " + urun_fiyat);
                fiyat_ekle.ExecuteNonQuery();
                con.Close();
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool urun_stok_guncelle(string urun_adi, string urun_stok)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            if (urun_adi != null && urun_stok != null)
            {
                con.Open();
                SqlCommand stok_ekle = new SqlCommand($"update icecek_stok set {urun_adi}=@stok", con);
                stok_ekle.Parameters.AddWithValue("@stok", $"{urun_adi} : " + urun_stok);
                stok_ekle.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Başarılı");
                return true;
                
            }
            else
            {
                con.Close();
                MessageBox.Show("Ürün Güncellenemedi");
                return false;
            }

        }

        public static void urun_guncelle(string urun_fiyat, string yemek_ad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"update icecek_fiyat set {yemek_ad} = @yeni_fiyat", con);
            cmd.Parameters.AddWithValue("@yeni_fiyat", $"{yemek_ad} : " + urun_fiyat);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void urun_sil(string urun_ad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"ALTER TABLE icecek_fiyat DROP COLUMN {urun_ad}", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static bool urun_kontrol(string urun_adi, string urun_fiyat)
        {
            List<string> icecekler_veritabani_fiyat = new List<string>();
            List<string> icecekler_veritabani_stok = new List<string>();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand kontrol = new SqlCommand("select * from icecek_fiyat", con);
            SqlDataReader read = kontrol.ExecuteReader();
            while (read.Read())
            {
                for (int i = 1; i < read.FieldCount; i++)
                {
                    icecekler_veritabani_fiyat.Add(read[i].ToString());
                    //MessageBox.Show(icecekler_veritabani_fiyat[i-1]);
                }
            }

            //SqlCommand cmd = new SqlCommand("select * from icecek_stok",con);
            //SqlDataReader read_stok = cmd.ExecuteReader();
            //{
            //    while (read.Read())
            //    {
            //        for (int i = 1; i < read.FieldCount; i++)
            //        {
            //            icecekler_veritabani_stok.Add(read[i].ToString());
            //            //MessageBox.Show(icecekler_veritabani_stok[i-1]);
            //        }
            //    }
            //}

            con.Close();
            if (icecekler_veritabani_fiyat.Contains(urun_adi + " : " + urun_fiyat))
            {
                MessageBox.Show("Eklemek istediğiniz içecek zaten menüde lütfen kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }




        //public static bool urun_kontrol(string urun_adi)
        //{
        //    List<string> icecekler_veritabani_fiyat = new List<string>();
        //    List<string> icecekler_veritabani_ad = new List<string>();
        //    SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
        //    con.Open();
        //    SqlCommand kontrol = new SqlCommand("select * from icecek_fiyat", con);
        //    SqlDataReader read = kontrol.ExecuteReader();
        //    while (read.Read())
        //    {
        //        for (int i = 1; i < read.FieldCount; i++)
        //        {
        //            icecekler_veritabani_fiyat.Add(read[i].ToString());
        //            //MessageBox.Show(icecekler_veritabani_fiyat[i-1]);

        //            string eklenecek_urun = icecekler_veritabani_fiyat[i];

        //            string[] veri = eklenecek_urun.Split(':');
        //            if (veri.Length >= 2)
        //            {
        //                string urun = veri[0];
        //                urun = null;
        //                icecekler_veritabani_ad.Add(urun);
        //            }
        //        }
        //    }



        //    con.Close();
        //    if (icecekler_veritabani_fiyat.Contains(icecekler_veritabani_ad.ToString()))
        //    {
        //        MessageBox.Show("Eklemek istediğiniz içecek zaten menüde lütfen kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
    }
}
