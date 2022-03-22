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

        }
    }
}
