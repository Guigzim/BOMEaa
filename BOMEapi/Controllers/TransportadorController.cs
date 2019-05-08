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
    public class TransportadorController : ControllerBase
    {
        // GET: api/Transportador
        [HttpGet]
        public List<Transportador> GetAllTransportadores()
        {
            return new Transportador().getAllTrasportador();
        }

        // GET: api/Transportador/5
        [HttpGet]
        [Route("{id}")]
        public Transportador GetTransportadorId(string id)
        {
            return new Transportador().getTransportadorId(id);
        }

        //// POST: api/Transportador
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        ////}

        //// PUT: api/Transportador/5
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
