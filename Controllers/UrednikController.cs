using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PozoristeProjekat.DTOs;
using PozoristeProjekat.DTOs.Base;
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
    [Route("api/urednik")]
    public class UrednikController : ControllerBase
    {
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly IUrednikRepository urednikRepository;
        private readonly IJWTAuth _jwtAuth;

        public UrednikController(LinkGenerator linkGenerator, IMapper mapper, IUrednikRepository urednikRepository, IJWTAuth jWTAuth)
        {
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.urednikRepository = urednikRepository;
            _jwtAuth = jWTAuth;
        }

        [HttpGet]
  //      [Authorize]
        //      [Authorize]
        public ActionResult<List<UrednikDTO>> GetUrednikSve()
        {
            var urednici = urednikRepository.GetUrednik();
            if (urednici == null || urednici.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<UrednikDTO>>(urednici));
        }
        [HttpGet("{urednikID}")]
   //     [Authorize(Roles = "admin")]
        public ActionResult<UrednikDTO> GetUrednik(Guid urednikID)
        {
            var urednik = urednikRepository.GetUrednikById(urednikID);
            if (urednik == null)
            {
                return NotFound();

            }
            return Ok(mapper.Map<UrednikDTO>(urednik));
        }
        [HttpPost]
    //    [Authorize(Roles = "admin")]
        public ActionResult<UrednikConfirmationDTO> CreateUrednik ([FromBody] UrednikCreationDTO urednik)
        {
            try
            {
                Urednik urednikEntity = mapper.Map<Urednik>(urednik);
                UrednikConfirmation confirmation = urednikRepository.CreateUrednik(urednikEntity);

                urednikRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetUrednikSve", "Urednik", new { UrednikID = confirmation.UrednikID });
                return Created(location, mapper.Map<UrednikConfirmationDTO>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");

            }
        }
        [HttpDelete("{urednikID}")]
  //      [Authorize(Roles = "admin")]
        public IActionResult DeleteUrednik(Guid urednikID)
        {
            try
            {
                var urednik = urednikRepository.GetUrednikById(urednikID);
                if ( urednik == null)
                {
                    return NotFound();

                }
                urednikRepository.DeleteUrednik(urednikID);
                urednikRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        [HttpPut("{UrednikID}")]
  //      [Authorize(Roles = "admin")]
        public ActionResult<UrednikConfirmationDTO> UpdateUrednik (UrednikUpdateDTO urednik)
        {
            try
            {
                if (urednikRepository.GetUrednikById(urednik.UrednikID) == null)
                {
                    return NotFound();
                }
                Urednik urednik2 = mapper.Map<Urednik>(urednik);
                UrednikConfirmation confirmation = urednikRepository.UpdateUrednik(urednik2);
                urednikRepository.SaveChanges();
                return Ok(mapper.Map<UrednikConfirmation>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        //[AllowAnonymous]
        // POST api/<MembersController>
    /*    [HttpPost("login")]
        public IActionResult Authentication([FromBody] UrednikLoginDTO urednik)
        {
            Urednik urednikModel = urednikRepository.GetByKorisnickoIme(urednik.KorisnickoImeUrednika);
            if (urednikModel == null || urednikModel.LozinkaUrednika != urednik.LozinkaUrednika)
            {
                return Unauthorized();
            }
            var token = _jwtAuth.Authentication(urednik.KorisnickoImeUrednika, urednik.LozinkaUrednika);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    */ }
    }
