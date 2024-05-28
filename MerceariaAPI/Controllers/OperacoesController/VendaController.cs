using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;
using System;
using System.Collections.Generic;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IRepository<Venda> _repository;

        public VendaController(IRepository<Venda> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var vendas = _repository.GetAll();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var venda = _repository.GetById(id);
            if (venda == null)
            {
                return NotFound();
            }
            return Ok(venda);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Venda venda)
        {
            if (venda == null)
            {
                return BadRequest();
            }

            // Aqui você pode adicionar a lógica necessária para calcular o total da venda
            // e validar se os produtos foram fornecidos corretamente

            _repository.Add(venda);
            return CreatedAtAction(nameof(GetById), new { id = venda.VendaId }, venda);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Venda venda)
        {
            if (venda == null || venda.VendaId != id)
            {
                return BadRequest();
            }

            var existingVenda = _repository.GetById(id);
            if (existingVenda == null)
            {
                return NotFound();
            }

            // Aqui você pode adicionar a lógica necessária para atualizar a venda

            _repository.Update(venda);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var venda = _repository.GetById(id);
            if (venda == null)
            {
                return NotFound();
            }

            // Aqui você pode adicionar a lógica necessária para excluir a venda

            _repository.Delete(venda);
            return NoContent();
        }
    }
}
