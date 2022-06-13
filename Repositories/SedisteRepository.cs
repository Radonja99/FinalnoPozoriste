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
    public class SedisteRepository : ISedisteRepository
    {
        private readonly PozoristeContext context;
        private readonly IMapper mapper;

        public SedisteRepository (PozoristeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public SedisteConfirmation CreateSediste(Sediste sediste)
        {
            var createdEntity = context.Add(sediste);
            return mapper.Map<SedisteConfirmation>(createdEntity.Entity);
        }

        public void DeleteSediste(Guid sedisteId)
        {
            var sediste = GetSedisteById(sedisteId);
            context.Remove(sediste);
        }

        public List<Sediste> GetSedista()
        {   
        return context.Sediste.Include(g=>g.Sala).ToList();
        }

        public Sediste GetSedisteById(Guid SedisteId)
        {
            return context.Sediste.Include(g => g.Sala).FirstOrDefault(e => e.SedisteID == SedisteId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public SedisteConfirmation UpdateSediste(Sediste sediste)
        {
            var sedisteold = GetSedisteById(sediste.SedisteID);

            sedisteold.SedisteID = sediste.SedisteID;
            sedisteold.Sektor = sediste.Sektor;
            sedisteold.BrojSedista = sediste.BrojSedista;
            sedisteold.BrojReda = sediste.BrojReda;


            return new SedisteConfirmation()
            {
                SedisteID = sedisteold.SedisteID,
                Sektor = sedisteold.Sektor,
                BrojSedista = sedisteold.BrojSedista,
                BrojReda = sedisteold.BrojReda
            };
        }
    }
}
