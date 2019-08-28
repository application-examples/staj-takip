using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{

    public class Chat
    {
        public int ID { get; set; }
        public int ProjeID { get; set; }
        public Proje Proje { get; set; }

        public int YazanProfilID { get; set; }
        public Profil YazanProfil { get; set; }

       // [Column(TypeName = "VARCHAR(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_turkish_ci")]
        public string Mesaj { get; set; }
        public DateTime Tarih { get; set; }
    }
}
