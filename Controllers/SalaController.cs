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
    [Route("api/sala")]

    public class SalaController : ControllerBase
    {
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ISalaRepository salaRepository;

        public SalaController(LinkGenerator linkGenerator, IMapper mapper, ISalaRepository salaRepository)
        {
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.salaRepository = salaRepository;
        }
        [HttpGet]
   //     [Authorize]
        public ActionResult<List<SalaDTO>> GetSalaSve() {
            var sale = salaRepository.GetSala();
            if (sale == null || sale.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<SalaDTO>>(sale));
        }
        [HttpGet("{SalaID}")]
    //    [Authorize]
        public ActionResult<SalaDTO> GetSala(Guid SalaID)
        {
            var sala = salaRepository.GetSalaById(SalaID);
            if (sala == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<SalaDTO>(sala));
        }
        [HttpPost]
    //    [Authorize(Roles = "admin")]
        public ActionResult<SalaConfirmationDTO> CreateSala([FromBody] SalaCreationDTO sala)
        {
            try
            {
                Sala salaEntity = mapper.Map<Sala>(sala);
                SalaConfirmation confirmation = salaRepository.CreateSala(salaEntity);

                salaRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetSalaSve", "Sala", new { confirmation.SalaID });
                return Created(location, mapper.Map<SalaConfirmationDTO>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");

            }
        }
        [HttpDelete]
   //     [Authorize(Roles = "admin")]
        public IActionResult DeleteSala(Guid salaID)
        {
            try
            {
                var sala = salaRepository.GetSalaById(salaID);
                if (sala == null)
                {
                    return NotFound();
                }
                salaRepository.DeleteSala(salaID);
                salaRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        [HttpPut("{SalaID}")]
     //   [Authorize(Roles = "admin")]
        public ActionResult<SalaConfirmationDTO> UpdateSala (SalaUpdateDTO sala)
        {
            try
            {
                if (salaRepository.GetSalaById(sala.SalaID) == null)
                {
                    return NotFound();
                }
                Sala sala2 = mapper.Map<Sala>(sala);
                SalaConfirmation confirmation = salaRepository.UpdateSala(sala2);
                salaRepository.SaveChanges();
                return Ok(mapper.Map<SalaConfirmation>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        
        
    }
}
