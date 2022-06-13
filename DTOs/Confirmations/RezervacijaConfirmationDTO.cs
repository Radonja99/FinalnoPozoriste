using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Confirmations
{
    public class RezervacijaConfirmationDTO
    {
        public Guid RezervacijaID { get; set; }

        public DateTime DatumKreiranjaRezervacije { get; set; }

        public int UkupnaCenaRezervacije { get; set; }

        public int BrojMesta { get; set; }

    }
}
