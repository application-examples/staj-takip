using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{
    public class Devamsizlik
    {
        public int ID { get; set; }
        public int StajyerID { get; set; }
        public Stajyer Stajyer { get; set; }
        public DateTime Tarih { get; set; }

    }
}
