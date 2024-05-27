using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LimpezaController : ControllerBase
    {
        private readonly IRepository<Limpeza> _repository;

        public LimpezaController(IRepository<Limpeza> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var limpezas = _repository.GetAll();
            return Ok(limpezas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var limpeza = _repository.GetById(id);
            if (limpeza == null)
            {
                return NotFound();
            }
            return Ok(limpeza);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Limpeza limpeza)
        {
            _repository.Add(limpeza);
            return CreatedAtAction(nameof(GetById), new { id = limpeza.Id }, limpeza);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Limpeza limpeza)
        {
            var existingLimpeza = _repository.GetById(id);
            if (existingLimpeza == null)
            {
                return NotFound();
            }
            _repository.Update(limpeza);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var limpeza = _repository.GetById(id);
            if (limpeza == null)
            {
                return NotFound();
            }
            _repository.Delete(limpeza);
            return NoContent();
        }
    }
}
