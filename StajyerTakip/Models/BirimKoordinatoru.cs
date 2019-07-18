using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{
    public class BirimKoordinatoru 
    {
        public int ID { get; set; }
        public Profil Profil { get; set; }
        public int ProfilID { get; set; }
        public string Unvan { get; set; }
      
        public List<StajyerBirimK> Stajyerler { get; set; }
        public List<ProjeBirim> Projeler { get; set; }
<<<<<<< HEAD
        public List<BirimveKoordinator> Birimler { get; set; }
=======
        
>>>>>>> 1d209fbdfc46243f40f5f1396d313f24570ef17a
    }
}
