using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzik_market_performans
{
    public static class Satilan_urunler
    {
        public static void urun_sat(string urun,int fiyat , int miktar , string satis_tarihi)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand satis_ekle = new SqlCommand("insert into Satilan_urunler (Satilan_urun,Fiyat,Miktar,Satis_tarihi) values (@urun,@fiyat,@miktar,@tarih)",con);
            satis_ekle.Parameters.AddWithValue("@urun",urun);
            satis_ekle.Parameters.AddWithValue("@fiyat",fiyat);
            satis_ekle.Parameters.AddWithValue("@miktar",miktar);
            satis_ekle.Parameters.AddWithValue("@tarih",satis_tarihi);
            satis_ekle.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Başarıyla Satış gerçekleşti","İşlem Başarılı",MessageBoxButtons.OK);
        }
    }
}
