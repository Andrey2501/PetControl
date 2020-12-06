using AutoMapper;
using Contracts;
using Entities;
using Entities.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetControlBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public StatisticController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet, Route("list/country")]
        public IActionResult GetCountDeasesByCountry([FromQuery] StatisticParameters parameters)
        {
            PagedList<StatisticModel> statistics = _repoWrapper.Pet.GetStatisticConutries(parameters);
            var metadata = statistics.MetaData;
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(statistics);
        }
    }
}
