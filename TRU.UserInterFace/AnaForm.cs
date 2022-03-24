using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRU.BussinesLogicLayer;
using TRU.Entities;

namespace TRU.UserInterFace
{
    public partial class AnaForm : Form
    {
        BussinesLL BLL;
        public AnaForm()
        {
            InitializeComponent();
            BLL = new BussinesLL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sonuc =  BLL.YeniKayit(Guid.NewGuid(),txt_isim.Text,txt_soyisim.Text,txt_telefonI.Text,txt_telefonII.Text,txt_telefonIII.Text,txt_adres.Text,txt_EmailAdres.Text,txt_aciklama.Text,txt_website.Text);
            if(sonuc > 0)
            {
                MessageBox.Show("Yeni Kayıt Başarılı Şekilde Oluşturuldu");
                Doldur();

            }else if(sonuc == -100)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz.Lütfen İsim Soyisim TelefonI Alanlarını Doldurunuz");
            }
            else
            {
                MessageBox.Show("Kayıt Ekleme İşleminde Hata Oluştu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sonuc = BLL.XMLVER();
            if(sonuc > 0)
            {
                MessageBox.Show("Data alma işlemi başarılı");
            }else
            {
                MessageBox.Show("Bir hata oluştu");
            }
        }
        private void Doldur()
        {
           List<RehberKayit> rehber = BLL.RehberKayitlariGetir();
            if(rehber.Count > 0 && rehber != null)
            {
                Liste.DataSource = rehber;
            }
        }
        private void AnaForm_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            ListBox list = (ListBox)sender;
            RehberKayit secilendeger = (RehberKayit)list.SelectedItem;
            txt_isim.Text = secilendeger.isim;
            txt_soyisim.Text = secilendeger.soyisim;
            txt_telefonI.Text = secilendeger.telefonI;
            txt_telefonII.Text = secilendeger.telefonII;
            txt_telefonIII.Text = secilendeger.telefonIII;
            txt_adres.Text = secilendeger.adres;
            txt_aciklama.Text = secilendeger.aciklama;
            txt_website.Text = secilendeger.website;
            txt_EmailAdres.Text = secilendeger.emailadres;
            grpbox_kayit.Text = "Rehber Kayit Günceller";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(Liste.SelectedItems != null)
            {
                RehberKayit K = (RehberKayit)Liste.SelectedItem;
                int sonuc = BLL.KayitGuncelle(K.ID, txt_isim.Text, txt_soyisim.Text, txt_telefonI.Text, txt_telefonII.Text, txt_telefonIII.Text, txt_adres.Text, txt_EmailAdres.Text, txt_aciklama.Text, txt_website.Text);

                if(sonuc > 0)
                {
                    MessageBox.Show("Kayıt Başarılı");
                    Doldur();
                }else if(sonuc == -100)
                {
                    MessageBox.Show("Eksik Parametre");
                }
                else
                {
                    MessageBox.Show("Kayıt Edilemedi");
                }
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RehberKayit silinecekID = (RehberKayit)Liste.SelectedItem;
             Guid ID = silinecekID.ID;
            int sonuc = BLL.KayitSil(ID);
            if(sonuc > 0)
            {
                MessageBox.Show("Kayıt Başarılı Şekilde Silindi");
                Doldur();
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }
    }
}
