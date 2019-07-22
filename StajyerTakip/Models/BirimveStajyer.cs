using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{
    public class BirimveStajyer
    {
        public int BirimID { get; set; }
        public int StajyerID { get; set; }

        public Stajyer Stajyer { get; set; }
        public Birim Birim { get; set; }
    }
}
