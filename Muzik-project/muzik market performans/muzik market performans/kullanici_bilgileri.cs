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
    public static class kullanici_bilgileri
    {
        public static string Ad { get; set; }
        public static string Soyad { get; set; }
        public static string kullaniciad { get; set; }
    }
    public static class kullanici
    {
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
