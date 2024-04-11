using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant_proje
{
    public partial class masalar : Form
    {
        public masalar()
        {
            InitializeComponent();
        }

        private void masalar_Load(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            masa_hesap.secilen_masa = "1";
            Masa_siparis_durumu frm = new Masa_siparis_durumu();
            frm.ShowDialog();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            masa_hesap.secilen_masa = "2";
            Masa_siparis_durumu frm = new Masa_siparis_durumu();
            frm.ShowDialog();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            masa_hesap.secilen_masa = "3";
            Masa_siparis_durumu frm = new Masa_siparis_durumu();
            frm.ShowDialog();
        }

        private void guna2CircleButton6_Click(object sender, EventArgs e)
        {
            masa_hesap.secilen_masa = "6";
            Masa_siparis_durumu frm = new Masa_siparis_durumu();
            frm.ShowDialog();
        }

        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            masa_hesap.secilen_masa = "5";
            Masa_siparis_durumu frm = new Masa_siparis_durumu();
            frm.ShowDialog();
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            masa_hesap.secilen_masa = "4";
            Masa_siparis_durumu frm = new Masa_siparis_durumu();
            frm.ShowDialog();
        }

        private void guna2CircleButton7_Click(object sender, EventArgs e)
        {
            masa_hesap.secilen_masa = "7";
            Masa_siparis_durumu frm = new Masa_siparis_durumu();
            frm.ShowDialog();
        }
    }
}
