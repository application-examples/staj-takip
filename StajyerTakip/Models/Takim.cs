using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{
    public class Takim
    {
        public int ID { get; set; }
        public string Ad { get; set; }

        public string Aciklama { get; set; }

        public List<Stajyer> Uyeler { get; set; }

    }
}
