using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Restorant_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbox_kullaniciadi.Text))
            {
                if (!String.IsNullOrEmpty(txtbox_sifre.Text))
                {
                    if (txtbox_sifre.Text.Length >=4)
                    {
                        if (giris.giris_kontrol(txtbox_sifre.Text, txtbox_kullaniciadi.Text) == true)
                        {
                            giris.kullanici_bilgi_al(txtbox_kullaniciadi.Text);
                            this.Hide();
                        }
                        else
                        {

                        }
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("Şifreniz 4 karakterden kısa olamaz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen kullanıcı adı kısmını doldurunuz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen kullanıcı adı kısmını doldurunuz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hesapolustur frm = new hesapolustur();
            frm.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtbox_sifre.UseSystemPasswordChar = true;
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifremi_unuttum frm = new sifremi_unuttum();
            frm.ShowDialog();
        }
    }
}
