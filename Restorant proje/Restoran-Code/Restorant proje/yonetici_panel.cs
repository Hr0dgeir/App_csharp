using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant_proje
{
    public partial class yonetici_panel : Form
    {
        public yonetici_panel()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            kullanici_ayarlari frm = new kullanici_ayarlari();
            frm.ShowDialog();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            kullanici_değiskenleri.kullanici_email = null;
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");

        private void yonetici_panel_Load(object sender, EventArgs e)
        {
            con.Open();
            try
            {

                SqlCommand picture_retrieve = new SqlCommand("select picture_foto from Kullanici_Kayit where E_mail='" + kullanici_değiskenleri.kullanici_email + "'", con);
                byte[] pictureData = (byte[])picture_retrieve.ExecuteScalar();
                if (pictureData != null)
                {
                    using (MemoryStream ms = new MemoryStream(pictureData))
                    {
                        Image retrievedImage = Image.FromStream(ms);

                        kullanici_resim.Image = retrievedImage;
                        kullanici_resim.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {

                }

            }
            catch
            {

            }

            SqlCommand kullanici_bilgier = new SqlCommand("select * from Kullanici_Kayit where E_mail like'%" + kullanici_değiskenleri.kullanici_email + "%' ", con);
            SqlDataReader read = kullanici_bilgier.ExecuteReader();
            while (read.Read())
            {
                string kullanici_adi = read[3].ToString();
                string kullanici_soyadi = read[4].ToString();
                string yetkisi = read[8].ToString();
                string tam_ad = kullanici_adi + " " + kullanici_soyadi;
                if (kullanici_adi == null)
                {
                    kullanici.Text = "Kullanici adı bulunamadı";
                }
                else if (yetkisi == null)
                {
                    yetki.Text = "Yetkisi bulunamadı";
                }
                else
                {
                    kullanici.Text = tam_ad.ToString();
                    yetki.Text = yetkisi.ToString();
                }
            }
            read.Close();


            SqlCommand kazanc = new SqlCommand("select * from Gunluk_kazanc",con);
            SqlDataReader read_kazanc = kazanc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read_kazanc);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            masalar frm = new masalar();
            frm.ShowDialog();
        }
    }
}
