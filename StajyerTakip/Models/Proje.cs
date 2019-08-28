using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{

    public class Proje
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Icerik { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public string Link { get; set; }
        public string KullanilanTeknolojiler { get; set; }
        public List<StajyerProje> Stajyerler { get; set; }
        public List<ProjeBirim> BirimKoordinatorleri { get; set; }
    }
}

