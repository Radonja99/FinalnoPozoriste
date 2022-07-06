using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PozoristeProjekat.DTOs;
using PozoristeProjekat.DTOs.Confirmations;
using PozoristeProjekat.DTOs.Creations;
using PozoristeProjekat.DTOs.Updates;
using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using PozoristeProjekat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Controllers
{
    [Route("api/rezervacija")]

    public class RezervacijaController : ControllerBase
    {
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly IRezervacijaRepository rezervacijaRepository;

        public RezervacijaController(LinkGenerator linkGenerator, IMapper mapper, IRezervacijaRepository rezervacijaRepository)
        {
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.rezervacijaRepository = rezervacijaRepository;
        }
        [HttpGet]
        [Authorize]
        public ActionResult<List<RezervacijaDTO>> GetRezervacijaSve()
        {
            var rezervacije = rezervacijaRepository.GetRezervacija();
            if (rezervacije == null || rezervacije.Count == 0)
            {
            return NoContent();
            }
               return Ok(mapper.Map<List<RezervacijaDTO>>(rezervacije));
        }
        [HttpGet("{RezervacijaID}")]
        [Authorize]
        public ActionResult<RezervacijaDTO> GetRezervacija(Guid rezervacijaID)
        {
            var rezervacija = rezervacijaRepository.GetRezervacijaById(rezervacijaID);
            if (rezervacija == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RezervacijaDTO>(rezervacija));
        }
        [HttpPost]
        [Authorize]
        public ActionResult<RezervacijaConfirmationDTO> CreateRezervacija([FromBody] RezervacijaCreationDTO rezervacija)
        {
            try
            {
                Rezervacija rezervacijaEntity = mapper.Map<Rezervacija>(rezervacija);
                //       if (izvedbaRepository.GetIzvedbaById((Guid)rezervacijaEntity.IzvedbaID).BrojSlobodnihMesta< rezervacijaEntity.BrojMesta)
                //       {
                //          return StatusCode(StatusCodes.Status406NotAcceptable, "Nema dovoljno mesta za tu izvedbu.");
                //      }
                if (rezervacijaRepository.Checker(rezervacijaEntity)) 
                {
                           return StatusCode(StatusCodes.Status406NotAcceptable, "Nema dovoljno mesta za tu izvedbu.");
                }
                if (rezervacijaRepository.Checker2Korisnik(rezervacijaEntity))
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, "Prekoracili ste dozvoljen broj rezervacija!");
                }
                RezervacijaConfirmation confirmation = rezervacijaRepository.CreateRezervacija(rezervacijaEntity);
                rezervacijaRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetRezervacijaSve", "Rezervacija", new { confirmation.RezervacijaID });
                return Created(location, mapper.Map<RezervacijaConfirmationDTO>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");

            }
        }
        [HttpDelete("{RezervacijaID}")]
        [Authorize]
        public IActionResult DeleteRezervacija(Guid rezervacijaID)
        {
            try
            {
                var rezervacija = rezervacijaRepository.GetRezervacijaById(rezervacijaID);
                if (rezervacija == null)
                {
                    return NotFound();
                }
                rezervacijaRepository.DeleteRezervacija(rezervacijaID);
                rezervacijaRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        
        }
        [HttpPut("{RezervacijaID}")]
   //     [Authorize(Roles = "admin")]
        public ActionResult<RezervacijaConfirmationDTO> UpdateRezervacija (Guid rezervacijaID)
        {
            try
            {
                if (rezervacijaRepository.GetRezervacijaById(rezervacijaID) == null)
                {
                    return NotFound();
                }
                Rezervacija rezervacija2 = mapper.Map<Rezervacija>(GetRezervacija(rezervacijaID));
                RezervacijaConfirmation confirmation = rezervacijaRepository.UpdateRezervacija(rezervacija2.RezervacijaID);
                rezervacijaRepository.SaveChanges();
                return Ok(mapper.Map<RezervacijaConfirmation>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        [HttpGet("korisnik/{KorisnikID}")]
        [Authorize]
        public ActionResult<List<RezervacijaDTO>> GetSveRezervacijeKorisnika(Guid KorisnikID )
        {
            var rezervacije = rezervacijaRepository.GetSveRezervacijeKorisnika(KorisnikID);
            if (rezervacije == null || rezervacije.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<RezervacijaDTO>>(rezervacije));
        }

    }
}

    