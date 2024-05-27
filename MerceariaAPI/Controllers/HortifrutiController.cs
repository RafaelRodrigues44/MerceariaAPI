using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HortifrutiController : ControllerBase
    {
        private readonly IRepository<Hortifruti> _repository;

        public HortifrutiController(IRepository<Hortifruti> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var hortifruti = _repository.GetAll();
            return Ok(hortifruti);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var hortifruti = _repository.GetById(id);
            if (hortifruti == null)
            {
                return NotFound();
            }
            return Ok(hortifruti);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Hortifruti hortifruti)
        {
            _repository.Add(hortifruti);
            return CreatedAtAction(nameof(GetById), new { id = hortifruti.Id }, hortifruti);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Hortifruti hortifruti)
        {
            var existingHortifruti = _repository.GetById(id);
            if (existingHortifruti == null)
            {
                return NotFound();
            }
            _repository.Update(hortifruti);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hortifruti = _repository.GetById(id);
            if (hortifruti == null)
            {
                return NotFound();
            }
            _repository.Delete(hortifruti);
            return NoContent();
        }
    }
}
