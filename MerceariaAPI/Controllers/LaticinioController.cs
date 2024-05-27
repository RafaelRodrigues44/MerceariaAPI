using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaticinioController : ControllerBase
    {
        private readonly IRepository<Laticinio> _repository;

        public LaticinioController(IRepository<Laticinio> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var laticinios = _repository.GetAll();
            return Ok(laticinios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var laticinio = _repository.GetById(id);
            if (laticinio == null)
            {
                return NotFound();
            }
            return Ok(laticinio);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Laticinio laticinio)
        {
            _repository.Add(laticinio);
            return CreatedAtAction(nameof(GetById), new { id = laticinio.Id }, laticinio);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Laticinio laticinio)
        {
            var existingLaticinio = _repository.GetById(id);
            if (existingLaticinio == null)
            {
                return NotFound();
            }
            _repository.Update(laticinio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var laticinio = _repository.GetById(id);
            if (laticinio == null)
            {
                return NotFound();
            }
            _repository.Delete(laticinio);
            return NoContent();
        }
    }
}
