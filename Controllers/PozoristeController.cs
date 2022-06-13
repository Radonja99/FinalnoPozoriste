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
    [Route("api/pozoriste")]

    public class PozoristeController : ControllerBase
    {
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly IPozoristeRepository pozoristeRepository;

        public PozoristeController(LinkGenerator linkGenerator, IMapper mapper, IPozoristeRepository pozoristeRepository)
        {
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.pozoristeRepository = pozoristeRepository;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<PozoristeDTO>> getPozoristeSve()
        {
            var pozorista = pozoristeRepository.GetPozoriste();
            if ( pozorista == null || pozorista.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<PozoristeDTO>>(pozorista));
        }
        [HttpGet("{pozoristeID}")]
        [Authorize(Roles = "admin")]
        public ActionResult<PozoristeDTO> getPozoriste(Guid pozoristeID)
        {
            var pozoriste = pozoristeRepository.GetPozoristeById(pozoristeID);
            if (pozoriste == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PozoristeDTO>(pozoriste));
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult<PozoristeConfirmationDTO> CreatePozoriste ([FromBody] PozoristeCreationDTO pozoriste)
        {
            try
            {
                Pozoriste pozoristeEntity = mapper.Map<Pozoriste>(pozoriste);
                PozoristeConfirmation confirmation = pozoristeRepository.CreatePozoriste(pozoristeEntity);

                pozoristeRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetPozoristeSve", "Pozoriste", new { PozoristeID = confirmation.PozoristeID });
                return Created(location, mapper.Map<PozoristeConfirmationDTO>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");

            }
        }
        [HttpDelete("{pozoristeID}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeletePozoriste (Guid pozoristeID)
        {
            try
            {
                var pozoriste = pozoristeRepository.GetPozoristeById(pozoristeID);
                if (pozoriste == null)
                {
                    return NotFound();
                }
                pozoristeRepository.DeletePozoriste(pozoristeID);
                pozoristeRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        [HttpPut("{PozoristeID}")]
        [Authorize(Roles = "admin")]
        public ActionResult<PozoristeConfirmationDTO> updatePozoriste (PozoristeUpdateDTO pozoriste)
        {
            try
            {
                if (pozoristeRepository.GetPozoristeById(pozoriste.PozoristeID)== null)
                {
                    return NotFound();
                }
                Pozoriste pozoriste2 = mapper.Map<Pozoriste>(pozoriste);
                PozoristeConfirmation confirmation = pozoristeRepository.UpdatePozoriste(pozoriste2);

                pozoristeRepository.SaveChanges();
                return Ok(mapper.Map<PozoristeConfirmation>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
        }
    }