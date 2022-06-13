using AutoMapper;
using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public class KorisnikRepository : IKorisnikRepository


    {
        private readonly PozoristeContext context;
        private readonly IMapper mapper;

        public KorisnikRepository(PozoristeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public KorisnikConfirmation CreateKorisnik(Korisnik korisnik)
        {
            var createdEntity = context.Add(korisnik);

            return mapper.Map<KorisnikConfirmation>(createdEntity.Entity);
        }

        public void DeleteKorisnik(Guid KorisnikId)
        {
            var korisnik = GetKorisnikById(KorisnikId);
            context.Remove(korisnik);
        }

        public List<Korisnik> GetKorisnik()
        {
            return context.Korisnik.ToList();
        }

        public Korisnik GetKorisnikById(Guid KorisnikId)
        {
            return context.Korisnik.FirstOrDefault(e => e.KorisnikID == KorisnikId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public KorisnikConfirmation UpdateKorisnik(Korisnik korisnik)
        {

            Korisnik korisniknew = GetKorisnikById(korisnik.KorisnikID);

            if (korisniknew == null)
            {
                throw new EntryPointNotFoundException();
            }

            Console.WriteLine(korisnik.KorisnickoIme);
            Console.WriteLine("Ovo je umesto testa" + korisnik.Role);
            korisniknew.KorisnikID = korisnik.KorisnikID;
            korisniknew.PrezimeKorisnika = korisnik.PrezimeKorisnika;
            korisniknew.ImeKorisnika = korisnik.ImeKorisnika;
            korisniknew.Telefon = korisnik.Telefon;
            korisniknew.LozinkaKorisnika = korisnik.LozinkaKorisnika;
            korisniknew.KorisnickoIme = korisnik.KorisnickoIme;
            korisniknew.Role = korisnik.Role;
            korisniknew.BrojRezervacija = korisnik.BrojRezervacija;
            context.SaveChanges();

            return new KorisnikConfirmation()
            {
                KorisnikID = korisniknew.KorisnikID,
                ImeKorisnika = korisniknew.ImeKorisnika,
                PrezimeKorisnika = korisniknew.PrezimeKorisnika,
                KorisnickoIme = korisniknew.KorisnickoIme
            };



        }
        public Korisnik GetByKorisnickoIme(string KorisnickoIme)
        {
            return context.Korisnik.FirstOrDefault(e => e.KorisnickoIme == KorisnickoIme);
        }
    }
}
