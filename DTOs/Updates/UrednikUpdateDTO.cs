using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.DTOs.Updates
{
    public class UrednikUpdateDTO
    {
        public Guid UrednikID { get; set; }
        public string ImeUrednika { get; set; }
        public string PrezimeUrednika { get; set; }
        public string JMBGUrednika { get; set; }
        public string KorisnickoImeUrednika { get; set; }
        public string LozinkaUrednika { get; set; }
    }
}
