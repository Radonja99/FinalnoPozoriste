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

    [Route("api/predstava")]
    public class PredstavaController : ControllerBase
    {
        private readonly IPredstavaRepository predstavaRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public PredstavaController(IPredstavaRepository predstavaRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.predstavaRepository = predstavaRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<List<PredstavaDTO>> GetPredstaveSve(string? zanr)
        {
            var predstave = predstavaRepository.GetPredstava(zanr);
            if (predstave == null || predstave.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<PredstavaDTO>>(predstave));
        }

        [HttpGet("{PredstavaID}")]
        public ActionResult<PredstavaDTO> GetPredstava(Guid PredstavaID)
        {
            var predstava = predstavaRepository.GetPredstavaById(PredstavaID);
            if (predstava == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PredstavaDTO>(predstava));

        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult<PredstavaConfirmationDTO> CreatePredstava([FromBody] PredstavaCreationDTO predstava)
        {
            try
            {
                Predstava predstavaEntity = mapper.Map<Predstava>(predstava);
                PredstavaConfirmation confirmation = predstavaRepository.CreatePredstava(predstavaEntity);

                predstavaRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetPredstaveSve", "Predstava", new { PredstavaID = confirmation.PredstavaID });
                return Created(location, mapper.Map<PredstavaConfirmationDTO>(confirmation));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.GetBaseException().Message);

            }
        }

        [HttpDelete("{PredstavaID}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeletePredstava(Guid PredstavaID)
        {
            try
            {
                var predstava = predstavaRepository.GetPredstavaById(PredstavaID);
                if (predstava == null)
                {
                    return NotFound();
                }
                predstavaRepository.DeletePredstava(PredstavaID);
                predstavaRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }
        [HttpPut("{PredstavaID}")]
        [Authorize(Roles = "admin")]
        public ActionResult<PredstavaConfirmationDTO> UpdatePredstava (PredstavaUpdateDTO predstava)
        {
            try
            {
                if (predstavaRepository.GetPredstavaById(predstava.PredstavaID) == null)
                {
                    return NotFound();
                }
                Predstava predstava2 = mapper.Map<Predstava>(predstava);
                PredstavaConfirmation confirmation = predstavaRepository.UpdatePredstava(predstava2);
                predstavaRepository.SaveChanges();

                return Ok(mapper.Map<PredstavaDTO>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Error");
            }
        }
        [HttpOptions]
        public IActionResult GetPredstavaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
      /*  [HttpGet("pozoriste/{PozoristeID}")]
        public ActionResult<List<PredstavaDTO>> GetPredstavaPoPozoristu(Guid pozoristeID)
        {
            List<Predstava> predstave = predstavaRepository.GetByPozoristeID(pozoristeID);
            if (predstave == null || predstave.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<PredstavaDTO>>(predstave));
        }
      */

    }
}
