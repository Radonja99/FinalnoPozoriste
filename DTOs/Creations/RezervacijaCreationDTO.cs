using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Creations
{
    public class RezervacijaCreationDTO
    {
        

        public DateTime DatumKreiranjaRezervacije { get; set; }

        public bool Placeno { get; set; }

        public DateTime DatumIstekaRezervacije { get; set; }

        public int BrojMesta { get; set; }

        public Guid? KorisnikID { get; set; }

  //      public Guid? SedisteID { get; set; }

        public Guid? IzvedbaID { get; set; }
    }
}
