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

namespace muzik_market_performans
{
    public partial class sifremi_unuttum : Form
    {
        public sifremi_unuttum()
        {
            InitializeComponent();
        }
        string global_kullanici_adi;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=muzikMarketDB;Integrated Security=True;TrustServerCertificate=True");
        string global_code;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (true)
            {
                if (true)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Kullanici_Kayit where E_mail like '" + textbox_email.Text + "'", con);
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

        private void sifremi_unuttum_Load(object sender, EventArgs e)
        {

        }

        private void btn_sifre_Click(object sender, EventArgs e)
        {
            if (textbox_code.Text == global_code && textbox_sifre.Text != null)
            {
                string sifre = Sha256convertor.sha256hash_(textbox_sifre.Text);

                con.Open();
                SqlCommand cmd = new SqlCommand("update Kullanici_Kayit set Sifre =@sifre where kullanici_Ad like '%" + global_kullanici_adi + "%' ", con);
                cmd.Parameters.AddWithValue("@Sifre", sifre);
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
