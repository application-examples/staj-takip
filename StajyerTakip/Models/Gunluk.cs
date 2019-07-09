using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{
    public class Gunluk
    {
        public int ID { get; set; }
        public int OgrenciID { get; set; }

        public string Baslik { get; set; }
        public string Bilgiler { get; set; }
        public Boolean OnayDurumu { get; set; }
        public DateTime Tarih { get; set; }


        public Stajyer Ogrenci { get; set; }
        public List<EkDosya> Ekler { get; set; }
    }
}
