using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetControlBackend.Models.VaccinationModel;

namespace PetControlBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VaccinationController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;
        public VaccinationController(IRepositoryWrapper repoWrapper)

        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet("{petId}")]
        public IActionResult GetByPetId(Guid petId)
        {
            IEnumerable<Vaccination> vaccination = _repoWrapper.Vaccination
                .FindByCondition(v => v.PetId == petId);

            return Ok(vaccination);
        }

        [HttpPost]
        public IActionResult AddVaccination([FromBody] VaccinationDto vaccinationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Pet pet = _repoWrapper.Pet
                .FindByCondition(p => p.Id == vaccinationDto.PetId && 
                    p.UserId.ToString() == userId)
                .FirstOrDefault();

            if (pet == null)
            {
                return BadRequest("PetId is incorrect");
            }
           

            var config = new MapperConfiguration(cfg => cfg.CreateMap<VaccinationDto, Vaccination>());
            var mapper = new Mapper(config);
            Vaccination vaccination = mapper.Map<VaccinationDto, Vaccination>(vaccinationDto);

            _repoWrapper.Vaccination.Create(vaccination);
            _repoWrapper.Save();

            return Ok(new { Success = true });
        }
    }
}
