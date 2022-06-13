using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models
{
    public class Predstava
    {
        public Guid PredstavaID { get; set; }
        [Required]
        public string NazivPredstave { get; set; }

        public string Zanr { get; set; }

        public int BrojIzvodjenja { get; set; }

        public DateTime DatumPremijere { get; set; }
    }
}
