using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Entities.Models;
using Entities.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetControlBackend.Models.ContactModel;

namespace PetControlBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;
        public ContactController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpPost]
        public IActionResult AddContact([FromBody] ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (contactDto.FirstPetId == contactDto.SecondPetId)
            {
                return BadRequest("FirstPetId is equal to SecondPetId");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ContactDto, Contact>());
            var mapper = new Mapper(config);
            Contact contact = mapper.Map<ContactDto, Contact>(contactDto);

            Pet FirstPet = _repoWrapper.Pet
                .FindByCondition(p => p.Id == contact.FirstPetId)
                .FirstOrDefault();
            if (FirstPet == null)
            {
                return NotFound("FirstPetId not found");
            }

            Pet SecondPet = _repoWrapper.Pet
                .FindByCondition(p => p.Id == contact.SecondPetId)
                .FirstOrDefault();
            if (SecondPet == null)
            {
                return NotFound("SecondPetId not found");
            }
            _repoWrapper.Contact.Create(contact);
            _repoWrapper.Save();

            return Ok(new { Success = true });
        }

        [HttpGet("{petId}")]
        public IActionResult GetContactByPetId(Guid petId, [FromQuery] ContactParameters parametrs)
        {
            PagedList<Contact> contacts = _repoWrapper.Contact
                .FindByCondition(parametrs, c => c.FirstPetId == petId);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(contacts.MetaData));

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Contact, ContactViewModel>());
            var mapper = new Mapper(config);
            IEnumerable<ContactViewModel> contactsView = mapper
                .Map<IEnumerable<Contact>, IEnumerable<ContactViewModel>>(contacts);

            return Ok(contacts);
        }
    }
}
