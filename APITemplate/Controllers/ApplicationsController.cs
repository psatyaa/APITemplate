using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITemplate.Domain.Models;
using APITemplate.Domain.Resources.Responses;
using APITemplate.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace APITemplate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : Controller
    {
        private readonly IApplicationService _appService;
        private readonly IMapper _mapper;
        public ApplicationsController(IApplicationService appService, IMapper mapper)
        {
            _appService = appService;
            _mapper = mapper;
        }

        // GET: api/Applications
        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<ApplicationResource>> Get()
        {
            var applications = await _appService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Application>, IEnumerable<ApplicationResource>>(applications);
            return resource;
        }

    }
}