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
    public class SedisteProfile : Profile

    {
        public SedisteProfile()
        {
            CreateMap<Sediste, SedisteDTO>();
            CreateMap<SedisteCreationDTO,Sediste>();
            CreateMap<SedisteUpdateDTO, Sediste>();
            CreateMap<SedisteConfirmation, SedisteConfirmationDTO>();
            CreateMap<Sediste, SedisteConfirmation>();
        }
    }
}
