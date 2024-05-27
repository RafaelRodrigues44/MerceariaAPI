using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidaController : ControllerBase
    {
        private readonly IRepository<Bebida> _repository;

        public BebidaController(IRepository<Bebida> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bebidas = _repository.GetAll();
            return Ok(bebidas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bebida = _repository.GetById(id);
            if (bebida == null)
            {
                return NotFound();
            }
            return Ok(bebida);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Bebida bebida)
        {
            _repository.Add(bebida);
            return CreatedAtAction(nameof(GetById), new { id = bebida.Id }, bebida);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Bebida bebida)
        {
            var existingBebida = _repository.GetById(id);
            if (existingBebida == null)
            {
                return NotFound();
            }
            _repository.Update(bebida);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bebida = _repository.GetById(id);
            if (bebida == null)
            {
                return NotFound();
            }
            _repository.Delete(bebida);
            return NoContent();
        }
    }
}
