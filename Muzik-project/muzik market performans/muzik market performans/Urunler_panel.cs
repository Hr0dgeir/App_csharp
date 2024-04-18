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
    public partial class Urunler_panel : Form
    {
        public Urunler_panel()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (combobox_tur.SelectedItem != null)
            {
                if (textbox_fiyat.Text != null && harf_kontrol(textbox_fiyat.Text) == true)
                {
                    if (Combobox_sanatcı.SelectedItem != null)
                    {
                        if (textbox_muzikad.Text != null)
                        {
                            if (textbox_tarih.Text != null && harf_kontrol(textbox_tarih.Text) == true)
                            {
                                urun_islemleri.ekle(combobox_tur.SelectedValue.ToString(), Combobox_sanatcı.SelectedValue.ToString(), textbox_tarih.Text, textbox_fiyat.Text, textbox_muzikad.Text);
                            }
                            else
                            {
                                MessageBox.Show("Lütfen müziğin piyasaya sürüldüğü tarihi doğru giriniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Müzik adı boş olamaz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Sanatçı belirtiniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Ürünün fiyatını belirleyiniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Tür Seçiniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void textbox_tarih_TextChanged(object sender, EventArgs e)
        {
            textbox_tarih.MaxLength = 10;
            if (textbox_tarih.Text.Length == 4)
            {
                textbox_tarih.Text += "/";
                textbox_tarih.SelectionStart = textbox_tarih.Text.Length;
            }
            if (textbox_tarih.Text.Length == 7)
            {
                textbox_tarih.Text += "/";
                textbox_tarih.SelectionStart = textbox_tarih.Text.Length;
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

        public bool sayi_kontrol(string veri)
        {
            foreach (char item in veri)
            {
                if (sayilar_liste.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            muzik_islemler frm  = new muzik_islemler();
            frm.ShowDialog();
        }

        private void Urunler_panel_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = urun_islemleri.urunDB();
            
            
            Combobox_sanatcı.DataSource = urun_islemleri.combobox_sanatcıDB();
            Combobox_sanatcı.ValueMember = "Sanatcı";
            Combobox_sanatcı.DisplayMember = "Sanatcı";

            combobox_tur.DataSource = urun_islemleri.combobox_turDB();
            combobox_tur.ValueMember = "Tur";
            combobox_tur.DisplayMember = "Tur";
        }
    }
}
