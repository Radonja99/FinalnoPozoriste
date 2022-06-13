using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public interface ISedisteRepository
    {
        public bool SaveChanges();
        List<Sediste> GetSedista();

        Sediste GetSedisteById(Guid SedisteId);

        SedisteConfirmation CreateSediste(Sediste sediste);

        SedisteConfirmation UpdateSediste(Sediste sediste);

        void DeleteSediste(Guid SedisteId);
    }
}
