using ImplementCors.Base.Controllers;
using ImplementCors.Models;
using ImplementCors.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCore.Models;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementCors.Controllers
{
    [Route("[controller]")]
    //[Authorize(Roles = "User")]
    public class PersonsController : BaseController<Person, PersonRepository, string>
    {
        PersonRepository personRepository;

        public PersonsController(PersonRepository personRepository) : base(personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpPost("RegisterData/")]
        public JsonResult RegisterData([FromBody]RegisterVM registerVM)
        {
            var result = personRepository.RegisterPerson(registerVM);
            return Json(result);
        }
        /*[HttpPost("Register")]
        public async Task<JsonResult> Register([FromBody]RegisterVM registerVM)
        {
            var result = await personRepository.Register(registerVM);
            return Json(result);
        }*/

        [HttpGet("GetAllData")]
        public async Task<JsonResult> GetAllData() {
            var result = await personRepository.GetAllProfile();
            return Json(result);
        }
        [HttpGet("GetById/{nik}")]
        public async Task<JsonResult> GetById(string nik) {
            var result = await personRepository.GetById(nik);
            return Json(result);
        }
        

    }
}
