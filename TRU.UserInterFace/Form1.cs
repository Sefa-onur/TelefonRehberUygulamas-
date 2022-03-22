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
    public partial class Form1 : Form
    {
        BussinesLL BLL;
        public Form1()
        {
            InitializeComponent();
            BLL = new BussinesLL();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            int sonuc = BLL.KullaniciKontrol(txt_kullaniciİsmi.Text, txt_sifre.Text);
            if(sonuc > 0)
            {
                AnaForm Form = new AnaForm();
                Form.Show();
            }else if(sonuc == -100)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz");
            }
            else
            {
                MessageBox.Show("Hatalı Bilgi Girdiniz");
            }
        }
    }
}
