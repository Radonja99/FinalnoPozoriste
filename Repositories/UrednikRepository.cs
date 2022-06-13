using AutoMapper;
using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public class UrednikRepository : IUrednikRepository
    {
        private readonly PozoristeContext context;
        private readonly IMapper mapper;

        public UrednikRepository(PozoristeContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }
        public UrednikConfirmation CreateUrednik(Urednik urednik)
        {
            var createdEntity = context.Add(urednik);
            return mapper.Map<UrednikConfirmation>(createdEntity.Entity);
        }

        public void DeleteUrednik(Guid UrednikId)
        {
            var urednik = GetUrednikById(UrednikId);
            context.Remove(urednik);
        }

        public List<Urednik> GetUrednik()
        {
            return context.Urednik.ToList();
        }

        public Urednik GetUrednikById(Guid UrednikId)
        {
            return context.Urednik.FirstOrDefault(e => e.UrednikID == UrednikId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public UrednikConfirmation UpdateUrednik(Urednik urednik)
        {
            Urednik urednikold = GetUrednikById(urednik.UrednikID);

            urednikold.UrednikID = urednik.UrednikID;
            urednikold.ImeUrednika = urednik.ImeUrednika;
            urednikold.PrezimeUrednika = urednik.PrezimeUrednika;
            urednikold.KorisnickoImeUrednika = urednik.KorisnickoImeUrednika;
            return new UrednikConfirmation()
            {
                UrednikID = urednikold.UrednikID,
                ImeUrednika = urednikold.ImeUrednika,
                PrezimeUrednika = urednikold.PrezimeUrednika,
                KorisnickoImeUrednika = urednikold.KorisnickoImeUrednika
            };
        }
        public Urednik GetByKorisnickoIme(string KorisnickoImeUrednika)
        {
            return context.Urednik.FirstOrDefault(e => e.KorisnickoImeUrednika == KorisnickoImeUrednika);
        }
    }
}
