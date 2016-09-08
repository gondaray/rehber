//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace rehber
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using System.Linq;

    public partial class FrmRehber : Form
    {

        public FrmRehber()
        {
            InitializeComponent();
            this.Text = KullaniciBilgi.KullaniciAdi + " - REHBER";

        }

        private List<RehberModel> _rehberList;

        ///
        //>    FrmRehber_Load
        ///
        private void FrmRehber_Load(object sender, System.EventArgs e)
        {
            listele();

            RehberModel selectedItem = this.listBox1.SelectedItem as RehberModel;

            AutoCompleteStringCollection listBoxStrings = new AutoCompleteStringCollection();

            foreach (RehberModel model in this._rehberList)
            {
                listBoxStrings.Add(model.Isim + " " + model.Soyisim);
                this.listBox1.SelectedItem = model.Isim + " " + model.Soyisim;
            }

            this.textBoxAra.AutoCompleteCustomSource = listBoxStrings;

            controlsEnableOrNot();
            
        }

        ///
        //->    btnSil_Click
        ///
        private void btnSil_Click(object sender, System.EventArgs e)
        {
            if(listBox1.Items.Count==0)
            {
                MessageBox.Show("Silinecek kay�t yok!", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (MessageBox.Show("Kay�d� silmek istedi�inize emin misiniz ?", "Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                try
                {
                    SqlConnection connection = new SqlHelper().Connection();
                    connection.Open();

                    RehberModel selectedItem = this.listBox1.SelectedItem as RehberModel;
                    new SqlCommand("DELETE FROM dbo.rehber WHERE rehber.ID = " + selectedItem.Id, connection).ExecuteNonQuery();
                    this.pictureBoxGoster.Image = image.icon_user_default;
                    this.labelAdSoyad.Text = null;
                    this.labelTelefon.Text = this.labelDogumTarihi.Text = this.labelCinsiyet.Text = this.labelIsTanim.Text = string.Empty;
                    this.listele();
                    controlsEnableOrNot();

                    MessageBox.Show("Kay�t silindi!", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   connection.Close();

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }

        ///
        //->   buttonGuncelle_Click
        ///
        private void btnGuncelle_Click(object sender, System.EventArgs e)
        {
                if (listBox1.Items.Count == 0)
                {
                    MessageBox.Show("Listede hen�z kay�t yok.", "G�ncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RehberModel selectedItem = this.listBox1.SelectedItem as RehberModel;
                    new FrmUpdate(selectedItem).ShowDialog();
                    this.listele();
                }
            
        }

        ///
        //->   listBox1_SelectedIndexChanged  -> listede se�ili eleman de�i�ti�inde..
        ///
        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.goster();
        }

        ///
        //->   listBox1_DoubleClick
        ///
        private void listBox1_DoubleClick(object sender, System.EventArgs e)
        {
            RehberModel selectedItem = this.listBox1.SelectedItem as RehberModel;
            new FrmUpdate(selectedItem, this).ShowDialog();
        }

        ///
        //->   textBoxAra_TextChanged -> arama yaparken sonu�lar� anl�k g�sterebilmek i�in..
        ///
        private void textBoxAra_TextChanged(object sender, System.EventArgs e)
        {
            List<RehberModel> list = (from q in this._rehberList
                                      where ((q.Isim.Contains(this.textBoxAra.Text) | q.Soyisim.Contains(this.textBoxAra.Text)) | q.GenelBilgi.Contains(this.textBoxAra.Text)) | q.TelNo.Contains(this.textBoxAra.Text)
                                      select q).ToList<RehberModel>();
           

            if (list.Count == 0)
            {
                this.pictureBoxGoster.Image = image.icon_user_default;
                this.labelAdSoyad.Text = "...";
                this.labelTelefon.Text = this.labelDogumTarihi.Text = this.labelCinsiyet.Text = this.labelIsTanim.Text = "-";
                lblLBStatus.Text = "Kay�t Bulunamad� !!";

                lblLBStatus.ForeColor = Color.Red;
            }
            else
            {
                this.listBox1.DataSource = list;
                lblLBStatus.Text = "Toplam Kay�t: " + list.Count; 
                lblLBStatus.ForeColor = Color.Black;
            }

            this.listBox1.DataSource = list;
        }


        ///
        //->   buttonYeniKayit_Click
        ///
        private void btnYeniKayit_Click(object sender, System.EventArgs e)
        {
            new FrmNewPerson(this).ShowDialog();
        }

        ///
        //->   listele() -> kaydedilen isimler listbox ta listeleniyor.
        ///
        public void listele()
        {
            this.listBox1.ValueMember = "kullaniciID";
            this.listBox1.DisplayMember = "GenelBilgi"; // GenelBilgi, RehberModel'in i�inde "�sim + Soyisim" bilgisini tutan eleman.
            this._rehberList = new RehberBL().RehberList();
            this.listBox1.DataSource = this._rehberList;

            lblLBStatus.Text = "Toplam Kay�t: " + _rehberList.Count;
        }

        ///
        //->   goster()  -> FrmRehber formunun sa� taraf�nda bilgiler g�steriliyor.
        ///
        public void goster()
        {
            RehberModel selectedItem = this.listBox1.SelectedItem as RehberModel;
            if (selectedItem != null)
            {
                if (selectedItem.Resim != null)
                {
                    MemoryStream stream = new MemoryStream(selectedItem.Resim);
                    this.pictureBoxGoster.Image = Image.FromStream(stream);
                }
                else
                {
                    this.pictureBoxGoster.Image = null;
                }

                //labelAdSoyad labelinin yaz� boyutunu kontrol ediyor
                if (selectedItem.GenelBilgi.Length < 19)
                {
                    this.labelAdSoyad.Font = new Font("candara", 18, FontStyle.Regular);
                    this.labelAdSoyad.TextAlign = ContentAlignment.MiddleLeft;
                }
                else if (selectedItem.GenelBilgi.Length >= 19 && selectedItem.GenelBilgi.Length < 25)
                {
                    this.labelAdSoyad.Font = new Font("candara", 15, FontStyle.Regular);
                    this.labelAdSoyad.TextAlign = ContentAlignment.MiddleLeft;
                }
                else 
                {
                    this.labelAdSoyad.Font = new Font("candara", 12, FontStyle.Regular);
                    this.labelAdSoyad.TextAlign = ContentAlignment.MiddleLeft;
                }

                this.labelAdSoyad.Text = selectedItem.GenelBilgi; 
                this.labelTelefon.Text = selectedItem.TelNo;
                this.labelEMail.Text = selectedItem.EMail;
                this.labelDogumTarihi.Text = selectedItem.DogumTarihi.ToShortDateString();
                this.labelCinsiyet.Text = selectedItem.Cinsiyet;
                this.labelIsTanim.Text = selectedItem.IsTanimi;
            }
        }
        ////
        //--> controlsEnableOrNot() -> "Ara" text box �n� ve "excel'e aktar" butonunu kay�t varken a��p kay�t yokken kapat�r.
        ////
        public void controlsEnableOrNot() 
        {
            if (this.listBox1.Items.Count == 0)
            {
                this.textBoxAra.Enabled = false;
                this.btnExcelAktar.Enabled = false;
            }
            else
            {
                this.textBoxAra.Enabled = true;
                this.btnExcelAktar.Enabled = true;
            }

        }

        ////
        //--> btnKullaniciDegistir_Click() -> ba�ka kullan�c�ya ge�mek i�in.. 
        ////
        private void btnKullaniciDegistir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ba�ka kullan�c�ya ge�mek istedi�inize emin misiniz?","Kullan�c� De�i�tir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();    
                FrmLogin _frmLogin = new FrmLogin();
                _frmLogin.ShowDialog();
                this.Close();

            }
           
        }

        ////
        //--> btnExcelAktar_Click() -> verileri excel e aktaran buton 
        ////
        private void btnExcelAktar_Click(object sender, EventArgs e)
        {
            new ImportExcelCheckList(this.listBox1).ShowDialog();
        }

        public void lblSifreDegistir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FrmChangePassword _frmChangePassword = new FrmChangePassword();
          
            _frmChangePassword.ShowDialog();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frmEPosta = new Frm_ePostaOlustur();
            frmEPosta.ShowDialog();
        }

    }
}
