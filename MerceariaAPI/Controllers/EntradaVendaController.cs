using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntradaVendaController : ControllerBase
    {
        private readonly IRepository<EntradaVenda> _repository;

        public EntradaVendaController(IRepository<EntradaVenda> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var estoqueVendas = _repository.GetAll();
            return Ok(estoqueVendas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var estoqueVenda = _repository.GetById(id);
            if (estoqueVenda == null)
            {
                return NotFound();
            }
            return Ok(estoqueVenda);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EntradaVenda estoqueVenda)
        {
            _repository.Add(estoqueVenda);
            return CreatedAtAction(nameof(GetById), new { id = estoqueVenda.EntradaId }, estoqueVenda);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EntradaVenda entradaVenda)
        {
            var existingEntradaVenda = _repository.GetById(id);
            if (existingEntradaVenda == null)
            {
                return NotFound();
            }
            _repository.Update(entradaVenda);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entradaVenda = _repository.GetById(id);
            if (entradaVenda == null)
            {
                return NotFound();
            }
            _repository.Delete(entradaVenda);
            return NoContent();
        }
    }
}
