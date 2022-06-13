using AutoMapper;
using PozoristeProjekat.DTOs;
using PozoristeProjekat.DTOs.Confirmations;
using PozoristeProjekat.DTOs.Creations;
using PozoristeProjekat.DTOs.Updates;
using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Profiles
{
    public class IzvedbaProfile : Profile
    {
        public IzvedbaProfile()
        {
            CreateMap<Izvedba, IzvedbaDTO>();

            CreateMap<IzvedbaCreationDTO, Izvedba>();

            CreateMap<IzvedbaUpdateDTO, Izvedba>();

            CreateMap<IzvedbaConfirmation, IzvedbaConfirmationDTO>();

            CreateMap<Izvedba, IzvedbaConfirmation>();
        }
    }
}
