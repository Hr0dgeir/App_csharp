using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muzik_market_performans
{
    public partial class muzik_islemler : Form
    {
        public muzik_islemler()
        {
            InitializeComponent();
        }
        bool islem = true;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textbox_sanatci.Text))
            {
                if (!String.IsNullOrEmpty(textbox_tur.Text))
                {
                    muzik.sanatcı_ekle(textbox_tur.Text,textbox_sanatci.Text);
                    textbox_tur.Text = "";
                    textbox_sanatci.Text = "";
                }
                else
                {
                    MessageBox.Show("Lütfen sanatçı müzik türünü giriniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen sanatçı ismini giriniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            muzik.tur_ekle(textbox_tur2.Text + "Müzik");
            textbox_tur2.Text = "";
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_islem.SelectedItem.ToString() == "Tür Güncelle")
            {
                guna2DataGridView1.DataSource =  muzik.tur_liste();
                islem = true;
            }
            else
            {
                guna2DataGridView1.DataSource = muzik.sanatcı_liste();
                islem = false;
            }
        }
        string id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (islem == false)
            {
                textbox_sanatcıtur.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
                textbox_sanatcıad.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
                textbox_sanatcıad.Visible = true;
            }
            if (islem == true)
            {
                textbox_sanatcıtur.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
                textbox_sanatcıad.Visible = false;
            }

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (islem == true)
            {
                if (id != null || id != "")
                {
                    muzik.tur_guncelle(textbox_sanatcıtur.Text + " Müzik", id);
                    guna2DataGridView1.DataSource = muzik.tur_liste();
                    textbox_sanatcıtur.Text = "";
                }
                else
                {
                    MessageBox.Show("Seçim yapmadınız", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            if (islem == false)
            {
                if (id != null || id != "")
                {
                    muzik.sanatcı_guncelle(id,textbox_sanatcıad.Text,textbox_sanatcıtur.Text);
                    guna2DataGridView1.DataSource = muzik.sanatcı_liste();
                }
                else
                {
                    MessageBox.Show("Seçim yapmadınız", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void muzik_islemler_Load(object sender, EventArgs e)
        {
            textbox_sanatcıad.Visible = false;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (islem == true)
            {
                if (id != null || id != "")
                {
                    muzik.tur_sil(id);
                    guna2DataGridView1.DataSource = muzik.tur_liste();
                    textbox_sanatcıtur.Text = "";
                    textbox_sanatcıad.Text = "";
                }
                else
                {
                    MessageBox.Show("Seçim yapmadınız", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            if (islem == false)
            {
                if (id != null || id != "")
                {
                    muzik.sanatcı_sil(id);
                    guna2DataGridView1.DataSource = muzik.sanatcı_liste();

                }
                else
                {
                    MessageBox.Show("Seçim yapmadınız", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
