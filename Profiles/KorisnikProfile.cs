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
    public class KorisnikProfile : Profile
    {
        public KorisnikProfile()
        {
            CreateMap<Korisnik, KorisnikDTO>();

            CreateMap<KorisnikCreationDTO, Korisnik>();

            CreateMap<KorisnikUpdateDTO, Korisnik>();

            CreateMap<KorisnikConfirmation, KorisnikConfirmationDTO>();

            CreateMap<Korisnik, KorisnikConfirmation>();
        }

    }
}
