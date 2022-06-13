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
    [Route("api/Izvedba")]
    public class IzvedbaController : ControllerBase
    {
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly IIzvedbaRepository izvedbaRepository;

        public IzvedbaController(LinkGenerator linkGenerator, IMapper mapper, IIzvedbaRepository izvedbaRepository)
        {
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.izvedbaRepository = izvedbaRepository;
        }

        [HttpGet]
  //      [Authorize]
        public ActionResult<List<IzvedbaDTO>> GetIzvedbaSve()
        {
            
            var izvedbe = izvedbaRepository.GetIzvedba();
            if (izvedbe == null || izvedbe.Count == 0)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<IzvedbaDTO>>(izvedbe));
        }

        
        [HttpGet("{IzvedbaID}")]
 //       [Authorize]
        public ActionResult<IzvedbaDTO> GetIzvedba(Guid IzvedbaID)
        {
            var izvedba = izvedbaRepository.GetIzvedbaById(IzvedbaID);
                if (izvedba == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<IzvedbaDTO>(izvedba));
        }
        [HttpPost]
       [Authorize(Roles = "admin")]
        public ActionResult<IzvedbaConfirmationDTO> CreateIzvedba([FromBody] IzvedbaCreationDTO izvedba)
        {
            try
            {
                Izvedba izvedbaEntity = mapper.Map<Izvedba>(izvedba);
                IzvedbaConfirmation confirmation = izvedbaRepository.CreateIzvedba(izvedbaEntity);

                izvedbaRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetIzvedbaSve", "Izvedba", new { confirmation.IzvedbaID });
                return Created(location, mapper.Map<IzvedbaConfirmationDTO>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");

            }
        }
        [HttpDelete("{IzvedbaID}")]
 //       [Authorize(Roles = "admin")]
        public IActionResult DeleteIzvedba(Guid IzvedbaID)
        {
            try
            {
                var izvedba = izvedbaRepository.GetIzvedbaById(IzvedbaID);
                if (izvedba == null)
                {
                    return NotFound();
                }
                izvedbaRepository.DeleteIzvedba(IzvedbaID);
                izvedbaRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status412PreconditionFailed, "Nemoguce je obrisati izvedbu dok postoje aktivne rezervacije.");
            }
        }
        [HttpPut("{IzvedbaID}")]
        [Authorize(Roles = "admin")]
        public ActionResult<IzvedbaConfirmationDTO> UpdateIzvedba (IzvedbaUpdateDTO izvedba)
        {
            try
            {
                if (izvedbaRepository.GetIzvedbaById(izvedba.IzvedbaID) == null)
                {
                    return NotFound();
                }
                Izvedba izvedba2 = mapper.Map<Izvedba>(izvedba);
                IzvedbaConfirmation confirmation = izvedbaRepository.UpdateIzvedba(izvedba2);
                izvedbaRepository.SaveChanges();
                return Ok(mapper.Map<IzvedbaConfirmationDTO>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Error");
            }
        }
        [HttpOptions]
        public IActionResult GetIzvedbaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
  //      [Authorize(Roles = "admin")]
        [HttpGet("predstava/{PredstavaID}")]
        public ActionResult<List<IzvedbaDTO>> GetSveIzvedbePredstave(Guid PredstavaID)
        {
            List<Izvedba> izvedbe = izvedbaRepository.GetSveIzvedbePredstave(PredstavaID);
            if (izvedbe == null || izvedbe.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<IzvedbaDTO>>(izvedbe));
        }
        [HttpGet("pozoriste/{PozoristeID}")]
        public ActionResult<List<IzvedbaDTO>> GetRepertoarPozorista(Guid PozoristeID)
        {
            List<Izvedba> izvedbe = izvedbaRepository.GetRepertoarPozorista(PozoristeID);
            if (izvedbe == null || izvedbe.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<IzvedbaDTO>>(izvedbe));
        }
    }
}
