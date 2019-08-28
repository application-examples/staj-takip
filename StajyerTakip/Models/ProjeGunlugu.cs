using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{


    public class ProjeGunlugu
    {
        public int ID { get; set; }
        public int ProjeID { get; set; }
        public string Durum { get; set; }
        public DateTime Tarih { get; set; }
        public string Baslik { get; set; }


        public Proje Proje { get; set; }
    }
}
