using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{
    public class Devamsızlık
    {
        public int ID { get; set; }
        public int OrenciID { get; set; }
        public string Ogrenci { get; set; }
        public DateTime Tarih { get; set; }

    }
}
