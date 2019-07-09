using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{
    public class EkDosya
    {
        public int ID { get; set; }
        public int GunlukID { get; set; }
        public string Path { get; set; }
        public Gunluk Gunluk { get; set; }
    }
}
