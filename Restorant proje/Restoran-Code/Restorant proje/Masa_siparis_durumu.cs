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

namespace Restorant_proje
{
    public partial class Masa_siparis_durumu : Form
    {
        public Masa_siparis_durumu()
        {
            InitializeComponent();
        }

        private void Masa_siparis_durumu_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = masa_hesap.secilen_masa.ToString();
            if (masa_hesap.secilen_masa == "1")
            {
                foreach (string item in masa_hesap.urunler1)
                {
                    listView2.Items.Add(item);
                }
                foreach (string item in masa_hesap.urun_liste1)
                {
                    listView1.Items.Add(item);
                }
            }
            if (masa_hesap.secilen_masa == "2")
            {
                foreach (string item in masa_hesap.urunler2)
                {
                    listView2.Items.Add(item);
                }
                foreach (string item in masa_hesap.urun_liste2)
                {
                    listView1.Items.Add(item);
                }
            }
            if (masa_hesap.secilen_masa == "3")
            {
                foreach (string item in masa_hesap.urunler3)
                {
                    listView2.Items.Add(item);
                }
                foreach (string item in masa_hesap.urun_liste3)
                {
                    listView1.Items.Add(item);
                }
            }
            if (masa_hesap.secilen_masa == "4")
            {
                foreach (string item in masa_hesap.urunler4)
                {
                    listView2.Items.Add(item);
                }
                foreach (string item in masa_hesap.urun_liste4)
                {
                    listView1.Items.Add(item);
                }
            }
            if (masa_hesap.secilen_masa == "5")
            {
                foreach (string item in masa_hesap.urunler5)
                {
                    listView2.Items.Add(item);
                }
                foreach (string item in masa_hesap.urun_liste5)
                {
                    listView1.Items.Add(item);
                }
            }
            if (masa_hesap.secilen_masa == "6")
            {
                foreach (string item in masa_hesap.urunler6)
                {
                    listView2.Items.Add(item);
                }
                foreach (string item in masa_hesap.urun_liste6)
                {
                    listView1.Items.Add(item);
                }
            }
            if (masa_hesap.secilen_masa == "7")
            {
                foreach (string item in masa_hesap.urunler7)
                {
                    listView2.Items.Add(item);
                }
                foreach (string item in masa_hesap.urun_liste7)
                {
                    listView1.Items.Add(item);
                }
            }

            int toplam_fiyat = 0;
            if (listView2.Items.Count != 0)
            {
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    string fiyat = listView2.Items[i].Text;

                    toplam_fiyat += Convert.ToInt32(fiyat);
                }
                guna2HtmlLabel6.Text = toplam_fiyat.ToString();
            }
            else
            {
                MessageBox.Show("Bu masada sipariş bulunmamaktadır","Bilgilendirme",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                this.Close();
            }
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"insert into Gunluk_kazanc ([{masa_hesap.kazanc_gun_bugun}]) values (@kazanc)",con);
            cmd.Parameters.AddWithValue("@kazanc",guna2HtmlLabel6.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            if (masa_hesap.secilen_masa == "1")
            {
                DialogResult cevap = MessageBox.Show("Siparişi kapatmaktan emin misin","Sipariş",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    masa_hesap.urunler1.Clear();
                    masa_hesap.urun_liste1.Clear();
                    this.Close();
                }
            }
            if (masa_hesap.secilen_masa == "2")
            {
                DialogResult cevap = MessageBox.Show("Siparişi kapatmaktan emin misin", "Sipariş", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    masa_hesap.urunler2.Clear();
                    masa_hesap.urun_liste2.Clear();
                    this.Close();
                }
            }
            if (masa_hesap.secilen_masa == "3")
            {
                DialogResult cevap = MessageBox.Show("Siparişi kapatmaktan emin misin", "Sipariş", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    masa_hesap.urunler3.Clear();
                    masa_hesap.urun_liste3.Clear();
                    this.Close();
                }
            }
            if (masa_hesap.secilen_masa == "4")
            {
                DialogResult cevap = MessageBox.Show("Siparişi kapatmaktan emin misin", "Sipariş", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    masa_hesap.urunler4.Clear();
                    masa_hesap.urun_liste4.Clear();
                    this.Close();
                }
            }
            if (masa_hesap.secilen_masa == "5")
            {
                DialogResult cevap = MessageBox.Show("Siparişi kapatmaktan emin misin", "Sipariş", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    masa_hesap.urunler5.Clear();
                    masa_hesap.urun_liste5.Clear();
                    this.Close();
                }
            }
            if (masa_hesap.secilen_masa == "6")
            {
                DialogResult cevap = MessageBox.Show("Siparişi kapatmaktan emin misin", "Sipariş", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    masa_hesap.urunler6.Clear();
                    masa_hesap.urun_liste6.Clear();
                    this.Close();
                }
            }
            if (masa_hesap.secilen_masa == "7")
            {
                DialogResult cevap = MessageBox.Show("Siparişi kapatmaktan emin misin", "Sipariş", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    masa_hesap.urunler7.Clear();
                    masa_hesap.urun_liste7.Clear();
                    this.Close();
                }
            }
        }
    }
}
