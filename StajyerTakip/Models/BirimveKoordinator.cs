namespace StajyerTakip.Models
{

    public class BirimveKoordinator
    {
        public int BirimID { get; set; }
        public int BirimKoordinatoruID { get; set; }

        public Birim Birim { get; set; }
        public BirimKoordinatoru BirimKoordinatoru { get; set; }
    }
}