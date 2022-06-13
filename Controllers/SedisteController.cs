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
    [Route("api/sediste")]

    public class SedisteController : ControllerBase
    {
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ISedisteRepository sedisteRepository;

        public SedisteController(LinkGenerator linkGenerator, IMapper mapper, ISedisteRepository sedisteRepository)
        {
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.sedisteRepository = sedisteRepository;
        }
        [HttpGet]
 //       [Authorize(Roles = "admin")]
        public ActionResult<List<SedisteDTO>> GetSedistaSve()
        {
            var sedista = sedisteRepository.GetSedista();
            if (sedista == null || sedista.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<SedisteDTO>>(sedista));
        }
        [HttpGet("{sedisteID}")]
  //      [Authorize(Roles = "admin")]
        public ActionResult<SedisteDTO> GetSediste(Guid sedisteID)
        {
            var sediste = sedisteRepository.GetSedisteById(sedisteID);
            if (sediste == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<SedisteDTO>(sediste));
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult<SedisteConfirmationDTO> CreateSediste([FromBody] SedisteCreationDTO sediste)
        {
            try
            {
                Sediste sedisteEntity = mapper.Map<Sediste>(sediste);
                SedisteConfirmation confirmation = sedisteRepository.CreateSediste(sedisteEntity);

                sedisteRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetSedisteSve", "Sediste", new { confirmation.SedisteID });
                return Created(location, mapper.Map<SedisteConfirmationDTO>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");

            }
        }

        [HttpDelete("{sedisteID}")]
  //      [Authorize(Roles = "admin")]
       public IActionResult DeleteSediste(Guid sedisteID)
        {
            try
            {
                var sediste = sedisteRepository.GetSedisteById(sedisteID);
                if (sediste == null)
                {
                    return NotFound();
                }
                sedisteRepository.DeleteSediste(sedisteID);
                sedisteRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        [HttpPut("{SedisteID}")]
        [Authorize(Roles = "admin")]
        public ActionResult<SedisteConfirmationDTO> UpdateSediste (SedisteUpdateDTO sediste)
        {
            try
            {
                if (sedisteRepository.GetSedisteById(sediste.SedisteID)== null)
                {
                    return NotFound();
                }
                Sediste sediste2 = mapper.Map<Sediste>(sediste);
                SedisteConfirmation confirmation = sedisteRepository.UpdateSediste(sediste2);
                sedisteRepository.SaveChanges();
                return Ok(mapper.Map<SedisteConfirmation>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

}
    }
