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
    public static class muzik
    {       

        public static void sanatcı_ekle(string tur, string sanatcı)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand ekle = new SqlCommand("insert into Sanatcı_liste (Sanatcı,tur) values (@Sanatcı,@tur)", con);
            ekle.Parameters.AddWithValue("@Sanatcı", sanatcı);
            ekle.Parameters.AddWithValue("@tur", tur);
            ekle.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Başarıyla ekleme işlemi gerçekleşti", "İşlem Başarılı", MessageBoxButtons.OK);

        }
        public static void sanatcı_guncelle(string id,string sanatcı,string tur)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand ekle = new SqlCommand("update Sanatcı_liste set Sanatcı = @sanatcı, Tur = @tur where ID = @id", con);
            ekle.Parameters.AddWithValue("@sanatcı", sanatcı);
            ekle.Parameters.AddWithValue("@tur", tur);
            ekle.Parameters.AddWithValue("@id", id);
            ekle.ExecuteNonQuery();
            con.Close();
        }
        public static void sanatcı_sil(string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand ekle = new SqlCommand("delete from Sanatcı_liste where ID = @id", con);
            ekle.Parameters.AddWithValue("@id", id);
            ekle.ExecuteNonQuery();
            con.Close();
        }

        public static void tur_ekle(string tur)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand ekle = new SqlCommand("insert into Muzik_turleri (tur) values (@tur)", con);
            ekle.Parameters.AddWithValue("@tur", tur);
            ekle.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Başarıyla ekleme işlemi gerçekleşti", "İşlem Başarılı", MessageBoxButtons.OK);
        }

        public static void tur_guncelle(string tur,string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand ekle = new SqlCommand("update Muzik_turleri set Tur=@tur where ID=@id", con);
            ekle.Parameters.AddWithValue("@tur", tur);
            ekle.Parameters.AddWithValue("@id", id);
            ekle.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Başarıyla güncelleme işlemi gerçekleşti", "İşlem Başarılı", MessageBoxButtons.OK);
        }

        public static void tur_sil(string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand ekle = new SqlCommand("delete from Muzik_turleri where ID=@id", con);
            ekle.Parameters.AddWithValue("@id", id);
            ekle.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Başarıyla silme işlemi gerçekleşti", "İşlem Başarılı", MessageBoxButtons.OK);
        }

        public static DataTable tur_liste()
        {
            DataTable dataTable = new DataTable();

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");


            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Muzik_turleri", con);
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            con.Close();
            return dataTable;
        }

        public static DataTable sanatcı_liste()
        {
            DataTable dataTable = new DataTable();

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");


            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Sanatcı_liste", con);
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            con.Close();
            return dataTable;
        }

    }
}
