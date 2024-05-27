using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HigieneController : ControllerBase
    {
        private readonly IRepository<Higiene> _repository;

        public HigieneController(IRepository<Higiene> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var higiene = _repository.GetAll();
            return Ok(higiene);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var higiene = _repository.GetById(id);
            if (higiene == null)
            {
                return NotFound();
            }
            return Ok(higiene);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Higiene higiene)
        {
            _repository.Add(higiene);
            return CreatedAtAction(nameof(GetById), new { id = higiene.Id }, higiene);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Higiene higiene)
        {
            var existingHigiene = _repository.GetById(id);
            if (existingHigiene == null)
            {
                return NotFound();
            }
            _repository.Update(higiene);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var higiene = _repository.GetById(id);
            if (higiene == null)
            {
                return NotFound();
            }
            _repository.Delete(higiene);
            return NoContent();
        }
    }
}
