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
using Microsoft.EntityFrameworkCore;
using PetControlBackend.Models.PetModel;

namespace PetControlBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PetController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public PetController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetPetById(string id)
        {
            if (id != null && Guid.TryParse(id, out Guid petId))
            {
                Pet pet = _repoWrapper.Pet
                    .FindByCondition(p => p.Id == petId)
                    .FirstOrDefault();

                if (pet == null)
                {
                    return NotFound();
                }

                return Ok(pet);
            }
            return BadRequest("PetId is incorrect");
        }

        [HttpGet, Route("list")]
        public IActionResult GetPetsByUserId()
        {
            string userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdStr != null && Guid.TryParse(userIdStr, out Guid userId))
            {
                IEnumerable<Pet> pets = _repoWrapper.Pet
                    .FindByCondition(p => p.UserId == userId);
                if (pets == null)
                {
                    return NotFound();
                }

                return Ok(pets);
            }

            return BadRequest("UserId is incorrect");
        }

        [HttpPost]
        public IActionResult CreatePet([FromBody] PetViewModel petView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdStr != null && Guid.TryParse(userIdStr, out Guid userId))
            {
                var mapper = new Mapper(new MapperConfiguration(cfg => 
                    cfg.CreateMap<PetViewModel, Pet>()));
                Pet pet = mapper.Map<PetViewModel, Pet>(petView);
                pet.UserId = userId;

                _repoWrapper.Pet.Create(pet);
                _repoWrapper.Save();

                return Ok(new { Success = true });
            }

            return BadRequest("Token is incorrect");
        }

        [HttpDelete("{id}")]
        public IActionResult RemovePetById(string id)
        {
            if (id != null && Guid.TryParse(id, out Guid petId))
            {
                Pet pet = _repoWrapper.Pet
                    .FindByCondition(p => p.Id == petId)
                    .FirstOrDefault();

                if (pet == null)
                {
                    return NotFound();
                }

                _repoWrapper.Pet.Delete(pet);
                _repoWrapper.Save();

                return Ok(new { Success = true });
            }

            return BadRequest("PetId is incorrect");
        }
    }
}
