using Guna.UI2.WinForms;
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

namespace Restorant_proje
{
    public partial class Yemek_fiyat : Form
    {
        public Yemek_fiyat()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
        private void Yemek_fiyat_Load(object sender, EventArgs e)
        {
            yenile();
        }

        public void yenile()
        {
            dataGridView1.DataSource = yemek_ekle.yemek_datagrid();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            yemek_ekle.urun_kontrol(textbox_yemekad.Text,textbox_yemekfiyat.Text);
            
            if (textbox_yemekfiyat.Text != null && textbox_yemekad.Text != null && !textbox_yemekfiyat.Text.Contains(" ") && !textbox_yemekfiyat.Text.StartsWith("-"))
            {
                try
                {
                    string yemek_ad = textbox_yemekad.Text;
                    string yemek_ad2 = yemek_ad + "_Fiyat";
                    yemek_ekle.yeni_yemek_ekle(textbox_yemekfiyat.Text,yemek_ad2,yemek_ad);
                    yenile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }
            else
            {
                MessageBox.Show("Lütfen yemek adı ve fiyatını doldurunuz","Uyarı",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textbox_guncellead.Text) && !String.IsNullOrEmpty(textbox_guncellefiyat.Text) && !textbox_guncellefiyat.Text.Contains(" ") && !textbox_guncellefiyat.Text.StartsWith("-"))
            {
                string yemek_ad = textbox_guncellead.Text;
                if (textbox_guncellefiyat.Text.StartsWith(""))
                {
                    yemek_ekle.yemek_guncelle(textbox_guncellefiyat.Text, yemek_ad);
                }
                if (textbox_guncellefiyat.Text.StartsWith("+"))
                {
                    textbox_guncellefiyat.Text = textbox_guncellefiyat.Text.TrimStart();
                    int arttıralacak_miktar = Convert.ToInt32(textbox_guncellefiyat.Text);
                    global_fiyat = global_fiyat + arttıralacak_miktar;
                    string eklenecek_yenimiktar = global_fiyat.ToString();
                    yemek_ekle.yemek_guncelle(eklenecek_yenimiktar, yemek_ad);
                }
                if (textbox_guncellefiyat.Text.StartsWith("-"))
                {
                    textbox_guncellefiyat.Text = textbox_guncellefiyat.Text.TrimStart();
                    int arttıralacak_miktar = Convert.ToInt32(textbox_guncellefiyat.Text);
                    global_fiyat = global_fiyat + arttıralacak_miktar;
                    string eklenecek_yenimiktar = global_fiyat.ToString();
                    yemek_ekle.yemek_guncelle(eklenecek_yenimiktar, yemek_ad);
                }               
                textbox_guncellefiyat.Text = "";
                textbox_guncellead.Text = "";
                textbox_yemeksil.Text = "";
                yenile();
            }
            else
            {
                if (textbox_guncellefiyat.Text.StartsWith("-"))
                {
                    MessageBox.Show("Yemek fiyati negatif olamaz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lütfen güncellenecek yemekleri seçiniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                textbox_guncellead.Text = selectedCell.OwningColumn.HeaderText;
                textbox_guncellefiyat.Text = selectedCell.Value.ToString();
                textbox_yemeksil.Text = selectedCell.OwningColumn.HeaderText;

                string eklenecek_urun = textbox_guncellefiyat.Text;

                string[] veri = eklenecek_urun.Split(':');
                if (veri.Length >= 2)
                {
                    string urun = veri[0];
                    string fiyat = veri[1];

                    textbox_guncellefiyat.Text = fiyat;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textbox_yemeksil.Text))
            {
                string yemek_ad = textbox_yemeksil.Text;
                yemek_ekle.yemek_sil(yemek_ad);
                yenile();
            }
            else
            {
                MessageBox.Show("Lütfen silinecek yemeği seçiniz");
            }
        }
        int global_fiyat;
        private void textbox_guncellefiyat_TextChanged(object sender, EventArgs e)
        {
            if (textbox_guncellefiyat.Text.StartsWith(" "))
            {
                textbox_guncellefiyat.Text = textbox_guncellefiyat.Text.TrimStart();
                global_fiyat = Convert.ToInt32(textbox_guncellefiyat.Text);
            }
        }

        private void textbox_guncellead_TextChanged(object sender, EventArgs e)
        {
            if (textbox_guncellead.Text.StartsWith(" "))
            {
                textbox_guncellead.Text = textbox_guncellead.Text.TrimStart();
            }
        }
    }
}
