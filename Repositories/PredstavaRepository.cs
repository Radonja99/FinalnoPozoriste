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
    public class PredstavaRepository : IPredstavaRepository
    {
        private readonly PozoristeContext context;
        private readonly IMapper mapper;

        public PredstavaRepository (PozoristeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public PredstavaConfirmation CreatePredstava(Predstava predstava)
        {
            var createdEntity = context.Add(predstava);
            return mapper.Map<PredstavaConfirmation>(createdEntity.Entity);
        }

        public void DeletePredstava(Guid PredstavaId)
        {
            var predstava = GetPredstavaById(PredstavaId);
            context.Remove(predstava);
        }

        public List<Predstava> GetPredstava(string zanr)
        {
            return context.Predstava.
                Where(e => (zanr == null || e.Zanr == zanr))
                .ToList();
        }

        public Predstava GetPredstavaById(Guid PredstavaId)
        {
            return context.Predstava.FirstOrDefault(e => e.PredstavaID == PredstavaId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public PredstavaConfirmation UpdatePredstava(Predstava predstava)
        {
            Predstava predstavaold = GetPredstavaById(predstava.PredstavaID);

            predstavaold.PredstavaID = predstava.PredstavaID;
            predstavaold.NazivPredstave = predstava.NazivPredstave;
            predstava.Zanr = predstava.Zanr;

            return new PredstavaConfirmation()
            {
                PredstavaID = predstavaold.PredstavaID,
                NazivPredstave = predstavaold.NazivPredstave,
                Zanr = predstavaold.Zanr
            };
        }
        public List<Predstava> GetByPozoristeID(Guid id)
        {
                return context.Predstava.Include(a => a.PredstavaID)
                    .Include(a => a.NazivPredstave)
                    .Include(a => a.Zanr)
                    .Include(a => a.BrojIzvodjenja)
                    .Include(a => a.DatumPremijere)
                    .ToList();
            
        }
    }
}
