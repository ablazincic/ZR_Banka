using System;
using System.Collections.Generic;

namespace ZR_Banka.Models;

public partial class Korisnik
{
    public int IdKorisnik { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Uloga { get; set; } = null!;

    public virtual ICollection<Kredit> Kredit { get; set; } = new List<Kredit>();

    public Korisnik(string ime, string prezime, string username,string password, string mail,string uloga)
    {
        Ime = ime;
        Prezime = prezime;
        Username = username;
        Password = password;
        Mail = mail;
        Uloga = uloga;
    }
}
