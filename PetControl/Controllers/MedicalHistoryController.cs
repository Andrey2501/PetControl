using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetControlBackend.Models.MedicalHistoryModel;

namespace PetControlBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public MedicalHistoryController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet("{petId}")]
        public IActionResult GetByPetId(Guid petId)
        {
            IEnumerable<MedicalHistory> vaccination = _repoWrapper.MedicalHistory.FindByCondition(v => v.PetId == petId);

            return Ok(vaccination);
        }

        [HttpPost]
        public IActionResult AddMedicalHistory([FromBody] MedicalHistoryDto medicalHistoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pet pet = _repoWrapper.Pet.FindByCondition(p => p.Id == medicalHistoryDto.PetId).FirstOrDefault();

            if (pet == null)
            {
                return BadRequest("PetId is incorrect");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MedicalHistoryDto, MedicalHistory>());
            var mapper = new Mapper(config);
            MedicalHistory medicalHistory = mapper.Map<MedicalHistoryDto, MedicalHistory>(medicalHistoryDto);

            if (medicalHistory.EndDate == null)
            {
                pet.IsSick = true;
                _repoWrapper.Pet.Update(pet);
            }

            _repoWrapper.MedicalHistory.Create(medicalHistory);
            _repoWrapper.Save();

            return Ok(new { Success = true });
        }
    }
}
