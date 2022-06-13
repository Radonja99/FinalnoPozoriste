using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public interface IIzvedbaRepository
    {
        public bool SaveChanges();
        List<Izvedba> GetIzvedba();

        Izvedba GetIzvedbaById(Guid IzvedbaId);

        IzvedbaConfirmation CreateIzvedba(Izvedba izvedba);

        IzvedbaConfirmation UpdateIzvedba(Izvedba izvedba);

        void DeleteIzvedba(Guid IzvedbaId);

        List<Izvedba> GetSveIzvedbePredstave(Guid id);

        List<Izvedba> GetRepertoarPozorista(Guid id);
    }
}
