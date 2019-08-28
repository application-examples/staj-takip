using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{

    public class Duyuru
    {
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
        public int EkleyenID { get; set; }
        public int EkleyenYetki { get; set; }
    }
}
