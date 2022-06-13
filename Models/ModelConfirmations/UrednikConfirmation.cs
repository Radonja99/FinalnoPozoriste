using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models.ModelConfirmations
{
    public class UrednikConfirmation
    {
        public Guid UrednikID { get; set; }
        public string ImeUrednika { get; set; }
        public string PrezimeUrednika { get; set; }
        public string KorisnickoImeUrednika { get; set; }
    }
}
