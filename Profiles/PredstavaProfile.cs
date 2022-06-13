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
    public class PredstavaProfile : Profile
    {
        public PredstavaProfile ()
        {
            CreateMap <Predstava, PredstavaDTO > ();

            CreateMap<PredstavaCreationDTO, Predstava>();

            CreateMap<PredstavaUpdateDTO, Predstava>();

            CreateMap<PredstavaConfirmation, PredstavaConfirmationDTO>();

            CreateMap <Predstava, PredstavaConfirmation > ();
        }
    }
}
