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
        public int TanimlananSure { get; set; }
        public string KullanilanTeknolojiler { get; set; }

        public List<Stajyer> Stajyerler { get; set; }
        public List<BirimKoordinatoru> BirimKoordinatorleri { get; set; }
    }
}

