using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR_Banka.Models
{
    public class Zahtjev
    {
        public int IdZahtjev { get; set; } 

        public int IdKorisnik { get; set; }

        public string vrsta_kredita { get; set; } = null!;

        public decimal iznos { get; set; }
        public DateTime datum_zahtjeva { get; set; }

        public int vrijeme_otplate { get; set; }

        public bool status_zahtjeva { get; set; }



    }
}
