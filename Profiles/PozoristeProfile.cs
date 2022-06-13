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
    public class PozoristeProfile : Profile
    {
        public PozoristeProfile()
        {
            CreateMap <Pozoriste, PozoristeDTO > ();

            CreateMap<PozoristeCreationDTO, Pozoriste>();

            CreateMap<PozoristeUpdateDTO, Pozoriste>();

            CreateMap<PozoristeConfirmation, PozoristeConfirmationDTO>();

            CreateMap <Pozoriste, PozoristeConfirmation > ();
        }
    }
}
