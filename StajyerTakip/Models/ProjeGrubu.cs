using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{


    public class ProjeGrubu
    {
        public int ID { get; set; }
        public int OgrenciID { get; set; }
        public int ProjeID { get; set; }
        public String Ogrenci { get; set; }
        public string Proje { get; set; }
    }
}
