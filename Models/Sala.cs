using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models
{
    public class Sala
    {
   
        public Guid SalaID { get; set; }

        [Required]
        public string NazivSale { get; set; }

        public int UkupanBrojMesta { get; set; }
        [Required]
        public Guid? PozoristeID { get; set; }

        public Pozoriste Pozoriste { get; set; }

        
    }
}
