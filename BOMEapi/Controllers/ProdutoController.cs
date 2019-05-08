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
    public class ProdutoController : ControllerBase
    {
        // GET: api/Produto
        [HttpGet]
        public List<Produto> GetAllProdutos()
        {
            return new Produto().getAll();
        }

        // GET: api/Produto/5
        [HttpGet("/Pedido/{id}")]
        public List<Produto> GetProdutosPedido(string id)
        {
            return new Produto().getProdutosPedido(id);
        }

        // POST: api/Produto
        [HttpPost]
        public IActionResult PostProduto([FromBody]Produto produto)
        {
            if (produto.isValid())
            {
                Produto.Insert(produto);
                return Ok("Produto cadastrado com sucesso");
            }
            else
            {
                return BadRequest("Falha no cadastro do produto!");
            }
        }

        //// PUT: api/Produto/5
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
