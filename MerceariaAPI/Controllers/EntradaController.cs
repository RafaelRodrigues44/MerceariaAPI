using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntradaController : ControllerBase
    {
        private readonly IRepository<Entrada> _entradaRepository;

        public EntradaController(IRepository<Entrada> entradaRepository)
        {
            _entradaRepository = entradaRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entradas = _entradaRepository.GetAll();
            return Ok(entradas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entrada = _entradaRepository.GetById(id);
            if (entrada == null)
            {
                return NotFound();
            }
            return Ok(entrada);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Entrada entrada)
        {
            _entradaRepository.Add(entrada);
            return CreatedAtAction(nameof(GetById), new { id = entrada.EntradaId }, entrada);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Entrada entrada)
        {
            var existingEntrada = _entradaRepository.GetById(id);
            if (existingEntrada == null)
            {
                return NotFound();
            }
            _entradaRepository.Update(entrada);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entrada = _entradaRepository.GetById(id);
            if (entrada == null)
            {
                return NotFound();
            }
            _entradaRepository.Delete(entrada);
            return NoContent();
        }
    }
}
