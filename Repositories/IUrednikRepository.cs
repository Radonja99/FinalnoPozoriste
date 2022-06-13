using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public interface IUrednikRepository
    {
        public bool SaveChanges();
        List<Urednik> GetUrednik();

        Urednik GetUrednikById(Guid UrednikId);

        UrednikConfirmation CreateUrednik(Urednik urednik);

        UrednikConfirmation UpdateUrednik(Urednik urednik);

        void DeleteUrednik(Guid UrednikId);
        Urednik GetByKorisnickoIme(string KorisnickoImeUrednika);
    }
}
