using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRU.Core;
using TRU.Entities;

namespace TRU.BussinesLogicLayer
{
public  class BussinesLL
    {
        DataBaseLogicLayer DLL;

        public BussinesLL()
        {
        DLL = new Core.DataBaseLogicLayer();
        }
        public int YeniKayit(Guid ID,string isim, string soyisim,string telefonI,string telefonII,string telefonIII,string adres,string email,string aciklama,string website)
        {
            int sonuc = 0;

            if(!string.IsNullOrEmpty(isim) && !string.IsNullOrEmpty(soyisim) && ID != Guid.Empty && !string.IsNullOrEmpty(telefonI))
            {
                RehberKayit yenikayit = new RehberKayit();
                yenikayit.ID = ID;
                yenikayit.isim = isim;
                yenikayit.isim = soyisim;
                yenikayit.telefonI = telefonI;
                yenikayit.telefonII= telefonI;
                yenikayit.telefonIII = telefonIII;
                yenikayit.adres = adres;
                yenikayit.aciklama = aciklama;
                yenikayit.emailadres = email;
                yenikayit.website = website;

                sonuc = DLL.YeniKayit(yenikayit);
            }
            else
            {
                sonuc = -100;
            }
            return sonuc;
        }

        public int KullaniciKontrol(string kullaniciadi, string sifre)
        {
            int sonuc = 0;

            if(!string.IsNullOrEmpty(kullaniciadi) && !string.IsNullOrEmpty(sifre))
            {
                Kullanici kullanici = new Kullanici();
                kullanici.Sifre = sifre;
                kullanici.KullaniciAdi = kullaniciadi;

                sonuc = DLL.KullaniciKontrol(kullanici);

            }else
            {
                sonuc = -100;
            }

            return sonuc;
        }
        public List<RehberKayit> RehberKayitlariGetir()
        {
          return DLL.RehberKayitlariGetir();
        }
        public int KayitGuncelle(Guid ID, string isim, string soyisim, string telefonI, string telefonII, string telefonIII, string adres, string email, string aciklama, string website)
        {
            int sonuc = 0;
            if(!string.IsNullOrEmpty(isim) && !string.IsNullOrEmpty(soyisim) && ID != Guid.Empty && !string.IsNullOrEmpty(telefonI) && ID != Guid.Empty)
            {
                RehberKayit yenikayit = new RehberKayit();
                yenikayit.ID = ID;
                yenikayit.isim = isim;
                yenikayit.isim = soyisim;
                yenikayit.telefonI = telefonI;
                yenikayit.telefonII = telefonI;
                yenikayit.telefonIII = telefonIII;
                yenikayit.adres = adres;
                yenikayit.aciklama = aciklama;
                yenikayit.emailadres = email;
                yenikayit.website = website;
                sonuc = DLL.KayitGuncelle(yenikayit);
            }
            else
            {
                sonuc = 100;
            }
            return sonuc;
        }
        public int KayitSil(Guid ID)
        {
            return DLL.KayitSil(ID);
        }
    }
}
