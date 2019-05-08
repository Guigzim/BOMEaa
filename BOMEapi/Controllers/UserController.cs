using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOMEapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOMEapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //GET: api/User/T
       [HttpGet]
       [Route("tipo/{tipo}")]
        public List<User> GetUsersTipo(string tipo)
        {
            return new User().getUserTipo(tipo);
        }

        // GET: api/User/5
        [HttpGet]
        [Route("{id}")]

        public User GetUser(string id)
        {
            return new User().getUserId(id);
        }

        //// POST: api/User
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/User/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
