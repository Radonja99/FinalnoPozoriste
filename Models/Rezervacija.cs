using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models
{
    public class Rezervacija
    {
   
        public Guid RezervacijaID { get; set; }

        [Required]
        public DateTime DatumKreiranjaRezervacije { get; set; }
        [Required]
        public int BrojMesta { get; set; }

        public int UkupnaCenaRezervacije { get; set; }

        public bool Placeno { get; set; }
        public DateTime DatumIstekaRezervacije { get; set; }
        [Required]
        public Guid KorisnikID { get; set; }

        public Korisnik Korisnik { get; set; }

        //      public Guid? SedisteID { get; set; }
        //     public Sediste Sediste { get; set; }
        [Required]
        public Guid IzvedbaID { get; set; }
        public Izvedba Izvedba { get; set; }
    }
}
