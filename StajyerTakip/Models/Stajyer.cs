using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{
    public class Ogrenci
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
        public int Telefon { get; set; }
        public string Okul { get; set; }
        public string Bolum { get; set; }
        public string Resim { get; set; }
    }
}
