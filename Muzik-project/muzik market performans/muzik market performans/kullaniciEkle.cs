using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzik_market_performans
{
    public static class kullaniciEkle
    {
        public static void ekle(string kullaniciAd, string sifre, string Email, string Tel, string Soyad, string Ad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand ekle = new SqlCommand("insert into Kullanici_Kayit (İsim,Soyad,Tel,E_mail,Kullanici_Ad,Sifre) values (@isim , @soyad , @tel , @email , @kullaniciad , @sifre)", con);
            string sifrelenmisSifre = Sha256convertor.sha256hash_(sifre);
            ekle.Parameters.AddWithValue("@isim", Ad);
            ekle.Parameters.AddWithValue("@soyad", Soyad);
            ekle.Parameters.AddWithValue("@tel", Tel);
            ekle.Parameters.AddWithValue("@email", Email);
            ekle.Parameters.AddWithValue("@sifre", sifrelenmisSifre);
            ekle.Parameters.AddWithValue("@kullaniciad", kullaniciAd);
            ekle.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Başarıyla eklendi", "Başarılı", MessageBoxButtons.OK);
        }
        public static void ekle(string kullaniciAd, string sifre, string Email, string Tel, string Soyad, string Ad, byte[] picture)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand ekle = new SqlCommand("insert into Kullanici_Kayit (İsim,Soyad,Tel,E_mail,fotograf,Kullanici_Ad,Sifre) values (@isim , @soyad , @tel , @email ,@fotograf, @kullaniciad , @sifre)", con);
            string sifrelenmisSifre = Sha256convertor.sha256hash_(sifre);
            ekle.Parameters.AddWithValue("@isim", Ad);
            ekle.Parameters.AddWithValue("@soyad", Soyad);
            ekle.Parameters.AddWithValue("@tel", Tel);
            ekle.Parameters.AddWithValue("@email", Email);
            ekle.Parameters.AddWithValue("@sifre", sifrelenmisSifre);
            ekle.Parameters.AddWithValue("@kullaniciad", kullaniciAd);
            ekle.Parameters.AddWithValue("@fotograf", picture);
            ekle.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Başarıyla eklendi", "Başarılı", MessageBoxButtons.OK);
        }

        public static void ekle(byte[] picture)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand ekle = new SqlCommand("update Kullanici_Kayit set fotograf=@fotograf where Kullanici_Ad ='"+kullanici_bilgileri.kullaniciad+"' ", con);
            ekle.Parameters.AddWithValue("@fotograf", picture);
            ekle.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Başarıyla eklendi", "Başarılı", MessageBoxButtons.OK);
        }
    }
}
