using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models
{
    public class Izvedba
    {

        [Key]
        public Guid IzvedbaID { get; set; }


        [Required]
        public DateTime DatumPrikazivanja { get; set; }

        public Boolean GostujucaPredstava { get; set; }

        [Required]
        public int BrojSlobodnihMesta { get; set; }

        [Required]
        public int Cena { get; set; }

        public Guid? SalaID { get; set; }
        [Required]
        public Sala Sala { get; set; }
        public Guid? PredstavaID { get; set; }
        [Required]
        public Predstava Predstava { get; set; }
    }
}
