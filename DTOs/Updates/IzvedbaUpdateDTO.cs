using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Updates
{
    public class IzvedbaUpdateDTO
    {
        public Guid IzvedbaID { get; set; }

        public DateTime DatumPrikazivanja { get; set; }

        public Boolean GostujucaPredstava { get; set; }

        public int BrojSlobodnihMesta { get; set; }

        public int Cena { get; set; }

        public Guid SalaID { get; set; }

        public Guid PredstavaID { get; set; }
    }
}
