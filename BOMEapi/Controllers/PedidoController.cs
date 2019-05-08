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
    public class PedidoController : ControllerBase
    {
        // GET: api/Pedido
        [HttpGet]
        public List<Pedido> GetAll()
        {
            return new Pedido().GetPedidos();
        }

        // GET: api/Pedido/Vendedor/5
        [HttpGet("/Vendedor/{id}")]
        public List<Pedido> GetPedidoVendedor(string id)
        {
            return new Pedido().GetPedidos().Where(x => x.usr_comercio.id == id).ToList();
        }
        // GET: api/Pedido/Transportador/5
        [HttpGet("/Transportador/{id}", Name = "Get")]
        public List<Pedido> GetPedidoTransportador(string id)
        {
            return new Pedido().GetPedidos().Where(x => x.transportador.id == id).ToList();
        }

        // POST: api/Pedido
        [HttpPost]
        public IActionResult PostPedido([FromBody]Pedido pedido)
        {
            if (pedido.isValid())
            {
                new Pedido().InsertPedido(pedido);
                return Ok("Pedido Cadastrado com sucesso!");
            }
            return BadRequest("Erro ao cadastrar pedido!");
        }

        // PUT: api/Pedido/5
        [HttpPut]
        [Route("{id_pedido}")]
        public IActionResult PutPedidoTransportador(string id_pedido, [FromBody]string id_transportador)
        {
            if (!string.IsNullOrEmpty(id_pedido) || !string.IsNullOrWhiteSpace(id_pedido) || !(id_pedido.Length < 36))
            {
                if (!string.IsNullOrEmpty(id_transportador) || !string.IsNullOrWhiteSpace(id_transportador) || !(id_pedido.Length < 36))
                {
                    new Pedido().UpdatePedidoTrans(id_pedido, id_transportador);
                    return Ok("Pedido atualizado com sucesso!");
                }
                return BadRequest("Erro ao atualizar pedido!");
            }
            return BadRequest("Erro ao atualizar pedido!");
        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
