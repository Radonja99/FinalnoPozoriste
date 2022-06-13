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
    public class SalaRepository : ISalaRepository
    {
        private readonly PozoristeContext context;
        private readonly IMapper mapper;

        public SalaRepository(PozoristeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public SalaConfirmation CreateSala(Sala sala)
        {
            var createdEntity = context.Add(sala);
            return mapper.Map<SalaConfirmation>(createdEntity.Entity);
        }

        public void DeleteSala(Guid SalaId)
        {
            var sala = GetSalaById(SalaId);
            context.Remove(sala);
        }

        public List<Sala> GetSala()
        {
            return context.Sala.Include(g=>g.Pozoriste).Include(g=>g.Pozoriste.Urednik).ToList();
        }

        public Sala GetSalaById(Guid SalaId)
        {
            return context.Sala.Include(g => g.Pozoriste).Include(g => g.Pozoriste.Urednik).FirstOrDefault(e => e.SalaID == SalaId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public SalaConfirmation UpdateSala(Sala sala)
        {
            var salaold = GetSalaById(sala.SalaID);

            salaold.SalaID = sala.SalaID;
            salaold.NazivSale = sala.NazivSale;

            return new SalaConfirmation()
            {
                SalaID = salaold.SalaID,
                NazivSale = salaold.NazivSale
            };
        }
    }
}
