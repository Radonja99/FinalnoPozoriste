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
    public class SalaProfile : Profile
    {
        public SalaProfile()
        {
            CreateMap<Sala, SalaDTO>();
            CreateMap<SalaCreationDTO, Sala>();
            CreateMap<SalaUpdateDTO, Sala>();
            CreateMap<SalaConfirmation, SalaConfirmationDTO>();
            CreateMap<Sala, SalaConfirmation>();
        }
    }
}
