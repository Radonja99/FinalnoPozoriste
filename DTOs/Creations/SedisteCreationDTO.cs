using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Creations
{
    public class SedisteCreationDTO
    {
       
        public int BrojReda { get; set; }

        public string Sektor { get; set; }
        public int BrojSedista { get; set; }

        public Guid? SalaID { get; set; }
    }
}
