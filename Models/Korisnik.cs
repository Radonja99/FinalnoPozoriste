using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models
{
    public class Korisnik
    {
    
        public Guid KorisnikID { get; set; }
        [Required]
        public string ImeKorisnika { get; set; }
        [Required]
        public string PrezimeKorisnika { get; set; }
        [Required]
        [MaxLength(11), MinLength(7)]
        public string Telefon { get; set; }
        [Required]
        public string KorisnickoIme { get; set; }
        [Required]
        public string LozinkaKorisnika { get; set; }

        public int BrojRezervacija { get; set; }
        [Required]
        public string Role { get; set; }

    }
}
