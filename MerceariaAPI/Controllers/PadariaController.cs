using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PadariaController : ControllerBase
    {
        private readonly IRepository<Padaria> _repository;

        public PadariaController(IRepository<Padaria> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var padarias = _repository.GetAll();
            return Ok(padarias);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var padaria = _repository.GetById(id);
            if (padaria == null)
            {
                return NotFound();
            }
            return Ok(padaria);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Padaria padaria)
        {
            _repository.Add(padaria);
            return CreatedAtAction(nameof(GetById), new { id = padaria.Id }, padaria);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Padaria padaria)
        {
            var existingPadaria = _repository.GetById(id);
            if (existingPadaria == null)
            {
                return NotFound();
            }
            _repository.Update(padaria);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var padaria = _repository.GetById(id);
            if (padaria == null)
            {
                return NotFound();
            }
            _repository.Delete(padaria);
            return NoContent();
        }
    }
}
