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
            // Aqui você pode implementar a lógica necessária para criar uma nova venda
            // Por exemplo, validar os dados da venda e salvar no banco de dados
            _repository.Add(venda);
            return CreatedAtAction(nameof(GetById), new { id = venda.VendaId }, venda);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Venda venda)
        {
            var existingVenda = _repository.GetById(id);
            if (existingVenda == null)
            {
                return NotFound();
            }
            // Aqui você pode implementar a lógica necessária para atualizar uma venda existente
            // Por exemplo, validar os dados da venda e atualizar no banco de dados
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
            // Aqui você pode implementar a lógica necessária para excluir uma venda
            // Por exemplo, excluir a venda do banco de dados
            _repository.Delete(venda);
            return NoContent();
        }
    }
}
