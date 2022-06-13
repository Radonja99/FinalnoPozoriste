using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Updates
{
    public class PozoristeUpdateDTO
    {
        public Guid PozoristeID { get; set; }
        public string NazivPozorista { get; set; }
        public string Adresa { get; set; }

        public string Grad { get; set; }

        public Guid? UrednikID { get; set; }
    }
}
