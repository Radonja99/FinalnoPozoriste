using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs
{
    public class KorisnikDTO
    {
        public Guid KorisnikID { get; set; }

        public string ImeKorisnika { get; set; }

        public string PrezimeKorisnika { get; set; }

        public string Telefon { get; set; }

        public string KorisnickoIme { get; set; }

        public string LozinkaKorisnika { get; set; }

        public int BrojRezervacija { get; set; }

        public string Role { get; set; }
    }
}
