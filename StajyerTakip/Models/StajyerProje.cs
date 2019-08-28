using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{

    public class StajyerProje
    {
        public int StajyerID { get; set; }
        public int ProjeID { get; set; }

        public Stajyer Stajyer { get; set; }
        public Proje Proje { get; set; }
    }
}
