using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{

    public class ProjeBirim
    {
        public int ProjeID { get; set; }
        public int BirimKoordinatoruID { get; set; }

        public Proje Proje { get; set; }
        public BirimKoordinatoru BirimKoordinatoru { get; set; }
    }
}
