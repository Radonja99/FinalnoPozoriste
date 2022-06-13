using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs
{
    public class RezervacijaDTO
    {
        public Guid RezervacijaID { get; set; }

        public DateTime DatumKreiranjaRezervacije { get; set; }

        public bool Placeno { get; set; }

        public int UkupnaCenaRezervacije { get; set; }
        public DateTime DatumIstekaRezervacije { get; set; }

        public int BrojMesta { get; set; }

        public KorisnikDTO Korisnik { get; set; }

 //       public SedisteDTO Sediste { get; set; }

        public IzvedbaDTO Izvedba { get; set; }
    }
}
