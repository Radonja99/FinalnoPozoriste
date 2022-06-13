using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models.ModelConfirmations
{
    public class KorisnikConfirmation
    {
        public Guid KorisnikID { get; set; }

        public string ImeKorisnika { get; set; }

        public string PrezimeKorisnika { get; set; }

        public string KorisnickoIme { get; set; }
    }
}
