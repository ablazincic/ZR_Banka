using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR_Banka.Classes
{
    public class KreditView
    {
        public int IdKredit { get; set; }
        public string VrstaKredita { get; set; }
        public DateTime DatumPozajmice { get; set; }
        public decimal UkupanIznos { get; set; }
        public decimal PreostaliDug { get; set; }
    }
}
