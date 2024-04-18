using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzik_market_performans
{
    public partial class Ana_panel : Form
    {
        public Ana_panel()
        {
            InitializeComponent();
        }
        private void Ana_panel_Load(object sender, EventArgs e)
        {
            kullanici_resim.SizeMode = PictureBoxSizeMode.StretchImage;
            kullanici_resim.Image = kullanici.kullanici_foto();

            giris.kullanici_bilgiAl(kullanici_bilgileri.kullaniciad);
            guna2HtmlLabel1.Text = kullanici_bilgileri.Ad + " " + kullanici_bilgileri.Soyad;


            combobox_urun.DataSource = Satis_islemleri.muzikler();
            combobox_urun.DisplayMember = "Muzik_ad";
            combobox_urun.ValueMember = "Muzik_ad";

            textbox_sanatci.Text = "";
            textbox_fiyat.Text = "";
            textbox_tarih.Text = "";
        }
        private void combobox_urun_SelectedIndexChanged(object sender, EventArgs e)
        {
            Satis_islemleri.secilen_sanatci(combobox_urun.SelectedValue.ToString());
            Satis_islemleri.fiyat_al(combobox_urun.SelectedValue.ToString());
            Satis_islemleri.tarih_al(combobox_urun.SelectedValue.ToString());
            if (Satis_islemleri.sanatci != null)
            {
                textbox_sanatci.Text = Satis_islemleri.sanatci;
                textbox_fiyat.Text = Satis_islemleri.fiyat;
                textbox_tarih.Text = Satis_islemleri.tarih;
            }
            else
            {
                textbox_sanatci.Text = "Sanatçı bulunamadı";
                textbox_fiyat.Text = "Sanatçı bulunamadı";
                textbox_tarih.Text = "Sanatçı bulunamadı";
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Urunler_panel frm = new Urunler_panel();
            frm.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            kullanici_ayarlari frm = new kullanici_ayarlari();
            frm.ShowDialog();

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            kullanici_bilgileri.Ad = null;
            kullanici_bilgileri.Soyad = null;
            kullanici_bilgileri.kullaniciad = null;

            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();

        }

        private void Ana_panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (textbox_fiyat.Text != null && textbox_sanatci.Text != null && textbox_tarih.Text != null)
            {
                string tarih = DateTime.Now.ToString();
                Satilan_urunler.urun_sat(combobox_urun.SelectedValue.ToString(), Convert.ToInt32(textbox_fiyat.Text), Convert.ToInt32(Combobox_sanatcı.SelectedItem), tarih);
                textbox_fiyat.Text = "";
                textbox_sanatci.Text = "";
                textbox_tarih.Text = "";
                tarih = "";
            }
        }
        private void Combobox_sanatcı_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fiyat = Satis_islemleri.fiyat_miktar;
            if (!String.IsNullOrEmpty(textbox_fiyat.Text))
            {

                string adet = Combobox_sanatcı.SelectedItem.ToString();
                int yeni_fiyat = Convert.ToInt32(fiyat) * Convert.ToInt32(adet);
                textbox_fiyat.Text = yeni_fiyat.ToString();
            }
            else
            {
                MessageBox.Show("Lütfen Bir müzik seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            gelir_gider frm = new gelir_gider();
            frm.ShowDialog();   
        }
    }
}
