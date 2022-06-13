using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Creations
{
    public class SalaCreationDTO
    {
      

        public string NazivSale { get; set; }

        public int UkupanBrojMesta { get; set; }

        public PozoristeDTO Pozoriste { get; set; }
    }
}
