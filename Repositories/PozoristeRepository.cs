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
    public class PozoristeRepository : IPozoristeRepository
    {
        private readonly PozoristeContext context;
        private readonly IMapper mapper;

        public PozoristeRepository(PozoristeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public PozoristeConfirmation CreatePozoriste(Pozoriste pozoriste)
        {
            var createdEntity = context.Add(pozoriste);
            return mapper.Map<PozoristeConfirmation>(createdEntity.Entity);
        }

        public void DeletePozoriste(Guid PozoristeId)
        {
            var pozoriste = GetPozoristeById(PozoristeId);
            context.Remove(pozoriste);
        }

        public List<Pozoriste> GetPozoriste()
        {
            return context.Pozoriste.Include(g=>g.Urednik).ToList();
        }

        public Pozoriste GetPozoristeById(Guid PozoristeId)
        {
            return context.Pozoriste.Include(g => g.Urednik).FirstOrDefault(e => e.PozoristeID == PozoristeId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public PozoristeConfirmation UpdatePozoriste(Pozoriste pozoriste)
        {
            Pozoriste pozoristeold = GetPozoristeById(pozoriste.PozoristeID);

            pozoristeold.PozoristeID = pozoriste.PozoristeID;
            pozoristeold.NazivPozorista = pozoriste.NazivPozorista;
            return new PozoristeConfirmation()
            {
                NazivPozorista = pozoristeold.NazivPozorista,
                PozoristeID = pozoristeold.PozoristeID
            };
        }
    }
}
