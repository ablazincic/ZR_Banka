using System;
using System.Collections.Generic;

namespace ZR_Banka.Models;

public partial class Uplata
{
    public int IdUplate { get; set; }

    public int? IdKredit { get; set; }

    public decimal Uplata_novac { get; set; }

    public DateOnly DatumUplate { get; set; }

    public decimal? PreostaliDug { get; set; }
}
