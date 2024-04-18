using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restorant_proje
{
    public partial class Ana_panel : Form
    {
        public Ana_panel()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
        private void Ana_panel_Load(object sender, EventArgs e)
        {
            //kazanc.kazanc_gunu();

            guna2CircleButton1.Hide();
            guna2CircleButton2.Hide();

            DateTime date_bugun = DateTime.Now.Date;
            string formatted_date = date_bugun.ToString("yyyy-MM-dd").Replace(' ', '_').Replace(".", "_").Replace("-", "_").Replace(":", "_");
            masa_hesap.kazanc_gun_bugun = formatted_date;

            string tablo_isim = "Gunluk_kazanc";
            string sütun_ismi = formatted_date;

            con.Open();
            SqlCommand kontrol = new SqlCommand($"select Count(*) from INFORMATION_SCHEMA.COLUMNS where Table_Name = '{tablo_isim}' and column_name = '{sütun_ismi}'",con);
            int sutun_sayisi = (int)kontrol.ExecuteScalar();

            if (sutun_sayisi > 0)
            {
                //MessageBox.Show("sütun var");
            }
            else
            {               
                SqlCommand tablo_olustur = new SqlCommand($"ALTER TABLE Gunluk_kazanc ADD [{formatted_date}] nvarchar(100)", con);
                tablo_olustur.ExecuteNonQuery();
            }
            con.Close();


            DateTime date = DateTime.Now.Date;
            string formattedDate = date.ToString("yyyy-MM-dd").Replace(' ', '_');
            string formatteddate2 = formattedDate.Replace(".", "_");
            string formatteddate3 = formatteddate2.Replace("-", "_");
            string formatteddate4 = formatteddate3.Replace(":", "_");
            string formatteddate5 = formatteddate4.Replace("-", "_");
            guna2HtmlLabel7.Text = formatteddate5.ToString();
            masa_hesap.kazanc_gun_global = formatteddate5.ToString();

            con.Open();
            try
            {
                
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
                
            }
            catch
            {

            }

            //kullanıcı bilgilerini doldur 
            SqlCommand kullanici_bilgier = new SqlCommand("select * from Kullanici_Kayit where E_mail like'%"+kullanici_değiskenleri.kullanici_email+"%' ",con);
            SqlDataReader read = kullanici_bilgier.ExecuteReader();
            while (read.Read())
            {
                string kullanici_adi = read[3].ToString();
                string kullanici_soyadi = read[4].ToString();
                string yetkisi = read[8].ToString();
                string tam_ad = kullanici_adi + " " + kullanici_soyadi;
                if (kullanici_adi == null)
                {
                    kullanici.Text = "Kullanici adı bulunamadı";
                }
                else if (yetkisi == null)
                {
                    yetki.Text = "Yetkisi bulunamadı";
                }
                else
                {
                    kullanici.Text = tam_ad.ToString();
                    yetki.Text = yetkisi.ToString();
                }           
            }
            read.Close();
            //Kullanıcı bilgilerini dolur 

            //combobox yemek menü doldur
            SqlCommand cmd = new SqlCommand("select * from Yemek_fiyat_liste ",con);
            SqlDataReader read_yemek = cmd.ExecuteReader();
            while (read_yemek.Read())
            {
                for (int i = 0; i < read_yemek.FieldCount; i++)
                {
                    combobox_yemek.Items.Add(read_yemek[i].ToString());
                }
            }
            read_yemek.Close();
            SqlCommand cmd2 = new SqlCommand("select * from icecek_fiyat ", con);
            SqlDataReader read_yemek2 = cmd2.ExecuteReader();
            while (read_yemek2.Read())
            {
                for (int i = 0; i < read_yemek2.FieldCount; i++)
                {
                    combobox_icecek.Items.Add(read_yemek2[i].ToString());
                }
            }
            read_yemek2.Close();
            con.Close();
            //combobox yemek menü doldur
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Yemek_fiyat frm = new Yemek_fiyat();
            frm.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            icecek_fiyat_yonetim frm = new icecek_fiyat_yonetim();
            frm.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (combobox_yemek.SelectedItem != null)
            {
                string eklenecek_urun = combobox_yemek.SelectedItem.ToString();


                string[] veri = eklenecek_urun.Split(':');
                if (veri.Length >= 2)
                {
                    string urun = veri[0];
                    string fiyat = veri[1];
                    listView1.Items.Add(fiyat);
                    listView2.Items.Add(urun);
                    urun = null;
                    fiyat = null;
                }
            }
            else
            {
                MessageBox.Show("Lütfen Seçim yapınız","Uyarı",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }


                     
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (combobox_icecek.SelectedItem != null)
            {
                string eklenecek_urun = combobox_icecek.SelectedItem.ToString();


                string[] veri = eklenecek_urun.Split(':');
                if (veri.Length >= 2)
                {
                    string urun = veri[0];
                    string fiyat = veri[1];


                    

                    string tablo_isim = "icecek_stok";

                    string sutun_isim = urun;

                    

                    con.Open();
                    SqlCommand stok = new SqlCommand($"SELECT TOP 1 {sutun_isim} FROM {tablo_isim}", con);
                    object sonuc = stok.ExecuteScalar();

                    if (sonuc != null)
                    {

                        string guncellenecek_stok = sonuc.ToString();

                        string[] stok_veri = guncellenecek_stok.Split(':');
                        if (stok_veri.Length >= 2)
                        {
                            string urun2 = stok_veri[0];
                            string stok2 = stok_veri[1];

                            int stok_urun = Convert.ToInt32(stok2);
                            int yeni_stok = stok_urun - 1;
                            if (yeni_stok >= 0)
                            {
                                string eklenecek_urun2 = urun2.Replace(" ", "");

                                SqlCommand stok_guncelle = new SqlCommand($"update icecek_stok set {eklenecek_urun2} =@yeni_stok", con);
                                stok_guncelle.Parameters.AddWithValue("@yeni_stok", $"{eklenecek_urun2} : " + yeni_stok);
                                stok_guncelle.ExecuteNonQuery();
                                listView1.Items.Add(fiyat);
                                listView2.Items.Add(urun);
                            }
                            else
                            {
                                MessageBox.Show("Yeterli Miktarda ürün bulunmamaktadır", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            }                      
                        }
                    }
                    con.Close();

                    urun = null;
                    fiyat = null;
                }
            }
            else
            {
                MessageBox.Show("Lütfen Seçim yapınız", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }           
        }
        List<string> urun_fiyatlari = new List<string>();
        List<string> urunler = new List<string>();

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (combobox_masa.SelectedItem != null)
            {
                //SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Restorant_yonetim_proje;Integrated Security=True;TrustServerCertificate=True");
                //con.Open();
                //SqlCommand fiyat = new SqlCommand($"update Yemek_fiyat_liste set {yemek_ad2} =@fiyat", con);
                //fiyat.Parameters.AddWithValue("@fiyat", $"{yemek_ad} : " + yemek_fiyat);
                //fiyat.ExecuteNonQuery();
                //con.Close();

                DialogResult cevap = MessageBox.Show("Siparişi vermekten emin misiniz", "Sipariş", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        urun_fiyatlari.Add(listView1.Items[i].Text);
                    }

                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        urunler.Add(listView2.Items[i].Text);
                    }

                    if (combobox_masa.SelectedItem.ToString() == "1")
                    {
                        for (int i = 0; i < urun_fiyatlari.Count; i++)
                        {
                            masa_hesap.urunler1.Add(urun_fiyatlari[i]);
                        }

                        for (int i = 0; i < urunler.Count; i++)
                        {
                            masa_hesap.urun_liste1.Add(urunler[i]);
                        }
                    }


                    if (combobox_masa.SelectedItem.ToString() == "2")
                    {
                        for (int i = 0; i < urun_fiyatlari.Count; i++)
                        {
                            masa_hesap.urunler2.Add(urun_fiyatlari[i]);
                        }

                        for (int i = 0; i < urunler.Count; i++)
                        {
                            masa_hesap.urun_liste2.Add(urunler[i]);
                        }
                    }

                    if (combobox_masa.SelectedItem.ToString() == "3")
                    {
                        for (int i = 0; i < urun_fiyatlari.Count; i++)
                        {
                            masa_hesap.urunler3.Add(urun_fiyatlari[i]);
                        }

                        for (int i = 0; i < urunler.Count; i++)
                        {
                            masa_hesap.urun_liste3.Add(urunler[i]);
                        }
                    }

                    if (combobox_masa.SelectedItem.ToString() == "4")
                    {
                        for (int i = 0; i < urun_fiyatlari.Count; i++)
                        {
                            masa_hesap.urunler4.Add(urun_fiyatlari[i]);
                        }

                        for (int i = 0; i < urunler.Count; i++)
                        {
                            masa_hesap.urun_liste4.Add(urunler[i]);
                        }
                    }

                    if (combobox_masa.SelectedItem.ToString() == "5")
                    {
                        for (int i = 0; i < urun_fiyatlari.Count; i++)
                        {
                            masa_hesap.urunler5.Add(urun_fiyatlari[i]);
                        }

                        for (int i = 0; i < urunler.Count; i++)
                        {
                            masa_hesap.urun_liste5.Add(urunler[i]);
                        }
                    }

                    if (combobox_masa.SelectedItem.ToString() == "6")
                    {
                        for (int i = 0; i < urun_fiyatlari.Count; i++)
                        {
                            masa_hesap.urunler6.Add(urun_fiyatlari[i]);
                        }

                        for (int i = 0; i < urunler.Count; i++)
                        {
                            masa_hesap.urun_liste6.Add(urunler[i]);
                        }
                    }

                    if (combobox_masa.SelectedItem.ToString() == "7")
                    {
                        for (int i = 0; i < urun_fiyatlari.Count; i++)
                        {
                            masa_hesap.urunler7.Add(urun_fiyatlari[i]);
                        }

                        for (int i = 0; i < urunler.Count; i++)
                        {
                            masa_hesap.urun_liste7.Add(urunler[i]);
                        }
                    }

                    //stok güncelleme

                    List<string> malzeme_ad_liste = new List<string>();
                    List<string> malzeme_stok_liste = new List<string>();
                    con.Open();
                    SqlCommand stok_malzeme_ad = new SqlCommand("select * from icecek_stok",con);
                    SqlDataReader read = stok_malzeme_ad.ExecuteReader();
                    while (read.Read())
                    {
                        for (int i = 1; i < read.FieldCount; i++)
                        {
                            string eklenecek_urun = read[i].ToString();

                            string[] veri = eklenecek_urun.Split(':');
                            if (veri.Length >= 2)
                            {
                                string urun = veri[0];
                                string stok = veri[1];

                                malzeme_ad_liste.Add(urun);
                                malzeme_stok_liste.Add(stok);
                            }
                        }           
                    }
                    con.Close();

                    for (int i = 0; i < malzeme_ad_liste.Count; i++)
                    {
                        malzeme_ad_liste[i] = malzeme_ad_liste[i].Replace(" ", "");
                    }



                    List<string> satilan_urunler = new List<string>();
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        satilan_urunler.Add(listView2.Items[i].Text);
                    }
                    for (int i = 0; i < satilan_urunler.Count; i++)
                    {
                        satilan_urunler[i] = satilan_urunler[i].Replace(" ", "");
                    }
                    
                    int stok_sayisi = 0;

                    for (int i = 0; i < satilan_urunler.Count; i++)
                    {
                        int index = malzeme_ad_liste.IndexOf(satilan_urunler[i]); //stok sayısını bulmak için index kullandık
                        stok_sayisi = Convert.ToInt32(malzeme_stok_liste[i]); // satılan malzemenin stok sayısını bulmak için index kullandık                              
                    }
                    //MessageBox.Show("Eleman bitti");

                    //int index = malzeme_ad_liste.IndexOf(satilan_urunler[0]);
                    //MessageBox.Show(index.ToString());
                    //--------------------

                    urun_fiyatlari.Clear();
                    urunler.Clear();

                    listView1.Items.Clear();
                    listView2.Items.Clear();

                    MessageBox.Show("Sipariş alındı");
                }   
                
            }

            
            if (combobox_masa.SelectedItem == null && combobox_yemek.SelectedItem == null || combobox_masa.SelectedItem == null && combobox_icecek.SelectedItem == null)
            {
                MessageBox.Show("Lütfen gerekli Seçimleri yapınız", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (combobox_masa.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Masa Seçimini yapınız", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }




        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            masalar frm = new masalar();
            frm.ShowDialog();
        }

        private void Ana_panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Ürünü silmekten emin misin", "Sipariş", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                string urun_ad = listView2.Items[global_index].Text;

                string tablo_isim = "icecek_stok";

                con.Open();
                SqlCommand stok = new SqlCommand($"SELECT TOP 1 {urun_ad} FROM {tablo_isim}", con);
                object sonuc = stok.ExecuteScalar();

                string guncellenecek_stok = sonuc.ToString();

                string[] stok_veri = guncellenecek_stok.Split(':');
                if (stok_veri.Length >= 2)
                {
                    string urun2 = stok_veri[0];
                    string stok2 = stok_veri[1];

                    int stok_urun = Convert.ToInt32(stok2);
                    int yeni_stok = stok_urun + 1;

                    string eklenecek_urun = urun2.Replace(" ", "");

                    SqlCommand stok_guncelle = new SqlCommand($"update icecek_stok set {eklenecek_urun} =@yeni_stok", con);
                    stok_guncelle.Parameters.AddWithValue("@yeni_stok", $"{eklenecek_urun} : " + yeni_stok);
                    stok_guncelle.ExecuteNonQuery();
                }
                con.Close();


                listView2.Items.RemoveAt(global_index);
                listView1.Items.RemoveAt(global_index);
            }
        }
        int global_index;
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                int secilen = listView2.SelectedIndices[0];
                global_index = secilen;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            kullanici_ayarlari frm = new kullanici_ayarlari();
            frm.ShowDialog();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            kullanici_değiskenleri.kullanici_email = null;
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void Ana_panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now.Date;
            DateTime birSonrakiGun = date.AddDays(1);
            string formattedNextDate = birSonrakiGun.ToString("yyyy-MM-dd").Replace(' ', '_').Replace(".", "_").Replace("-", "_").Replace(":", "_");
            guna2HtmlLabel7.Text = formattedNextDate.ToString();
            masa_hesap.kazanc_gun_global = formattedNextDate;

            string newdate = guna2HtmlLabel7.Text;

            SqlCommand cmd2 = new SqlCommand($"ALTER TABLE Gunluk_kazanc ADD [{formattedNextDate}] nvarchar(100)", con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();

            guna2CircleButton1.Hide();
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void kullanici_resim_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void yetki_Click(object sender, EventArgs e)
        {

        }

        private void kullanici_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now.Date;
            string formatted_date = date.ToString("yyyy-MM-dd").Replace(' ', '_').Replace(".", "_").Replace("-", "_").Replace(":", "_");
            masa_hesap.kazanc_gun_bugun = formatted_date;

            SqlCommand cmd2 = new SqlCommand($"ALTER TABLE Gunluk_kazanc ADD [{formatted_date}] nvarchar(100)", con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();

            guna2CircleButton1.Hide();
        }
    }
}
