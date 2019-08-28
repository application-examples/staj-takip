using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{

    public class Yorum
    {
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public int Puan { get; set; }
        public string YorumlayanAdi { get; set; }
        public int YorumlayanID { get; set; } // Yorumlayan bilgileri icin
        public DateTime EklenmeTarihi { get; set; }
        public int StajyerID { get; set; }

        public Profil Yorumlayan { get; set; }
        public Stajyer Stajyer { get; set; }
    }
}
