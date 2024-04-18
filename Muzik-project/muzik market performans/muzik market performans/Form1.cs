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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtbox_sifre.UseSystemPasswordChar = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hesap_olustur frm = new Hesap_olustur();
            frm.ShowDialog();

        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            kullanici_bilgileri.kullaniciad = txtbox_kullaniciadi.Text;
            if (!String.IsNullOrEmpty(txtbox_kullaniciadi.Text))
            {
                if (!String.IsNullOrEmpty(txtbox_sifre.Text))
                {
                    if (txtbox_sifre.Text.Length >= 4)
                    {
                        if (giris.giris_kontrol(txtbox_sifre.Text, txtbox_kullaniciadi.Text) == true)
                        {                          
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Bir hata oluştu","Hata!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }                                             
                    }
                    else
                    {
                        MessageBox.Show("Şifreniz 4 karakterden kısa olamaz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Şifre kısmını doldurunuz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Kullanıcı Adı kısmını doldurunuz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txtbox_sifre.UseSystemPasswordChar = false;
            }
            else
            {
                txtbox_sifre.UseSystemPasswordChar = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifremi_unuttum frm = new sifremi_unuttum();
            frm.ShowDialog();
        }
    }
}
