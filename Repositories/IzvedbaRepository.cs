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
    public class IzvedbaRepository : IIzvedbaRepository
    {
        private readonly PozoristeContext context;
        private readonly IMapper mapper;

        public IzvedbaRepository(PozoristeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IzvedbaConfirmation CreateIzvedba(Izvedba izvedba)
        {
            Console.Write(izvedba);
            var createdEntity = context.Add(izvedba);
            
            return mapper.Map<IzvedbaConfirmation>(createdEntity.Entity);

        }

        public void DeleteIzvedba(Guid IzvedbaId)
        {
            var Izvedba = GetIzvedbaById(IzvedbaId);
            context.Remove(Izvedba);
        }

        public List<Izvedba> GetIzvedba()
        {
             return context.Izvedba.Include(g => g.Sala).Include(g => g.Predstava).Include(g => g.Sala.Pozoriste).Include(g => g.Sala.Pozoriste.Urednik).ToList();

        }

        public Izvedba GetIzvedbaById(Guid IzvedbaId)
        {
            return context.Izvedba.Include(g => g.Sala).Include(g => g.Predstava).Include(g => g.Sala.Pozoriste).Include(g => g.Sala.Pozoriste.Urednik).FirstOrDefault(e=> e.IzvedbaID == IzvedbaId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public IzvedbaConfirmation UpdateIzvedba(Izvedba izvedba)
        {
            Izvedba izvedbaold = GetIzvedbaById(izvedba.IzvedbaID);

            izvedbaold.IzvedbaID = izvedba.IzvedbaID;
            izvedbaold.SalaID = izvedba.SalaID;
            izvedbaold.Cena = izvedba.Cena;
            izvedbaold.BrojSlobodnihMesta = izvedba.BrojSlobodnihMesta;
            izvedbaold.PredstavaID = izvedba.PredstavaID;
            izvedbaold.GostujucaPredstava = izvedba.GostujucaPredstava;
            izvedbaold.DatumPrikazivanja = izvedba.DatumPrikazivanja;
            return new IzvedbaConfirmation
            {
                IzvedbaID = izvedba.IzvedbaID,
                DatumPrikazivanja = izvedba.DatumPrikazivanja
            };
        }
        public List<Izvedba> GetSveIzvedbePredstave(Guid id)
        {
            return context.Izvedba
                .Include(a=>a.Predstava)
                .Include(a=>a.Sala)
                .Include(a=>a.Sala.Pozoriste)
                .Where(a=>a.PredstavaID == id)
                .ToList();

        }
        public List<Izvedba> GetRepertoarPozorista(Guid id)
        {
            return context.Izvedba
                .Include(a => a.Predstava)
                .Include(a => a.Sala)
                .Include(a => a.Sala.Pozoriste)
                .Where(a => a.Sala.PozoristeID == id)
                .ToList();
        }

    }
    
}
