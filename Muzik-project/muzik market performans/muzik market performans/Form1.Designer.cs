namespace muzik_market_performans
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbox_sifre = new Guna.UI2.WinForms.Guna2TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn_giris = new Guna.UI2.WinForms.Guna2Button();
            this.txtbox_kullaniciadi = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // txtbox_sifre
            // 
            this.txtbox_sifre.AutoRoundedCorners = true;
            this.txtbox_sifre.BorderColor = System.Drawing.Color.Black;
            this.txtbox_sifre.BorderRadius = 17;
            this.txtbox_sifre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbox_sifre.DefaultText = "";
            this.txtbox_sifre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbox_sifre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbox_sifre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbox_sifre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbox_sifre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbox_sifre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbox_sifre.ForeColor = System.Drawing.Color.Black;
            this.txtbox_sifre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbox_sifre.Location = new System.Drawing.Point(89, 130);
            this.txtbox_sifre.Name = "txtbox_sifre";
            this.txtbox_sifre.PasswordChar = '\0';
            this.txtbox_sifre.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtbox_sifre.PlaceholderText = "Şifre";
            this.txtbox_sifre.SelectedText = "";
            this.txtbox_sifre.Size = new System.Drawing.Size(200, 36);
            this.txtbox_sifre.TabIndex = 37;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox2.ForeColor = System.Drawing.Color.Black;
            this.checkBox2.Location = new System.Drawing.Point(154, 172);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(135, 20);
            this.checkBox2.TabIndex = 36;
            this.checkBox2.Text = "Show Password";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(194, 249);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(110, 17);
            this.linkLabel2.TabIndex = 35;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Şifremi unuttum";
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(12, 522);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(125, 22);
            this.linkLabel1.TabIndex = 34;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Hesap Oluştur";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(15, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(362, 38);
            this.guna2HtmlLabel1.TabIndex = 33;
            this.guna2HtmlLabel1.Text = "Müzik Marketi Giriş Paneli";
            // 
            // btn_giris
            // 
            this.btn_giris.AutoRoundedCorners = true;
            this.btn_giris.BorderRadius = 17;
            this.btn_giris.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_giris.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_giris.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_giris.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_giris.FillColor = System.Drawing.Color.White;
            this.btn_giris.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_giris.ForeColor = System.Drawing.Color.Black;
            this.btn_giris.Location = new System.Drawing.Point(89, 198);
            this.btn_giris.Name = "btn_giris";
            this.btn_giris.Size = new System.Drawing.Size(200, 36);
            this.btn_giris.TabIndex = 32;
            this.btn_giris.Text = "Giriş Yap";
            this.btn_giris.Click += new System.EventHandler(this.btn_giris_Click);
            // 
            // txtbox_kullaniciadi
            // 
            this.txtbox_kullaniciadi.AutoRoundedCorners = true;
            this.txtbox_kullaniciadi.BorderColor = System.Drawing.Color.Black;
            this.txtbox_kullaniciadi.BorderRadius = 17;
            this.txtbox_kullaniciadi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbox_kullaniciadi.DefaultText = "";
            this.txtbox_kullaniciadi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbox_kullaniciadi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbox_kullaniciadi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbox_kullaniciadi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbox_kullaniciadi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbox_kullaniciadi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbox_kullaniciadi.ForeColor = System.Drawing.Color.Black;
            this.txtbox_kullaniciadi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbox_kullaniciadi.Location = new System.Drawing.Point(89, 88);
            this.txtbox_kullaniciadi.Name = "txtbox_kullaniciadi";
            this.txtbox_kullaniciadi.PasswordChar = '\0';
            this.txtbox_kullaniciadi.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtbox_kullaniciadi.PlaceholderText = "Kullanıcı Adı";
            this.txtbox_kullaniciadi.SelectedText = "";
            this.txtbox_kullaniciadi.Size = new System.Drawing.Size(200, 36);
            this.txtbox_kullaniciadi.TabIndex = 31;
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_giris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 553);
            this.Controls.Add(this.txtbox_sifre);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.btn_giris);
            this.Controls.Add(this.txtbox_kullaniciadi);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtbox_sifre;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btn_giris;
        private Guna.UI2.WinForms.Guna2TextBox txtbox_kullaniciadi;
    }
}

