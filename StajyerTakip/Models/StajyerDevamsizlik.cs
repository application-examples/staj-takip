using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{

    public class StajyerDevamsizlik
    {
        public List<Devamsizlik> Veriler { get; set; }
        public Stajyer Stajyer { get; set; }
    }
}
