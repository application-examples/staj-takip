﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip.Models
{
    public class Profil
    {

        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string KullaniciAdi { get; set; }
        public string Fotograf { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Sokak { get; set; }
        public int Rol { get; set; }
    }
}