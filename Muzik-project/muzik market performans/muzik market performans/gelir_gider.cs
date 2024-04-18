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
    public partial class gelir_gider : Form
    {
        public gelir_gider()
        {
            InitializeComponent();
        }

        private void gelir_gider_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = gelir_gider_islemler.satilan_urunler();
        }
    }
}
