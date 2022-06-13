using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Confirmations
{
    public class IzvedbaConfirmationDTO
    {
        public Guid IzvedbaID { get; set; }
       

        public int Cena { get; set; }

        public DateTime DatumPrikazivanja { get; set; }


       
    }
}
