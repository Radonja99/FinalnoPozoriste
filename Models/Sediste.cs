using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models
{
    public class Sediste

    {
       
        public Guid SedisteID { get; set; }
        public int BrojReda { get; set; }

        public string Sektor { get; set; }
        public int BrojSedista { get; set; }
        public Guid? SalaID { get; set; }

        public Sala Sala { get; set; }

    }
}
