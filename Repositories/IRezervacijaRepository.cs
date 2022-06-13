using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public interface IRezervacijaRepository
    {
        public bool SaveChanges();
        List<Rezervacija> GetRezervacija();

        bool Checker2Korisnik(Rezervacija rezervacija);
        Rezervacija GetRezervacijaById(Guid RezervacijaId);

        RezervacijaConfirmation CreateRezervacija(Rezervacija rezervacija);

        RezervacijaConfirmation UpdateRezervacija(Rezervacija rezervacija);

        List<Rezervacija> GetSveRezervacijeKorisnika(Guid id);

        void DeleteRezervacija(Guid RezervacijaId);

        bool Checker(Rezervacija rezervacija);
    }
}
