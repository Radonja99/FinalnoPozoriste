using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs
{
    public class SalaDTO
    {
        public Guid SalaID { get; set; }

        public string NazivSale { get; set; }

        public int UkupanBrojMesta { get; set; }

        public PozoristeDTO Pozoriste { get; set; }
    }
}
