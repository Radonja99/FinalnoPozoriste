using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs
{
    public class IzvedbaDTO
    {
        public Guid IzvedbaID { get; set; }

        public DateTime DatumPrikazivanja { get; set; }

        public int BrojSlobodnihMesta { get; set; }

        public int Cena { get; set; }
        public Boolean GostujucaPredstava { get; set; }

        public SalaDTO Sala { get; set; }

        public PredstavaDTO Predstava { get; set; }
    }
}
