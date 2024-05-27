using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeralController : ControllerBase
    {
        private readonly IRepository<Geral> _repository;

        public GeralController(IRepository<Geral> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var geral = _repository.GetAll();
            return Ok(geral);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var geral = _repository.GetById(id);
            if (geral == null)
            {
                return NotFound();
            }
            return Ok(geral);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Geral geral)
        {
            _repository.Add(geral);
            return CreatedAtAction(nameof(GetById), new { id = geral.Id }, geral);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Geral geral)
        {
            var existingGeral = _repository.GetById(id);
            if (existingGeral == null)
            {
                return NotFound();
            }
            _repository.Update(geral);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var geral = _repository.GetById(id);
            if (geral == null)
            {
                return NotFound();
            }
            _repository.Delete(geral);
            return NoContent();
        }
    }
}
