using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mgrProject.Interfaces;
using mgrProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mgrProject.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        private readonly IGenerationValueServices _generation;

        public GeneratorController(IGenerationValueServices generation)
        {
            _generation = generation;
        }

    }
}
