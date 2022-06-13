using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public interface IPredstavaRepository
    {
        public bool SaveChanges();
        List<Predstava> GetPredstava(string zanr);

        Predstava GetPredstavaById(Guid PredstavaId);

        PredstavaConfirmation CreatePredstava(Predstava predstava);

        PredstavaConfirmation UpdatePredstava(Predstava predstava);

        void DeletePredstava(Guid PredstavaId);

        List<Predstava> GetByPozoristeID(Guid id);
    }
}
