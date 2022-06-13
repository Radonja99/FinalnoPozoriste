using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public interface IKorisnikRepository
    {
        public bool SaveChanges();
        List<Korisnik> GetKorisnik();

        Korisnik GetKorisnikById(Guid KorisnikId);

        KorisnikConfirmation CreateKorisnik(Korisnik korisnik);

        KorisnikConfirmation UpdateKorisnik(Korisnik korisnik);

        Korisnik GetByKorisnickoIme(string KorisnickoIme);

        void DeleteKorisnik(Guid KorisnikId);
    }
}
