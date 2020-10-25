using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetControlBackend.Models.UserModel;

namespace PetControlBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public UserController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public IActionResult GetUserById()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id != null && Guid.TryParse(id, out Guid userID))
            {
                User user = _repoWrapper.User
                    .FindByCondition(u => u.Id == userID)
                    .FirstOrDefault();

                if (user == null)
                {
                    return NotFound("User with id does not exist");
                }

                var config = new MapperConfiguration(cfg => 
                    cfg.CreateMap<User, UserViewModel>());
                var mapper = new Mapper(config);
                UserViewModel userView = mapper.Map<User, UserViewModel>(user);
                return Ok(userView);
            }

            return BadRequest("UserId is incorrect");
        }

        [HttpGet, Route("list"), Authorize(Roles = "Admin")]
        public IActionResult GetUserList()
        {
            IEnumerable<User> users = _repoWrapper.User.FindAll();
            return Ok(users);
        }
    }
}
