using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Creations
{
    public class PozoristeCreationDTO
    {
        
        public string NazivPozorista { get; set; }
        public string Adresa { get; set; }

        public string Grad { get; set; }

        public Guid? UrednikID { get; set; }
    }
}
