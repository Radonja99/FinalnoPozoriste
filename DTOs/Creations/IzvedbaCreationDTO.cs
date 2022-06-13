using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Creations
{
    public class IzvedbaCreationDTO
    {
       
        public DateTime DatumPrikazivanja { get; set; }

        public Boolean GostujucaPredstava { get; set; }


        public int Cena { get; set; }

        public Guid? SalaID { get; set; }

        public Guid? PredstavaID { get; set; }
    }
}
