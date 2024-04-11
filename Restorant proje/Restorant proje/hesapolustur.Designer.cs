namespace Restorant_proje
{
    partial class hesapolustur
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_kayit = new Guna.UI2.WinForms.Guna2Button();
            this.textbox_kullaniciadi = new Guna.UI2.WinForms.Guna2TextBox();
            this.textbox_sifre = new Guna.UI2.WinForms.Guna2TextBox();
            this.textbox_ad = new Guna.UI2.WinForms.Guna2TextBox();
            this.textbox_soyad = new Guna.UI2.WinForms.Guna2TextBox();
            this.textbox_tel = new Guna.UI2.WinForms.Guna2TextBox();
            this.textbox_mail = new Guna.UI2.WinForms.Guna2TextBox();
            this.kullanici_resim = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.combobox_yetki = new Guna.UI2.WinForms.Guna2ComboBox();
            this.button_resimekle = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.kullanici_resim)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_kayit
            // 
            this.btn_kayit.AutoRoundedCorners = true;
            this.btn_kayit.BorderRadius = 15;
            this.btn_kayit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_kayit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_kayit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_kayit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_kayit.FillColor = System.Drawing.Color.White;
            this.btn_kayit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_kayit.ForeColor = System.Drawing.Color.Black;
            this.btn_kayit.Location = new System.Drawing.Point(80, 511);
            this.btn_kayit.Name = "btn_kayit";
            this.btn_kayit.Size = new System.Drawing.Size(200, 33);
            this.btn_kayit.TabIndex = 10;
            this.btn_kayit.Text = "Kayıt Ol";
            this.btn_kayit.Click += new System.EventHandler(this.btn_kayit_Click);
            // 
            // textbox_kullaniciadi
            // 
            this.textbox_kullaniciadi.AutoRoundedCorners = true;
            this.textbox_kullaniciadi.BorderColor = System.Drawing.Color.Black;
            this.textbox_kullaniciadi.BorderRadius = 17;
            this.textbox_kullaniciadi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_kullaniciadi.DefaultText = "";
            this.textbox_kullaniciadi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textbox_kullaniciadi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textbox_kullaniciadi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textbox_kullaniciadi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textbox_kullaniciadi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textbox_kullaniciadi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textbox_kullaniciadi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textbox_kullaniciadi.Location = new System.Drawing.Point(80, 208);
            this.textbox_kullaniciadi.Name = "textbox_kullaniciadi";
            this.textbox_kullaniciadi.PasswordChar = '\0';
            this.textbox_kullaniciadi.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textbox_kullaniciadi.PlaceholderText = "Kullanıcı Adı";
            this.textbox_kullaniciadi.SelectedText = "";
            this.textbox_kullaniciadi.Size = new System.Drawing.Size(200, 36);
            this.textbox_kullaniciadi.TabIndex = 11;
            this.textbox_kullaniciadi.TextChanged += new System.EventHandler(this.textbox_kullaniciadi_TextChanged);
            // 
            // textbox_sifre
            // 
            this.textbox_sifre.AutoRoundedCorners = true;
            this.textbox_sifre.BorderColor = System.Drawing.Color.Black;
            this.textbox_sifre.BorderRadius = 17;
            this.textbox_sifre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_sifre.DefaultText = "";
            this.textbox_sifre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textbox_sifre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textbox_sifre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textbox_sifre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textbox_sifre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textbox_sifre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textbox_sifre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textbox_sifre.Location = new System.Drawing.Point(80, 250);
            this.textbox_sifre.Name = "textbox_sifre";
            this.textbox_sifre.PasswordChar = '\0';
            this.textbox_sifre.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textbox_sifre.PlaceholderText = "Şifre";
            this.textbox_sifre.SelectedText = "";
            this.textbox_sifre.Size = new System.Drawing.Size(200, 36);
            this.textbox_sifre.TabIndex = 12;
            // 
            // textbox_ad
            // 
            this.textbox_ad.AutoRoundedCorners = true;
            this.textbox_ad.BorderColor = System.Drawing.Color.Black;
            this.textbox_ad.BorderRadius = 17;
            this.textbox_ad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_ad.DefaultText = "";
            this.textbox_ad.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textbox_ad.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textbox_ad.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textbox_ad.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textbox_ad.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textbox_ad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textbox_ad.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textbox_ad.Location = new System.Drawing.Point(80, 292);
            this.textbox_ad.Name = "textbox_ad";
            this.textbox_ad.PasswordChar = '\0';
            this.textbox_ad.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textbox_ad.PlaceholderText = "Ad";
            this.textbox_ad.SelectedText = "";
            this.textbox_ad.Size = new System.Drawing.Size(200, 36);
            this.textbox_ad.TabIndex = 13;
            // 
            // textbox_soyad
            // 
            this.textbox_soyad.AutoRoundedCorners = true;
            this.textbox_soyad.BorderColor = System.Drawing.Color.Black;
            this.textbox_soyad.BorderRadius = 17;
            this.textbox_soyad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_soyad.DefaultText = "";
            this.textbox_soyad.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textbox_soyad.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textbox_soyad.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textbox_soyad.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textbox_soyad.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textbox_soyad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textbox_soyad.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textbox_soyad.Location = new System.Drawing.Point(80, 334);
            this.textbox_soyad.Name = "textbox_soyad";
            this.textbox_soyad.PasswordChar = '\0';
            this.textbox_soyad.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textbox_soyad.PlaceholderText = "Soyad";
            this.textbox_soyad.SelectedText = "";
            this.textbox_soyad.Size = new System.Drawing.Size(200, 36);
            this.textbox_soyad.TabIndex = 14;
            // 
            // textbox_tel
            // 
            this.textbox_tel.AutoRoundedCorners = true;
            this.textbox_tel.BorderColor = System.Drawing.Color.Black;
            this.textbox_tel.BorderRadius = 17;
            this.textbox_tel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_tel.DefaultText = "";
            this.textbox_tel.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textbox_tel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textbox_tel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textbox_tel.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textbox_tel.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textbox_tel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textbox_tel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textbox_tel.Location = new System.Drawing.Point(80, 376);
            this.textbox_tel.MaxLength = 13;
            this.textbox_tel.Name = "textbox_tel";
            this.textbox_tel.PasswordChar = '\0';
            this.textbox_tel.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textbox_tel.PlaceholderText = "Tel";
            this.textbox_tel.SelectedText = "";
            this.textbox_tel.Size = new System.Drawing.Size(200, 36);
            this.textbox_tel.TabIndex = 15;
            this.textbox_tel.TextChanged += new System.EventHandler(this.textbox_tel_TextChanged);
            // 
            // textbox_mail
            // 
            this.textbox_mail.AutoRoundedCorners = true;
            this.textbox_mail.BorderColor = System.Drawing.Color.Black;
            this.textbox_mail.BorderRadius = 17;
            this.textbox_mail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_mail.DefaultText = "";
            this.textbox_mail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textbox_mail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textbox_mail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textbox_mail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textbox_mail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textbox_mail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textbox_mail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textbox_mail.Location = new System.Drawing.Point(80, 418);
            this.textbox_mail.Name = "textbox_mail";
            this.textbox_mail.PasswordChar = '\0';
            this.textbox_mail.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textbox_mail.PlaceholderText = "E-mail";
            this.textbox_mail.SelectedText = "";
            this.textbox_mail.Size = new System.Drawing.Size(200, 36);
            this.textbox_mail.TabIndex = 16;
            this.textbox_mail.TextChanged += new System.EventHandler(this.textbox_mail_TextChanged);
            // 
            // kullanici_resim
            // 
            this.kullanici_resim.ImageRotate = 0F;
            this.kullanici_resim.Location = new System.Drawing.Point(111, 2);
            this.kullanici_resim.Name = "kullanici_resim";
            this.kullanici_resim.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kullanici_resim.Size = new System.Drawing.Size(137, 119);
            this.kullanici_resim.TabIndex = 17;
            this.kullanici_resim.TabStop = false;
            // 
            // combobox_yetki
            // 
            this.combobox_yetki.AutoRoundedCorners = true;
            this.combobox_yetki.BackColor = System.Drawing.Color.Transparent;
            this.combobox_yetki.BorderColor = System.Drawing.Color.Black;
            this.combobox_yetki.BorderRadius = 17;
            this.combobox_yetki.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_yetki.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_yetki.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combobox_yetki.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combobox_yetki.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.combobox_yetki.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.combobox_yetki.ItemHeight = 30;
            this.combobox_yetki.Items.AddRange(new object[] {
            "Yönetici",
            "Personel"});
            this.combobox_yetki.Location = new System.Drawing.Point(80, 460);
            this.combobox_yetki.Name = "combobox_yetki";
            this.combobox_yetki.Size = new System.Drawing.Size(200, 36);
            this.combobox_yetki.TabIndex = 18;
            // 
            // button_resimekle
            // 
            this.button_resimekle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_resimekle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_resimekle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_resimekle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_resimekle.FillColor = System.Drawing.Color.White;
            this.button_resimekle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button_resimekle.ForeColor = System.Drawing.Color.Black;
            this.button_resimekle.Location = new System.Drawing.Point(150, 127);
            this.button_resimekle.Name = "button_resimekle";
            this.button_resimekle.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.button_resimekle.Size = new System.Drawing.Size(59, 41);
            this.button_resimekle.TabIndex = 33;
            this.button_resimekle.Text = "Resim ekle";
            this.button_resimekle.Click += new System.EventHandler(this.button_resimekle_Click);
            // 
            // hesapolustur
            // 
            this.AcceptButton = this.btn_kayit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 557);
            this.Controls.Add(this.button_resimekle);
            this.Controls.Add(this.combobox_yetki);
            this.Controls.Add(this.kullanici_resim);
            this.Controls.Add(this.textbox_mail);
            this.Controls.Add(this.textbox_tel);
            this.Controls.Add(this.textbox_soyad);
            this.Controls.Add(this.textbox_ad);
            this.Controls.Add(this.textbox_sifre);
            this.Controls.Add(this.textbox_kullaniciadi);
            this.Controls.Add(this.btn_kayit);
            this.Name = "hesapolustur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hesap Oluştur";
            this.Load += new System.EventHandler(this.hesapolustur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kullanici_resim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btn_kayit;
        private Guna.UI2.WinForms.Guna2TextBox textbox_kullaniciadi;
        private Guna.UI2.WinForms.Guna2TextBox textbox_sifre;
        private Guna.UI2.WinForms.Guna2TextBox textbox_ad;
        private Guna.UI2.WinForms.Guna2TextBox textbox_soyad;
        private Guna.UI2.WinForms.Guna2TextBox textbox_tel;
        private Guna.UI2.WinForms.Guna2TextBox textbox_mail;
        private Guna.UI2.WinForms.Guna2CirclePictureBox kullanici_resim;
        private Guna.UI2.WinForms.Guna2ComboBox combobox_yetki;
        private Guna.UI2.WinForms.Guna2CircleButton button_resimekle;
    }
}