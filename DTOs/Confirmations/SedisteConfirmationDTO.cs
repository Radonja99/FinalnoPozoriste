using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Confirmations
{
    public class SedisteConfirmationDTO
    {
        public Guid SedisteID { get; set; }
        public int BrojReda { get; set; }

        public string Sektor { get; set; }
        public int BrojSedista { get; set; }

    }
}
