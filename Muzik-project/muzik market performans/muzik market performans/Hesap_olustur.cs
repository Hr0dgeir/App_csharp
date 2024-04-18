using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzik_market_performans
{
    public partial class Hesap_olustur : Form
    {
        public Hesap_olustur()
        {
            InitializeComponent();
        }

        private void btn_kayit_Click(object sender, EventArgs e)
        {
            bilgileri_kontrol_et.bilgi_kontrol();
            
            if (!String.IsNullOrEmpty(textbox_ad.Text) && sayi_kontrol(textbox_ad.Text) == true)
            {
                if (!String.IsNullOrEmpty(textbox_soyad.Text) && sayi_kontrol(textbox_soyad.Text) == true)
                {
                    if (!String.IsNullOrEmpty(textbox_tel.Text) && textbox_tel.Text.Length == 13 && harf_kontrol(textbox_tel.Text) == true)
                    {
                        if (!String.IsNullOrEmpty(textbox_mail.Text) && textbox_mail.Text.Contains("@gmail.com") || textbox_mail.Text.Contains("@hotmail.com") || textbox_mail.Text.Contains("@outlook.com") || textbox_mail.Text.Contains("@windowslive.com" ))
                        {
                            if (!String.IsNullOrEmpty(textbox_sifre.Text) && textbox_sifre.Text.Length >= 4)
                            {
                                if (!String.IsNullOrEmpty(textbox_kullaniciadi.Text))
                                {
                                    if (bilgileri_kontrol_et.kullaniciad.Contains(textbox_kullaniciadi.Text))
                                    {
                                        MessageBox.Show("Yapmak istediğiniz kullanıcı adı zaten kullanılıyor", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);                                   
                                    }
                                    else
                                    {
                                        if (bilgileri_kontrol_et.tel.Contains(textbox_tel.Text))
                                        {
                                            MessageBox.Show("Bu telefon numarası zaten kullanılıyor", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                        }
                                        else
                                        {
                                            if (bilgileri_kontrol_et.email.Contains(textbox_mail.Text))
                                            {
                                                MessageBox.Show("Bu mail zaten kullanılıyor", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                            }
                                            else
                                            {
                                                if (kullanici_resim.Image == null)
                                                {
                                                    DialogResult cevap = MessageBox.Show("Resim eklemeden devam ediceksiniz eklemek isterseniz Yes butonuna basın daha sonradan resim ekleyebilirsiniz", "Resim", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                                    if (cevap == DialogResult.Yes)
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
                                                            kullaniciEkle.ekle(textbox_kullaniciadi.Text, textbox_sifre.Text, textbox_mail.Text, textbox_tel.Text, textbox_soyad.Text, textbox_ad.Text, picture);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        kullaniciEkle.ekle(textbox_kullaniciadi.Text, textbox_sifre.Text, textbox_mail.Text, textbox_tel.Text, textbox_soyad.Text, textbox_ad.Text);
                                                    }
                                                }
                                            }
                                            
                                        }
                                        
                                    }
                                   
                                }
                                else
                                {
                                    MessageBox.Show("Lütfen Kullanıcı Adınızı kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                if (textbox_sifre.Text.Length < 4)
                                {
                                    MessageBox.Show("Lütfen Şifrenizi kontrol ediniz 4 karakterden az olamaz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show("Lütfen Şifrenizi kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen E-Mail adresinizi kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (textbox_tel.Text.Length < 13)
                        {
                            MessageBox.Show("Lütfen Telefon numaranızı kontrol ediniz 10 karakterden az olamaz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (harf_kontrol(textbox_tel.Text) == false)
                            {
                                MessageBox.Show("Lütfen Telefon numaranızı kontrol ediniz harf içeremez", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show("Lütfen Telefon numaranızı kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Soyadınızı kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Adınızı kontrol ediniz","Uyarı",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }
            
            
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
        char[] harf_liste = {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        char[] sinif_sube_liste = { 'A', 'B', 'C', 'D', 'E' };
        char[] sayilar_liste = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        public bool harf_kontrol(string veri)
        {
            foreach (char item in veri)
            {
                if (harf_liste.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }

        public bool sayi_kontrol(string veri)
        {
            foreach (char item in veri)
            {
                if (sayilar_liste.Contains(item))
                {
                    return false;
                }
            }
            return true;
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
            }
        }
    }
}
