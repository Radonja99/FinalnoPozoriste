using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public class RezervacijaRepository : IRezervacijaRepository
    {
        private readonly PozoristeContext context;
        private readonly IMapper mapper;

        public RezervacijaRepository(PozoristeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public bool Checker(Rezervacija rezervacija)
        {
            IIzvedbaRepository izvedbaRepository = new IzvedbaRepository(context, mapper);
            Izvedba izvedba;
            izvedba = izvedbaRepository.GetIzvedbaById(rezervacija.IzvedbaID);
            if (izvedba.BrojSlobodnihMesta > rezervacija.BrojMesta)
            {
                return false;
            }
            return true;
        }
        public bool Checker2Korisnik(Rezervacija rezervacija)
        {
            IKorisnikRepository korisnikRepository = new KorisnikRepository(context, mapper);
            Korisnik korisnik;
            korisnik = korisnikRepository.GetKorisnikById(rezervacija.KorisnikID);
            if (korisnik.BrojRezervacija + rezervacija.BrojMesta < 15)
            {
                return false;
            }
            return true;
        }
        public RezervacijaConfirmation CreateRezervacija(Rezervacija rezervacija)
        {
            var createdEntity = context.Add(rezervacija);
            return mapper.Map<RezervacijaConfirmation>(createdEntity.Entity);
        }

        public void DeleteRezervacija(Guid RezervacijaId)
        {
            var rezervacija = GetRezervacijaById(RezervacijaId);
            context.Remove(rezervacija);
        }

        public List<Rezervacija> GetRezervacija()
        {
            return context.Rezervacija.Include(g=>g.Izvedba).Include(g=>g.Korisnik).Include(g=>g.Izvedba.Sala).Include(g=>g.Izvedba.Predstava).Include(g=>g.Izvedba.Sala.Pozoriste).ToList();
        }

        public Rezervacija GetRezervacijaById(Guid RezervacijaId)
        {
            return context.Rezervacija.FirstOrDefault(e => e.RezervacijaID == RezervacijaId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public RezervacijaConfirmation UpdateRezervacija(Rezervacija rezervacija)
        {
            Rezervacija rezervacijaold = GetRezervacijaById(rezervacija.RezervacijaID);
            //     rezervacijaold.RezervacijaID = rezervacija.RezervacijaID;
            //     rezervacijaold.DatumKreiranjaRezervacije = rezervacija.DatumKreiranjaRezervacije;
            rezervacija.Placeno = true;
            rezervacijaold.Placeno = true;

            return new RezervacijaConfirmation()
            {
                RezervacijaID = rezervacijaold.RezervacijaID,
                DatumKreiranjaRezervacije = rezervacijaold.DatumKreiranjaRezervacije,
               
                
            };
        }
        public List<Rezervacija> GetSveRezervacijeKorisnika(Guid id)
        {
            return context.Rezervacija
                .Include(g => g.Izvedba)
                .Include(g => g.Korisnik)
                .Include(g => g.Izvedba.Sala)
                .Include(g => g.Izvedba.Predstava)
                .Include(g => g.Izvedba.Sala.Pozoriste)
                .Where(a=>a.Korisnik.KorisnikID == id)
                .ToList();
        }
    }
}
