using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzik_market_performans
{
    public static class Kullanici_guncelle
    {
        public static string sifre { get; set; }
        public static string Kullanici_ad { get; set; }
        public static string E_mail { get; set; }
        public static string Tel { get; set; }
        public static int islem_sayisi { get; set; }
        public static void bilgiler()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand bilgi = new SqlCommand("select * from Kullanici_Kayit where Kullanici_Ad = '"+kullanici_bilgileri.kullaniciad+"' ",con);
            SqlDataReader read = bilgi.ExecuteReader();
            while (read.Read())
            {
                Kullanici_ad = read[6].ToString();
                E_mail = read[4].ToString();
                Tel = read[3].ToString();
                sifre = read[7].ToString();
            }
            con.Close();
        }

        public static void kullanici_ad_guncelle(string yeni_ad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand updateka = new SqlCommand("update Kullanici_Kayit set Kullanici_ad=@kullanici_ad where Kullanici_Ad = '"+kullanici_bilgileri.kullaniciad+"' ",con);
            updateka.Parameters.AddWithValue("@kullanici_ad",yeni_ad);
            updateka.ExecuteNonQuery();
            con.Close();
            kullanici_bilgileri.kullaniciad = yeni_ad;
            Kullanici_guncelle.Kullanici_ad = yeni_ad;
        }

        public static void kullanici_tel_guncelle(string tel_no)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand updateka = new SqlCommand("update Kullanici_Kayit set Tel=@tel where Kullanici_Ad = '" + kullanici_bilgileri.kullaniciad + "' ", con);
            updateka.Parameters.AddWithValue("@tel", tel_no);
            updateka.ExecuteNonQuery();
            con.Close();
            Kullanici_guncelle.Tel = tel_no;
        }
        public static void kullanici_email_guncelle(string email)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand updateka = new SqlCommand("update Kullanici_Kayit set E_mail=@e_mail where Kullanici_Ad = '" + kullanici_bilgileri.kullaniciad + "' ", con);
            updateka.Parameters.AddWithValue("@e_mail", email);
            updateka.ExecuteNonQuery();
            con.Close();
            Kullanici_guncelle.E_mail = email;
        }

        public static void kullanici_sifre_guncelle(string sifre)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand updateka = new SqlCommand("update Kullanici_Kayit set Sifre=@sifre where Kullanici_Ad = '" + kullanici_bilgileri.kullaniciad + "' ", con);
            updateka.Parameters.AddWithValue("@sifre", sifre);
            updateka.ExecuteNonQuery();
            con.Close();
            Kullanici_guncelle.sifre = sifre;
        }
        public static Image kullanici_foto()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            try
            {

                SqlCommand picture_retrieve = new SqlCommand("select fotograf from Kullanici_Kayit where Kullanici_Ad='" + kullanici_bilgileri.kullaniciad + "'", con);
                byte[] pictureData = (byte[])picture_retrieve.ExecuteScalar();
                if (pictureData != null)
                {
                    using (MemoryStream ms = new MemoryStream(pictureData))
                    {
                        Image retrievedImage = Image.FromStream(ms);
                        con.Close();
                        return retrievedImage;
                        //kullanici_resim.Image = retrievedImage;

                        //kullanici_resim.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }

        }
    }
}
