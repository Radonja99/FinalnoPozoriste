using PozoristeProjekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs
{
    public class PozoristeDTO
    {
        public Guid PozoristeID { get; set; }
        public string NazivPozorista { get; set; }
        public string Adresa { get; set; }

        public string Grad { get; set; }

        public UrednikDTO Urednik { get; set; }
    }
}
