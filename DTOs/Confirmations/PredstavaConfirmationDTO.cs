using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Confirmations
{
    public class PredstavaConfirmationDTO
    {
        public Guid PredstavaID { get; set; }

        public string NazivPredstave { get; set; }

        public string Zanr { get; set; }

    }
}
