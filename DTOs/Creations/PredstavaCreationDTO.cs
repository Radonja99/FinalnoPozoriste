using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Creations
{
    public class PredstavaCreationDTO
    {
        public string NazivPredstave { get; set; }

        public string Zanr { get; set; }

        public int BrojIzvodjenja { get; set; }

        public DateTime DatumPremijere { get; set; }
    }
}
