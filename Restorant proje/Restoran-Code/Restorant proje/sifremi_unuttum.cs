using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant_proje
{
    public partial class sifremi_unuttum : Form
    {
        public sifremi_unuttum()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");

        private void sifremi_unuttum_Load(object sender, EventArgs e)
        {
            kontrol();
            btn_sifre.Visible = false;
            textbox_code.Visible = false;
            textbox_sifre.Visible = false;
            
        }
        List<string> kullanici_adlari = new List<string>();
        List<string> mailler = new List<string>();

        public void kontrol()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from kullanici_kayit",con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                kullanici_adlari.Add(read[1].ToString());
                mailler.Add(read[6].ToString());
            }
            con.Close();
        }
        string global_kullanici_adi;
        string global_code;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (mailler.Contains(textbox_email.Text))
            {
                if (kullanici_adlari.Contains(textbox_kullaniciadi.Text))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Kullanici_kayit where E_mail like '" + textbox_email.Text + "'", con);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        string mail = read[6].ToString();
                    }

                    string user_mail;
                    

                    Random code = new Random();
                    int password_code = code.Next(0, 1000000);
                    user_mail = textbox_email.Text;
                    global_code = password_code.ToString();
                    try
                    {
                        string fromAddress = "mailiniz buraya";
                        string toAddress = textbox_email.Text;
                        string subject = "Password Forget";
                        string body = global_code;

                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                        smtpClient.Port = 587;
                        smtpClient.Credentials = new NetworkCredential("mailiniz buraya", "kodunuz buraya");
                        smtpClient.EnableSsl = true;

                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress(fromAddress);
                        mailMessage.To.Add(toAddress);
                        mailMessage.Subject = subject;
                        mailMessage.Body = body;

                        smtpClient.Send(mailMessage);

                        global_kullanici_adi = textbox_kullaniciadi.Text;
                        btn_sifre.Visible = true;
                        textbox_sifre.Visible = true;
                        textbox_code.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error: " + ex.Message);
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Böyle bir kullanıcı adı bulunamadı");
                }
            }
            else
            {
                MessageBox.Show("Böyle bir mail bulunamadı");
            }
        }

        private void btn_sifre_Click(object sender, EventArgs e)
        {
            if (textbox_code.Text == global_code && textbox_sifre.Text != null)
            {
                string sifre = Sha256convertor.sha256hash_(textbox_sifre.Text);

                con.Open();
                SqlCommand cmd = new SqlCommand("update Kullanici_kayit set sifre =@sifre where kullanici_adi like '%"+ global_kullanici_adi+"%' ",con);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Başarıyla şifreniz değiştirildi");
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen boşlukları kontrol ediniz");
            }
        }
    }
}
