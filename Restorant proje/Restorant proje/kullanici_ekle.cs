using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant_proje
{
    public static class kullanici_ekle
    {
        public static void kullanici_bilgileri(string kullanici_adi,string sifre,string ad, string soyad,string e_mail,string tel,string yetki)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Kullanici_Kayit (Kullanici_adi,sifre,Ad,Soyad,Tel,E_mail,yetki) values (@kullanici_adi,@sifre,@ad,@soyad,@tel,@e_mail,@yetki)",con);
            cmd.Parameters.AddWithValue("@kullanici_adi",kullanici_adi);
            cmd.Parameters.AddWithValue("@sifre",sifre);
            cmd.Parameters.AddWithValue("@ad",ad);
            cmd.Parameters.AddWithValue("@soyad",soyad);
            cmd.Parameters.AddWithValue("@tel",tel);
            cmd.Parameters.AddWithValue("@e_mail",e_mail);
            cmd.Parameters.AddWithValue("@yetki",yetki);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void kullanici_bilgileri(string kullanici_adi, string sifre, string ad, string soyad, string e_mail, string tel, byte[]picture ,string yetki)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Kullanici_Kayit (Kullanici_adi,sifre,Ad,Soyad,Tel,E_mail,picture_foto,yetki) values (@kullanici_adi,@sifre,@ad,@soyad,@tel,@e_mail,@picture_foto,@yetki)", con);
            cmd.Parameters.AddWithValue("@kullanici_adi", kullanici_adi);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            cmd.Parameters.AddWithValue("@ad", ad);
            cmd.Parameters.AddWithValue("@soyad", soyad);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@e_mail", e_mail);
            cmd.Parameters.AddWithValue("@picture_foto", picture);
            cmd.Parameters.AddWithValue("@yetki", yetki);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
