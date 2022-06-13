using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models.ModelConfirmations
{
    public class IzvedbaConfirmation
    {
        public Guid IzvedbaID { get; set; }

        public int Cena { get; set; }

        public DateTime DatumPrikazivanja { get; set; }
    }
}
