using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{
    public class StajyerBirimK
    {
        public int StajyerID { get; set; }
        public int BirimKID { get; set; }

        public Stajyer Stajyer { get; set; }
        public BirimKoordinatoru BirimK { get; set; }
    }
}
