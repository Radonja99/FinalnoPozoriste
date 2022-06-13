using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public interface IPozoristeRepository
    {
        public bool SaveChanges();
        List<Pozoriste> GetPozoriste();

        Pozoriste GetPozoristeById(Guid PozoristeId);

        PozoristeConfirmation CreatePozoriste(Pozoriste pozoriste);

        PozoristeConfirmation UpdatePozoriste(Pozoriste pozoriste);

        void DeletePozoriste(Guid PozoristeId);
    }
}
