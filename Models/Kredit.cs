using System;
using System.Collections.Generic;

namespace ZR_Banka.Models;

public partial class Kredit
{
    public int IdKredit { get; set; }

    public int? IdKorisnik { get; set; }

    public string VrstaKredita { get; set; } = null!;

    public DateOnly DatumPozajmice { get; set; }

    public decimal KamatnaStopa { get; set; }

    public int VrijemeOtplate { get; set; }

    public decimal Glavnica { get; set; }

    public bool StatusKredita { get; set; }

    public decimal UkupanIznos { get; set; }

    public virtual Korisnik? IdKorisnikNavigation { get; set; }

   
}
