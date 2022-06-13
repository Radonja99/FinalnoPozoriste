using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Updates
{
    public class SalaUpdateDTO
    {
        public Guid SalaID { get; set; }

        public string NazivSale { get; set; }

        public int UkupanBrojMesta { get; set; }

        public Guid? PozoristeID { get; set; }
    }
}
