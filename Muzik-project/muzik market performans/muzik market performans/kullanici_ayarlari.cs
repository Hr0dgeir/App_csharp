using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzik_market_performans
{
    public partial class kullanici_ayarlari : Form
    {
        public kullanici_ayarlari()
        {
            InitializeComponent();
        }

        private void button_resimekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please Sellect your picture";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                kullanici_resim.Image = null;
                string dosya_yolu = ofd.FileName;
                kullanici_resim.Image = Image.FromFile(dosya_yolu);
                kullanici_resim.SizeMode = PictureBoxSizeMode.StretchImage;

                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] picture = br.ReadBytes((int)fs.Length);
                br.Close();

                kullaniciEkle.ekle(picture);
            }
        }
        bool degisiklik = false;
        string sifre;
        private void btn_kayit_Click(object sender, EventArgs e)
        {
            bilgileri_kontrol_et.bilgi_kontrol();
            sifre = Sha256convertor.sha256hash_(textbox_sifretekrar.Text);
            if (textbox_kullaniciadi.Text != Kullanici_guncelle.Kullanici_ad && !bilgileri_kontrol_et.kullaniciad.Contains(textbox_kullaniciadi.Text))
            {
                Kullanici_guncelle.kullanici_ad_guncelle(textbox_kullaniciadi.Text);
                degisiklik = true;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu","Hata",MessageBoxButtons.OK);
            }
            if (textbox_mail.Text != Kullanici_guncelle.E_mail && !bilgileri_kontrol_et.email.Contains(textbox_mail.Text))
            {
                Kullanici_guncelle.kullanici_email_guncelle(textbox_mail.Text);
                degisiklik = true;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu", "Hata", MessageBoxButtons.OK);
            }
            if (textbox_tel.Text != Kullanici_guncelle.Tel && !bilgileri_kontrol_et.tel.Contains(textbox_tel.Text))
            {
                Kullanici_guncelle.kullanici_tel_guncelle(textbox_tel.Text);
                degisiklik = true;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu", "Hata", MessageBoxButtons.OK);
            }
            if (textbox_sifre.Text == textbox_sifretekrar.Text && textbox_sifretekrar.Text != "" && textbox_sifre.Text != "" && Sha256convertor.sha256hash_(textbox_eskisifre.Text) == Kullanici_guncelle.sifre)
            {
                Kullanici_guncelle.kullanici_sifre_guncelle(sifre);
                degisiklik = true;
            }
            if (degisiklik == true)
            {
                System.Windows.Forms.MessageBox.Show("Başarılı bir şekilde güncellendi", "İşlem Başarılı", MessageBoxButtons.OK);
            }
        }

        private void kullanici_ayarlari_Load(object sender, EventArgs e)
        {
            kullanici_resim.Image = Kullanici_guncelle.kullanici_foto();
            kullanici_resim.SizeMode = PictureBoxSizeMode.StretchImage;

            Kullanici_guncelle.bilgiler();
            textbox_mail.Text = Kullanici_guncelle.E_mail;
            textbox_tel.Text = Kullanici_guncelle.Tel;
            textbox_kullaniciadi.Text = Kullanici_guncelle.Kullanici_ad;
        }

        private void textbox_tel_TextChanged(object sender, EventArgs e)
        {
            if (textbox_tel.Text.Length == 3)
            {
                textbox_tel.Text += "-";
                textbox_tel.SelectionStart = textbox_tel.Text.Length;
            }
            else if (textbox_tel.Text.Length == 7)
            {
                textbox_tel.Text += "-";
                textbox_tel.SelectionStart = textbox_tel.Text.Length;
            }
            else if (textbox_tel.Text.Length == 10)
            {
                textbox_tel.Text += "-";
                textbox_tel.SelectionStart = textbox_tel.Text.Length;
            }
        }
    }
}
