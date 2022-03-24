using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRU.Entities;

namespace TRU.Core
{
    public class DataBaseLogicLayer
    {
        List<RehberKayit> Kayitlarim;
        public DataBaseLogicLayer()
        {
            VeriTabaniKontrol();
            Kayitlarim = new List<RehberKayit>();
        }

        public void VeriTabaniKontrol()
        {
           bool rehberkontrol = Directory.Exists(@"c:\TelefonRehberi\");
           if (!rehberkontrol)
            {
                Directory.CreateDirectory(@"c:\TelefonRehberi\");

                Kullanici demo = new Kullanici();
                demo.ID = Guid.NewGuid();
                demo.KullaniciAdi = "demo";
                demo.Sifre = "demo";

                string kullanici =  Newtonsoft.Json.JsonConvert.SerializeObject(demo);
                File.WriteAllText(@"c:\TelefonRehberi\kullanici.json", kullanici);
            }
        }
        public int YeniKayit(RehberKayit K)
        {
            int sonuc = 0;
            try
            {
                RehberKayitlariGetir();
                Kayitlarim.Add(K);
                RehberGuncelle();
                sonuc = 1;
            }
            catch (Exception ex)
            {

                sonuc = 0;
            }
            return sonuc;
        }
        public int KayitGuncelle(RehberKayit K)
        {
            int sonuc = 0;
            try
            {
                RehberKayitlariGetir();
                int index = Kayitlarim.FindIndex(I => I.ID == K.ID);
                if(index > -1)
                {
                    Kayitlarim[index].isim = K.isim;
                    Kayitlarim[index].soyisim = K.soyisim;
                    Kayitlarim[index].telefonI = K.telefonI;
                    Kayitlarim[index].telefonII = K.telefonII;
                    Kayitlarim[index].telefonIII = K.telefonIII;
                    Kayitlarim[index].adres = K.adres;
                    Kayitlarim[index].emailadres = K.emailadres;
                    Kayitlarim[index].aciklama = K.aciklama;
                    Kayitlarim[index].website = K.website;
                 }
                RehberGuncelle();
                sonuc = 1;
            }
            catch (Exception ex)
            {

                
            }
            return sonuc;
        }
        public List<RehberKayit> RehberKayitlariGetir()
        {
            bool kontrol = File.Exists(@"c:\TelefonRehberi\Rehber.json");
            if (kontrol)
            {
                string gelenrehber = File.ReadAllText(@"c:\TelefonRehberi\Rehber.json");
                Kayitlarim = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RehberKayit>>(gelenrehber);
            }            
            return Kayitlarim;
        }

        public int KullaniciKontrol(Kullanici kullanici)
        {
            int sonuc = 0;
            if (File.Exists(@"c:\TelefonRehberi\kullanici.json"))
            {
                string gelenrehber = File.ReadAllText(@"c:\TelefonRehberi\kullanici.json");
                List<Kullanici> kullanicilar = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Kullanici>>(gelenrehber);
                sonuc = kullanicilar.FindAll(I => I.KullaniciAdi == kullanici.KullaniciAdi && I.Sifre == kullanici.Sifre).ToList().Count();               
            }
            return sonuc;
        }
        public int KayitSil(Guid ID)
        {
            int sonuc = 0;
            try
            {
                RehberKayitlariGetir();
                RehberKayit silinecekdeger = Kayitlarim.Find(I => I.ID == ID);
                Kayitlarim.Remove(silinecekdeger);
                sonuc = 1;
                RehberGuncelle();
            }
            catch (Exception ex)
            {

            }


            return sonuc;
        }

        #region
        private void RehberGuncelle()
        {
            if(Kayitlarim !=null&&Kayitlarim.Count > 0)
            {
                string guncelkayit = Newtonsoft.Json.JsonConvert.SerializeObject(Kayitlarim);
                File.WriteAllText(@"c:\TelefonRehberi\Rehber.json",guncelkayit);
            }
        }
        #endregion
    }
}
