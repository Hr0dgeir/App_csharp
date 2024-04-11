using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant_proje
{
    public static class kazanc
    {
        public static void kazanc_gunu()
        {
            //DateTime dateTime = DateTime.Now;
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select * from Gunluk_kazanc",con);
            //SqlDataReader read = cmd.ExecuteReader();
            //while (read.Read())
            //{
            //    if (read[1].ToString() == null)
            //    {
            //        SqlCommand ekle = new SqlCommand("insert into Gunluk_kazanc (Zaman) values (@zaman)",con);
            //        ekle.Parameters.AddWithValue("@zaman",dateTime);
            //        ekle.ExecuteNonQuery();
            //        System.Windows.Forms.MessageBox.Show("ZAMAN BOŞ");
            //    }
            //    else
            //    {
            //        string veritabani_zaman = read[1].ToString();
            //        if (veritabani_zaman == dateTime.ToString())
            //        {
            //            System.Windows.Forms.MessageBox.Show("ZAMAN bugüne eşit");
            //        }
            //        else
            //        {

            //            DateTime birSonrakiGun = dateTime.AddDays(1);
            //            SqlCommand ekle = new SqlCommand("insert into Gunluk_kazanc (Zaman) values (@zaman)", con);
            //            ekle.Parameters.AddWithValue("@zaman", birSonrakiGun);
            //            ekle.ExecuteNonQuery();
            //            dateTime = birSonrakiGun;
            //            System.Windows.Forms.MessageBox.Show("ZAMAN ilerledi");

            //        }
            //    }
            //}
            //con.Close();

            //bool zaman_bos = false;
            //DateTime dateTime = DateTime.Now.Date;
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select * from Gunluk_kazanc", con);
            //SqlDataReader read = cmd.ExecuteReader();
            //while (read.Read())
            //{
            //    if (read[1].ToString() == "")
            //    {
            //        //zaman_bos = true;
            //        break;
            //    }
            //}
            //read.Close();
            //SqlCommand tarih_bos = new SqlCommand("update Gunluk_kazanc set Zaman=@zaman",con);
            //tarih_bos.Parameters.AddWithValue("@zaman",dateTime.ToString());
            //tarih_bos.ExecuteNonQuery();
            //con.Close();
            //masa_hesap.kazanc_gun = dateTime.ToString();
        }
    }
}
