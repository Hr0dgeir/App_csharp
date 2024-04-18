using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant_proje
{
    public static class yemek_ekle
    {
        public static void yeni_yemek_ekle(string yemek_fiyat, string yemek_ad2, string yemek_ad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            SqlCommand cmd2 = new SqlCommand($"ALTER TABLE Yemek_fiyat_liste ADD {yemek_ad2} nvarchar(50)", con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand fiyat = new SqlCommand($"update Yemek_fiyat_liste set {yemek_ad2} =@fiyat", con);
            fiyat.Parameters.AddWithValue("@fiyat",$"{yemek_ad} : "+yemek_fiyat);
            fiyat.ExecuteNonQuery();
            con.Close();
        }
        public static void yemek_guncelle(string yeni_fiyat,string yemek_ad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"update Yemek_fiyat_liste set {yemek_ad} = @yeni_fiyat", con);
            cmd.Parameters.AddWithValue("@yeni_fiyat",$"{yemek_ad} : " +  yeni_fiyat);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static DataTable yemek_datagrid()
        {
            DataTable dataTable = new DataTable();

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Yemek_fiyat_liste", con);
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            con.Close();
            return dataTable;
        }

        public static void yemek_sil(string yemek_ad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");

            con.Open();
            SqlCommand delete = new SqlCommand($"ALTER TABLE Yemek_fiyat_liste DROP COLUMN {yemek_ad}", con);
            delete.ExecuteNonQuery();
            MessageBox.Show("Başarıyla silindi");
            con.Close();
        }

        public static bool urun_kontrol(string urun_adi, string urun_fiyat)
        {
            List<string> yemek_liste = new List<string>();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand kontrol = new SqlCommand("select * from Yemek_fiyat_liste", con);
            SqlDataReader read = kontrol.ExecuteReader();
            while (read.Read())
            {
                for (int i = 1; i < read.FieldCount; i++)
                {
                    yemek_liste.Add(read[i].ToString());

                    //MessageBox.Show(yemek_liste[i-1]);
                    //

                    //string eklenecek_urun = yemek_liste[i];

                    //string[] veri = eklenecek_urun.Split(':');
                    //if (veri.Length >= 2)
                    //{
                    //    string urun = veri[0];
                    //    yemek_liste_ad.Add(urun);
                    //}
                }
            }

            con.Close();
            if (yemek_liste.Contains(urun_adi + " : " + urun_fiyat))
            {
                MessageBox.Show("Eklemek istediğiniz içecek zaten menüde lütfen kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
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

            


            //bool olmaz = false;


            //for (int i = 0; i < yemek_liste_ad.Count; i++)
            //{
            //    if (yemek_liste_ad.Contains(urun_adi))
            //    {
            //        olmaz = true;
            //        break;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Başarılı");
            //    }
            //}

            ////(yemek_liste.Contains(urun_adi + " : " + urun_fiyat))

            //if(olmaz == true)
            //{
            //    MessageBox.Show("Eklemek istediğiniz içecek zaten menüde lütfen kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}








        }
    }
}
