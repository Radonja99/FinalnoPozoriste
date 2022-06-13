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
    public class RezervacijaProfile : Profile
    {
        public RezervacijaProfile()
        {
            CreateMap <Rezervacija, RezervacijaDTO > ();

            CreateMap<RezervacijaCreationDTO, Rezervacija>();

            CreateMap<RezervacijaUpdateDTO, Rezervacija>();

            CreateMap<RezervacijaConfirmation, RezervacijaConfirmationDTO>();

            CreateMap <Rezervacija, RezervacijaConfirmation > ();
        }
    }
}
