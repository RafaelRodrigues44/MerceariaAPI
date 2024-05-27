using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BiscoitoController : ControllerBase
    {
        private readonly IRepository<Biscoito> _repository;

        public BiscoitoController(IRepository<Biscoito> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var biscoitos = _repository.GetAll();
            return Ok(biscoitos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var biscoito = _repository.GetById(id);
            if (biscoito == null)
            {
                return NotFound();
            }
            return Ok(biscoito);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Biscoito biscoito)
        {
            _repository.Add(biscoito);
            return CreatedAtAction(nameof(GetById), new { id = biscoito.Id }, biscoito);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Biscoito biscoito)
        {
            var existingBiscoito = _repository.GetById(id);
            if (existingBiscoito == null)
            {
                return NotFound();
            }
            _repository.Update(biscoito);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var biscoito = _repository.GetById(id);
            if (biscoito == null)
            {
                return NotFound();
            }
            _repository.Delete(biscoito);
            return NoContent();
        }
    }
}
