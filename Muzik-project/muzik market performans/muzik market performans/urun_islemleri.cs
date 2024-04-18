using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzik_market_performans
{
    public static class urun_islemleri
    {
        public static void ekle(string tur, string sanatcı, string tarih, string fiyat, string muzik_adi)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand ekle = new SqlCommand("insert into Muzikler (Tur,Sanatcı,Tarih,Fiyat,Muzik_ad ) values (@tur,@sanatcı,@tarih,@fiyat,@muzik_ad)", con);
            ekle.Parameters.AddWithValue("@tur", tur);
            ekle.Parameters.AddWithValue("@sanatcı", sanatcı);
            ekle.Parameters.AddWithValue("@tarih", tarih);
            ekle.Parameters.AddWithValue("@fiyat", fiyat);
            ekle.Parameters.AddWithValue("@muzik_ad", muzik_adi);
            ekle.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Başarıyla ekleme işlemi gerçekleşti", "İşlem Başarılı", MessageBoxButtons.OK);
        }

        public static DataTable combobox_sanatcıDB()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sanatcıDB = new SqlCommand("select Sanatcı from Sanatcı_liste",con);
            SqlDataReader read = sanatcıDB.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(read);
            con.Close();
            return dataTable;
        }

        public static DataTable combobox_turDB()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sanatcıDB = new SqlCommand("select Tur from Muzik_turleri", con);
            SqlDataReader read = sanatcıDB.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(read);
            con.Close();
            return dataTable;
        }

        public static DataTable urunDB()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand sanatcıDB = new SqlCommand("select * from Muzikler", con);
            SqlDataReader read = sanatcıDB.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(read);
            con.Close();
            return dataTable;
        }
    }
}
