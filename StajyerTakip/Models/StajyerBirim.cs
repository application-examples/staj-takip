using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{
    public class StajyerBirim
    {
        public int StajyerID { get; set; }
        public int BirimKoordinatoruID { get; set; }

        public Stajyer Stajyer { get; set; }
        public BirimKoordinatoru BirimKoordinatoru { get; set; }
    }
}
