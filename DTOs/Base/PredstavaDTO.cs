using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs
{
    public class PredstavaDTO
    {
        public Guid PredstavaID { get; set; }

        public string NazivPredstave { get; set; }

        public string Zanr { get; set; }

        public int BrojIzvodjenja { get; set; }

        public DateTime DatumPremijere { get; set; }
    }
}
