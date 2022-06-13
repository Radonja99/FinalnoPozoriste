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
    public class UrednikProfile : Profile
    {
        public UrednikProfile()
        {
            CreateMap<Urednik, UrednikDTO>();
            CreateMap<UrednikCreationDTO, Urednik>();
            CreateMap<UrednikUpdateDTO, Urednik>();
            CreateMap<UrednikConfirmation, UrednikConfirmationDTO>();
            CreateMap<Urednik, UrednikConfirmation>();
        }
    }
}
