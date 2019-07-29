using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{
    public class SistemYoneticisi
    {
        public int ID { get; set; }
        public int ProfilID { get; set; }

        public Profil Profil { get; set; }
    }
}
