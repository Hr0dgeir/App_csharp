using Guna.UI2.WinForms;
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
    public partial class kullanici_ayarlari : Form
    {
        public kullanici_ayarlari()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");

        List<string> kullanici_adlari_liste = new List<string>();
        List<string> e_mail_liste = new List<string>();
        List<string> tel_liste = new List<string>();

        string global_sifrelenmis_sifre;

        int i = 0;

        private void kullanici_ayarlari_Load(object sender, EventArgs e)
        {
            textbox_sifre.UseSystemPasswordChar = true;
            textbox_sifretekrar.UseSystemPasswordChar = true;
            textbox_eskisifre.UseSystemPasswordChar = true;

            con.Open();
            SqlCommand kullanici_adlari = new SqlCommand("select * from Kullanici_kayit",con);
            SqlDataReader read_ad = kullanici_adlari.ExecuteReader();
            while (read_ad.Read())
            {
                kullanici_adlari_liste.Add(read_ad[1].ToString());
                e_mail_liste.Add(read_ad[6].ToString());
                tel_liste.Add(read_ad[5].ToString());
            }
            con.Close();




            con.Open();
            SqlCommand veriler = new SqlCommand("select * from Kullanici_Kayit where E_mail like'%" + kullanici_değiskenleri.kullanici_email + "%' ", con);
            SqlDataReader read = veriler.ExecuteReader();
            while (read.Read())
            {
                string kullanici_adi = read[1].ToString();
                string sifre = read[2].ToString();
                string tel = read[5].ToString();
                string e_mail = read[6].ToString();

                textbox_mail.Text = e_mail;
                textbox_kullaniciadi.Text = kullanici_adi;
                textbox_tel.Text = tel;
                global_sifrelenmis_sifre = sifre;
            }
            con.Close();

            global_tel_kontrol = textbox_tel.Text;
            global_e_mail_kontrol = textbox_mail.Text;
            global_kullanici_adi_kontrol = textbox_kullaniciadi.Text;

            try
            {
                con.Open();
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
                con.Close();
            }
            catch
            {

            }
        }

        string global_tel_kontrol;
        string global_e_mail_kontrol;
        string global_kullanici_adi_kontrol;
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textbox_sifre.UseSystemPasswordChar = false;
                textbox_sifretekrar.UseSystemPasswordChar = false;
                textbox_eskisifre.UseSystemPasswordChar=false;
            }
            else
            {
                textbox_sifre.UseSystemPasswordChar = true;
                textbox_sifretekrar.UseSystemPasswordChar = true;
                textbox_eskisifre.UseSystemPasswordChar = true;
            }
        }

        private void btn_kayit_Click(object sender, EventArgs e)
        {
            //string hashed_password = Sha256convertor.sha256hash_(txtbox_newpassword2.Text);
            //SqlCommand password = new SqlCommand("update Doctor_Register set Password='" + hashed_password + "' where E_mail like  '%" + Variables.id + "%'", con);
            //password.ExecuteNonQuery();

            if (global_kullanici_adi_kontrol != textbox_kullaniciadi.Text && textbox_kullaniciadi.Text != null && textbox_mail.Text != null && textbox_tel.Text != null)
            {
                if (kullanici_adlari_liste.Contains(textbox_kullaniciadi.Text))
                {
                    MessageBox.Show("Değiştirmek istediğiniz kullanıcı adı kullanılıyor lütfen başka bir tane deneyiniz!","Hata",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    SqlCommand kullanici_adi_update = new SqlCommand("update Kullanici_Kayit set Kullanici_adi='" + textbox_kullaniciadi.Text + "' where E_mail like '%" + kullanici_değiskenleri.kullanici_email + "%' ", con);
                    kullanici_adi_update.ExecuteNonQuery();
                    con.Close();
                    kullanici_adlari_liste.Remove(global_kullanici_adi_kontrol);
                    global_kullanici_adi_kontrol = textbox_kullaniciadi.Text;

                    i++;
                    if (i <= 1)
                    {
                        DialogResult cikis = MessageBox.Show("İşlem başarıyla tamamlandı çıkmak ister misiniz ? ", "Başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (cikis == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    else
                    {

                    }
                }
                
            }
            else
            {
                MessageBox.Show("Bir hata oluştu lütfen bilgilerinizi kontrol ediniz","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if (global_tel_kontrol != textbox_tel.Text)
            {
                if (tel_liste.Contains(textbox_tel.Text))
                {
                    MessageBox.Show("Değiştirmek istediğiniz telefon numarası kullanılıyor lütfen başka bir tane deneyiniz!", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    SqlCommand telefon_update = new SqlCommand("update Kullanici_Kayit set Tel='" + textbox_tel.Text + "' where E_mail like '%" + kullanici_değiskenleri.kullanici_email + "%' ", con);
                    telefon_update.ExecuteNonQuery();
                    con.Close();
                    tel_liste.Remove(global_tel_kontrol);
                    global_tel_kontrol = textbox_tel.Text;
                    i++;
                    if (i <= 1)
                    {
                        DialogResult cikis = MessageBox.Show("İşlem başarıyla tamamlandı çıkmak ister misiniz ? ", "Başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (cikis == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    else
                    {

                    }
                }
            }
            if (global_e_mail_kontrol != textbox_mail.Text)
            {
                if (e_mail_liste.Contains(textbox_mail.Text))
                {
                    MessageBox.Show("Değiştirmek istediğiniz E_mail adı kullanılıyor lütfen başka bir tane deneyiniz!", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    SqlCommand e_mail_update = new SqlCommand("update Kullanici_Kayit set E_mail='" + textbox_mail.Text + "' where E_mail like '%" + kullanici_değiskenleri.kullanici_email + "%' ", con);
                    e_mail_update.ExecuteNonQuery();
                    con.Close();
                    e_mail_liste.Remove(global_e_mail_kontrol);
                    global_e_mail_kontrol = textbox_mail.Text;
                    kullanici_değiskenleri.kullanici_email = textbox_mail.Text;
                    i++;
                    if (i <= 1)
                    {
                        DialogResult cikis = MessageBox.Show("İşlem başarıyla tamamlandı çıkmak ister misiniz ? ", "Başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (cikis == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    else
                    {

                    }
                }
            }
            if (global_sifrelenmis_sifre == Sha256convertor.sha256hash_(textbox_eskisifre.Text))
            {
                if (textbox_sifre.Text == textbox_sifretekrar.Text && textbox_eskisifre.Text != textbox_sifre.Text)
                {
                    con.Open();
                    SqlCommand sifre_degistir = new SqlCommand("update Kullanici_Kayit set sifre ='" +Sha256convertor.sha256hash_(textbox_sifretekrar.Text)+ "' where E_mail like '%"+kullanici_değiskenleri.kullanici_email+"%' ",con);
                    sifre_degistir.ExecuteNonQuery();
                    con.Close();
                    i++;
                    if (i <= 1)
                    {
                        DialogResult cikis = MessageBox.Show("İşlem başarıyla tamamlandı çıkmak ister misiniz ? ", "Başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (cikis == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    else
                    {

                    }
                }
                if (textbox_sifre.Text != textbox_sifretekrar.Text)
                {
                    MessageBox.Show("Yeni şifre aynı olmalıdır lütfen kontrol ediniz ", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                if (textbox_eskisifre.Text == textbox_sifre.Text)
                {
                    MessageBox.Show("Eski şifreyle yeni şifreniz aynı olamaz lütfen kontrol ediniz ", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                
                //MessageBox.Show("Değiştir");
            }
            if (global_sifrelenmis_sifre != Sha256convertor.sha256hash_(textbox_eskisifre.Text) && String.IsNullOrEmpty(textbox_eskisifre.Text))
            {
                //MessageBox.Show("Değiştirme");
            }
            if (!String.IsNullOrEmpty(textbox_eskisifre.Text) && Sha256convertor.sha256hash_(textbox_eskisifre.Text) != global_sifrelenmis_sifre)
            {
                MessageBox.Show("Eski şifreniz hatalı lütfen kontrol ediniz","Uyarı",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }


            if (i > 1)
            {
                DialogResult cikis = MessageBox.Show("İşlemler başarıyla tamamlandı çıkmak ister misiniz ? ", "Başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cikis == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
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

                SqlCommand picture_add = new SqlCommand("update Kullanici_Kayit set picture_foto=@picture where E_mail='" + kullanici_değiskenleri.kullanici_email + "' ", con);
                picture_add.Parameters.AddWithValue("@picture", picture);
                con.Close();
                con.Open();
                picture_add.ExecuteNonQuery();
                MessageBox.Show("succesfully");
                con.Close();
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
    }
}
