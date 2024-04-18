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
    public partial class icecek_fiyat_yonetim : Form
    {
        public icecek_fiyat_yonetim()
        {
            InitializeComponent();
        }

        private void icecek_fiyat_yonetim_Load(object sender, EventArgs e)
        {
            yenile();
        }
        public void yenile()
        {
            dataGridView1.DataSource = icecek_fiyat.data_grid_yenile();
            dataGridView2.DataSource = icecek_fiyat.data_grid2_yenile();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //icecek_fiyat.urun_kontrol(textbox_urunad.Text,textbox_urunfiyat.Text);

            if (!String.IsNullOrEmpty(textbox_urunad.Text) && !textbox_urunfiyat.Text.Contains(" ") && !textbox_urunstok.Text.Contains(" ") && !textbox_urunstok.Text.StartsWith("-") && !textbox_urunfiyat.Text.StartsWith("-"))
            {
                if (icecek_fiyat.urun_ekle(textbox_urunad.Text, textbox_urunfiyat.Text, textbox_urunstok.Text) == true)
                {
                    MessageBox.Show("Başarılı bir şekilde eklendi","İşlem başarılı",MessageBoxButtons.OK);
                    yenile();
                }
                else
                {
                    MessageBox.Show("Hata oluştu", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }


            }
            else
            {
                MessageBox.Show("Lütfen Eklemek istediğiniz ürünün Bilgilerini kontrol ediniz","Uyarı",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(textbox_urunadguncelle.Text) && !String.IsNullOrEmpty(textbox_urunfiyatguncelle.Text) && !textbox_urunfiyatguncelle.Text.Contains(" ") && textbox_urunfiyatguncelle.Text.StartsWith("-") && textbox_urun_stok_guncelle.Text.StartsWith("-"))
            {                                
                yenile();
                if (textbox_urun_stok_guncelle.Text.StartsWith(""))
                {
                    icecek_fiyat.urun_guncelle(textbox_urunfiyatguncelle.Text, textbox_urunadguncelle.Text);
                    icecek_fiyat.urun_stok_guncelle(textbox_urunadguncelle.Text, textbox_urun_stok_guncelle.Text);
                    yenile();
                }
                if (textbox_urun_stok_guncelle.Text.StartsWith("+"))
                {
                    textbox_urun_stok_guncelle.Text = textbox_urun_stok_guncelle.Text.TrimStart();
                    int eklenecek_urun = Convert.ToInt32(textbox_urun_stok_guncelle.Text);
                    global_stok += eklenecek_urun;
                    string eklenecek_miktar = global_stok.ToString();
                    icecek_fiyat.urun_stok_guncelle(textbox_urunadguncelle.Text,eklenecek_miktar);
                    yenile();
                }
                if (textbox_urun_stok_guncelle.Text.StartsWith("-"))
                {
                    textbox_urun_stok_guncelle.Text = textbox_urun_stok_guncelle.Text.TrimStart();
                    int çıkartılacak_urun = Convert.ToInt32(textbox_urun_stok_guncelle.Text);
                    global_stok = global_stok + çıkartılacak_urun;
                    string çıkartılacak_miktar = global_stok.ToString();
                    icecek_fiyat.urun_stok_guncelle(textbox_urunadguncelle.Text, çıkartılacak_miktar);
                    yenile();
                }
                textbox_urunadguncelle.Text = "";
                textbox_urunfiyatguncelle.Text = "";
                textbox_yemeksil.Text = "";
                textbox_urun_stok_guncelle.Text = "";
            }
            else
            {
                MessageBox.Show("Lütfen gerekli yerleri doldurunuz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                textbox_urunadguncelle.Text = selectedCell.OwningColumn.HeaderText;
                textbox_urunfiyatguncelle.Text = selectedCell.Value.ToString();
                textbox_yemeksil.Text = selectedCell.OwningColumn.HeaderText;
                string sutun_isim = selectedCell.OwningColumn.HeaderText;

                string eklenecek_urun = textbox_urunfiyatguncelle.Text;

                string[] veri = eklenecek_urun.Split(':');
                if (veri.Length >= 2)
                {
                    string urun = veri[0];
                    string fiyat = veri[1];

                    textbox_urunfiyatguncelle.Text = fiyat;
                }

                
                
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");

                string tablo_isim = "icecek_stok";

                con.Open();
                SqlCommand stok = new SqlCommand($"SELECT TOP 1 {sutun_isim} FROM {tablo_isim}", con);
                object sonuc = stok.ExecuteScalar();

                if (sonuc != null)
                {

                    string guncellenecek_stok = sonuc.ToString();

                    string[] stok_veri = guncellenecek_stok.Split(':');
                    if (stok_veri.Length >= 2)
                    {
                        string urun = stok_veri[0];
                        string stok2 = stok_veri[1];
                        textbox_urun_stok_guncelle.Text = stok2;
                    }

                }
                else
                {
                    MessageBox.Show("Test");
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textbox_yemeksil.Text))
            {
                icecek_fiyat.urun_sil(textbox_yemeksil.Text);
                yenile();
            }
            else
            {
                MessageBox.Show("Lütfen gerekli yerleri doldurunuz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textbox_urunfiyatguncelle_TextChanged(object sender, EventArgs e)
        {
            if (textbox_urunfiyatguncelle.Text.StartsWith(" "))
            {
                textbox_urunfiyatguncelle.Text = textbox_urunfiyatguncelle.Text.TrimStart();
            }
        }

        private void textbox_urunadguncelle_TextChanged(object sender, EventArgs e)
        {
            if (textbox_urunadguncelle.Text.StartsWith(" "))
            {
                textbox_urunadguncelle.Text = textbox_urunadguncelle.Text.TrimStart();
                
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            //{
            //    DataGridViewCell selectedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    textbox_urunfiyatguncelle.Text = selectedCell.Value.ToString();
            //}
        }
        int global_stok;
        private void textbox_urun_stok_guncelle_TextChanged(object sender, EventArgs e)
        {
            if (textbox_urun_stok_guncelle.Text.StartsWith(" "))
            {
                textbox_urun_stok_guncelle.Text = textbox_urun_stok_guncelle.Text.TrimStart();
                global_stok = Convert.ToInt32(textbox_urun_stok_guncelle.Text);
            }
        }
    }
}
