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
    public partial class hesapolustur : Form
    {
        public hesapolustur()
        {
            InitializeComponent();
        }



        private void txtbox_ad_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void btn_kayit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textbox_kullaniciadi.Text))
            {
                if (!String.IsNullOrEmpty(textbox_sifre.Text))
                {
                    if (textbox_sifre.Text.Length >=4)
                    {
                        if (!String.IsNullOrEmpty(textbox_ad.Text))
                        {
                            if (!String.IsNullOrEmpty(textbox_soyad.Text))
                            {
                                if (!String.IsNullOrEmpty(textbox_tel.Text))
                                {
                                    if (textbox_tel.Text.Length >= 13)
                                    {
                                        if (harf_kontrol(textbox_tel.Text) == true)
                                        {
                                            if (textbox_mail.Text.Contains("@gmail.com") || textbox_mail.Text.Contains("@hotmail.com") || textbox_mail.Text.Contains("@windowslive.com") || textbox_mail.Text.Contains("@outlook.com"))
                                            {
                                                if (textbox_kullaniciadi.Text != textbox_ad.Text)
                                                {
                                                    if (combobox_yetki.SelectedItem != null)
                                                    {
                                                        if (textbox_ad.Text == "0000000125478")
                                                        {
                                                            
                                                        }
                                                        else
                                                        {
                                                            //DialogResult bilgilendirme = MessageBox.Show("Resim eklemeden devam ediceksiniz resim eklemek isterseniz Yes tuşuna basın daha sonradan resim ekleyebilirsiniz", "uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                                            //if (bilgilendirme == DialogResult.Yes)
                                                            //{

                                                            //}
                                                            //else
                                                            //{


                                                            //}
                                                            if (kullanici_adi_liste.Contains(textbox_kullaniciadi.Text))
                                                            {
                                                                MessageBox.Show("Bu kullanıcı adı kullanılıyor !", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                                            }
                                                            else
                                                            {
                                                                if (tel_liste.Contains(textbox_tel.Text))
                                                                {
                                                                    MessageBox.Show("Bu telefon numarası kullanılıyor !", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                                                }
                                                                else
                                                                {
                                                                    if (e_mail_liste.Contains(textbox_mail.Text))
                                                                    {
                                                                        MessageBox.Show("Bu mail kullanılıyor !", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (isim_kontrol(textbox_ad.Text) != true)
                                                                        {
                                                                            if (isim_kontrol(textbox_soyad.Text) != true)
                                                                            {
                                                                                if (kullanici_resim.Image != null)
                                                                                {
                                                                                    //OpenFileDialog ofd = new OpenFileDialog();
                                                                                    //ofd.Title = "Please Sellect your picture";
                                                                                    //if (ofd.ShowDialog() == DialogResult.OK)
                                                                                    //{
                                                                                    //    kullanici_resim.Image = null;
                                                                                    //    string dosya_yolu = ofd.FileName;
                                                                                    //    kullanici_resim.Image = Image.FromFile(dosya_yolu);
                                                                                    //    kullanici_resim.SizeMode = PictureBoxSizeMode.StretchImage;

                                                                                    //    FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                                                                                    //    BinaryReader br = new BinaryReader(fs);
                                                                                    //    byte[] picture = br.ReadBytes((int)fs.Length);
                                                                                    //    br.Close();


                                                                                    //}

                                                                                    con.Open();
                                                                                    string sifrelenmis_sifre = Sha256convertor.sha256hash_(textbox_sifre.Text);
                                                                                    kullanici_ekle.kullanici_bilgileri(textbox_kullaniciadi.Text, sifrelenmis_sifre, textbox_ad.Text, textbox_soyad.Text, textbox_mail.Text, textbox_tel.Text,global_picture_yol ,combobox_yetki.SelectedItem.ToString());
                                                                                    MessageBox.Show("Giriş yapılıyor");
                                                                                    this.Close();
                                                                                    con.Close();


                                                                                }
                                                                                else
                                                                                {
                                                                                    DialogResult bilgilendirme = MessageBox.Show("Resim eklemeden devam ediceksiniz resim eklemek isterseniz Yes tuşuna basın daha sonradan resim ekleyebilirsiniz", "uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                                                                    if (bilgilendirme == DialogResult.Yes)
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


                                                                                            con.Open();
                                                                                            string sifrelenmis_sifre = Sha256convertor.sha256hash_(textbox_sifre.Text);
                                                                                            kullanici_ekle.kullanici_bilgileri(textbox_kullaniciadi.Text, sifrelenmis_sifre, textbox_ad.Text, textbox_soyad.Text, textbox_mail.Text, textbox_tel.Text,picture ,combobox_yetki.SelectedItem.ToString());
                                                                                            this.Close();
                                                                                            con.Close();

                                                                                            MessageBox.Show("oldu");
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        string sifrelenmis_sifre = Sha256convertor.sha256hash_(textbox_sifre.Text);
                                                                                        kullanici_ekle.kullanici_bilgileri(textbox_kullaniciadi.Text, sifrelenmis_sifre, textbox_ad.Text, textbox_soyad.Text, textbox_mail.Text, textbox_tel.Text, combobox_yetki.SelectedItem.ToString());
                                                                                        MessageBox.Show("Giriş yapılıyor");
                                                                                        this.Close();
                                                                                    }
                                                                                    
                                                                                }
                                                                                

                                                                            }
                                                                            else
                                                                            {
                                                                                MessageBox.Show("Soyadınız sayı içeremez!", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                                                                            }

                                                                        }
                                                                        else
                                                                        {
                                                                            MessageBox.Show("İsminiz sayı içeremez!", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                                                        }

                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Yetki alanı boş olamaz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                                    }                                                  
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Kullanıcı adınız ve adınız aynı olamaz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Mailiniz @gmail.com, @hotmail.com, @outlook.com, @windowslive.com'dan biri olmalıdır", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Lütfen Telefon numaranız harf içeremez", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Lütfen Telefon numaranızı kontrol ediniz 13 karakterden az olamaz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Lütfen Telefon numaranızı kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Lütfen Soyadınızı kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Adınızı kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen şifrenizi kontrol ediniz en az 4 karakterden oluşabilir", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen şifre kısmını kontrol ediniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen kullanıcı adı kısmını doldurunuz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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
        public bool isim_kontrol(string veri)
        {
            foreach(char item in veri)
            {
                if (sayilar_liste.Contains(item))
                {
                    return false;
                }
            }
            return false;
        }
        List<string> kullanici_adi_liste = new List<string>();
        List<string> tel_liste = new List<string>();
        List<string> e_mail_liste = new List<string>();
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");

        private void hesapolustur_Load(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Kullanici_Kayit",con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                string kullanici_adi = read[1].ToString();
                string tel = read[5].ToString();
                string e_mail = read[6].ToString();

                e_mail_liste.Add(e_mail);
                tel_liste.Add(tel);
                kullanici_adi_liste.Add(kullanici_adi);
            }
            con.Close();
        }

        private void textbox_kullaniciadi_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_mail_TextChanged(object sender, EventArgs e)
        {

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
        byte[] global_picture_yol;
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

                global_picture_yol = picture;
            }
        }
    }
}
