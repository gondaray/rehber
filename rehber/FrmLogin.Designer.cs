﻿namespace rehber
{
    partial class FrmLogin
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
            this.btnGiris = new System.Windows.Forms.Button();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkBeniHatirla = new System.Windows.Forms.CheckBox();
            this.btnKayitOlDialog = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.Ivory;
            this.btnGiris.Font = new System.Drawing.Font("Buxton Sketch", 15F);
            this.btnGiris.Location = new System.Drawing.Point(288, 186);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(110, 38);
            this.btnGiris.TabIndex = 1;
            this.btnGiris.Text = "GİRİŞ >>";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Verdana", 11F);
            this.txtKullaniciAdi.Location = new System.Drawing.Point(129, 27);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(200, 25);
            this.txtKullaniciAdi.TabIndex = 1;
            this.txtKullaniciAdi.Text = "admin";
            this.txtKullaniciAdi.Leave += new System.EventHandler(this.txtKullaniciAdi_Leave);
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new System.Drawing.Font("Verdana", 11F);
            this.txtSifre.Location = new System.Drawing.Point(129, 60);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(200, 25);
            this.txtSifre.TabIndex = 2;
            this.txtSifre.Text = "admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Buxton Sketch", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı Adı     :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Buxton Sketch", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre               :";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkBeniHatirla);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSifre);
            this.panel1.Controls.Add(this.txtKullaniciAdi);
            this.panel1.Location = new System.Drawing.Point(49, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 145);
            this.panel1.TabIndex = 0;
            // 
            // chkBeniHatirla
            // 
            this.chkBeniHatirla.AutoSize = true;
            this.chkBeniHatirla.Location = new System.Drawing.Point(129, 94);
            this.chkBeniHatirla.Name = "chkBeniHatirla";
            this.chkBeniHatirla.Size = new System.Drawing.Size(80, 17);
            this.chkBeniHatirla.TabIndex = 3;
            this.chkBeniHatirla.Text = "Beni Hatırla";
            this.chkBeniHatirla.UseVisualStyleBackColor = true;
            // 
            // btnKayitOlDialog
            // 
            this.btnKayitOlDialog.BackColor = System.Drawing.Color.Ivory;
            this.btnKayitOlDialog.Font = new System.Drawing.Font("Buxton Sketch", 15F);
            this.btnKayitOlDialog.Location = new System.Drawing.Point(49, 186);
            this.btnKayitOlDialog.Name = "btnKayitOlDialog";
            this.btnKayitOlDialog.Size = new System.Drawing.Size(110, 38);
            this.btnKayitOlDialog.TabIndex = 2;
            this.btnKayitOlDialog.Text = "Kayıt Ol";
            this.btnKayitOlDialog.UseVisualStyleBackColor = false;
            this.btnKayitOlDialog.Click += new System.EventHandler(this.btnKayitOlDialog_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 264);
            this.Controls.Add(this.btnKayitOlDialog);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGiris);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kullanıcı Girişi";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkBeniHatirla;
        private System.Windows.Forms.Button btnKayitOlDialog;
    }
}