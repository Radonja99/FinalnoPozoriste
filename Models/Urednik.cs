using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models
{
    public class Urednik
    {
   
        public Guid UrednikID { get; set; }
        public string ImeUrednika { get; set; }
        public string PrezimeUrednika { get; set; }
        public string JMBGUrednika { get; set; }
        public string KorisnickoImeUrednika { get; set; }
        public string LozinkaUrednika { get; set; }

    }
}
