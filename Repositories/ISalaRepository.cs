using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public interface ISalaRepository
    {
        public bool SaveChanges();
        List<Sala> GetSala();

        Sala GetSalaById(Guid SalaId);

        SalaConfirmation CreateSala(Sala sala);

        SalaConfirmation UpdateSala(Sala sala);

        void DeleteSala(Guid SalaId);
    }
}
