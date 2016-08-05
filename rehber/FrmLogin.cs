﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.Logging;
using System.IO;
using System.Data.SqlClient;
using  mailGonder;

namespace rehber
{
    public partial class FrmLogin : Form
    {

        public RehberModel _rehberModel;
        
        public bool Login { get; set; }

        public FrmLogin()
        {
            InitializeComponent();
            btnGiris.Focus();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

            if (!KullaniciLoginDurum())
            {
                MessageBox.Show("Hatalı Giriş. Bilgilerinizi Kontrol Edin", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
      
                SqlConnection baglanti = new SqlHelper().Connection();
                SqlCommand komut = new SqlCommand("beniHatirla", baglanti); // beniHatirla (stored procedure)
                komut.CommandType = CommandType.StoredProcedure;

                if (chkBeniHatirla.Checked)
                {
                    komut.Parameters.AddWithValue("@beniHatirla", "true");
                    komut.Parameters.AddWithValue("@kullaniciAdi", txtKullaniciAdi.Text);

                    try
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                    finally
                    {
                        baglanti.Close();
                    }

                }
                
                this.Hide();
                FrmRehber _frmRehber = new FrmRehber();
                _frmRehber.ShowDialog();
                this.Close();
            }

        }

        private bool KullaniciLoginDurum()
        {
            try
            {
                // var login = new tokDBEntities1().logins.FirstOrDefault(q => q.kullaniciAdi.Equals(txtKullaniciAdi.Text) & q.sifre.Equals(txtSifre.Text));

                var j = new tokDBEntities1().logins.ToDictionary(x => x.kullaniciAdi);
                //-> x i key olarak atayıp, database'de uniq olan kullanıcı adı'nı da x e atadık.
                //j bütün kullanıcı adlarını çekecek.
                var uName = j[txtKullaniciAdi.Text];
                // kullanıcı adı textboxtakiyle aynı olan üye varsa işleme sokacak. 

                if (uName != null && uName.sifre == txtSifre.Text)
                {
                    KullaniciBilgi.KullaniciAdi = uName.kullaniciAdi;
                    KullaniciBilgi.KullaniciID = uName.kullaniciID;

                    return true;
                }
                return false;
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
            catch(KeyNotFoundException ex)
            {
                return false;
            }
            catch (SqlException)
            {
                DialogResult result = MessageBox.Show("Veritabanı bağlantısı yapılamadı. Bağlantıyı kontrol edip tekrar deneyiniz. ", "Bağlantı Hatası", MessageBoxButtons.RetryCancel);
               
                if (result == DialogResult.Retry)
                {
                    //btnGiris_Click içinde yapılan işlemler "yeniden dene" butonuna basılırsa tekrar çağırılıyor...
                    if (!KullaniciLoginDurum())
                    {
                        MessageBox.Show("Hatalı Giriş. Bilgilerinizi Kontrol Edin", "Hatalı Giriş", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        SqlConnection baglanti = new SqlHelper().Connection();
                        SqlCommand komut = new SqlCommand("beniHatirla", baglanti); // beniHatirla (stored procedure)
                        komut.CommandType = CommandType.StoredProcedure;

                        if (chkBeniHatirla.Checked)
                        {
                            komut.Parameters.AddWithValue("@beniHatirla", "true");
                            komut.Parameters.AddWithValue("@kullaniciAdi", txtKullaniciAdi.Text);

                            try
                            {
                                baglanti.Open();
                                komut.ExecuteNonQuery();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }

                            finally
                            {
                                baglanti.Close();
                            }

                        }

                        this.Hide();
                        FrmRehber _frmRehber = new FrmRehber();
                        _frmRehber.ShowDialog();
                        this.Close();
                    }
                }

                return false;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            new Frm_ePostaOlustur().ShowDialog();

            SqlConnection baglanti = new SqlHelper().Connection();
            SqlCommand komut = new SqlCommand("SELECT * FROM dbo.login WHERE beniHatirla = 'true'", baglanti);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }


        private void btnKayitOlDialog_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSignUp _frmSignUp = new FrmSignUp();
            _frmSignUp.ShowDialog();
            this.Close();
        }

        private void txtKullaniciAdi_Leave(object sender, EventArgs e)
        {

            var j = new tokDBEntities1().logins.ToDictionary(x => x.kullaniciAdi);
            //-> x i key olarak atayıp, database'de uniq olan kullanıcı adı'nı da x e atadık.
            //j bütün kullanıcı adlarını çekecek.
            try
            {
                var uName = j[txtKullaniciAdi.Text];
                // kullanıcı adı textboxtakiyle aynı olan üye varsa işleme sokacak. 

                if (uName.beniHatirla == true)
                {
                    txtSifre.Text = uName.sifre;
                }
                else
                {
                    txtSifre.Clear();
                }
            }
            catch (KeyNotFoundException ex)
            {
                txtSifre.Clear();
            }
        }
    }
}
