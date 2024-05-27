using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarneController : ControllerBase
    {
        private readonly IRepository<Carne> _repository;

        public CarneController(IRepository<Carne> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var carnes = _repository.GetAll();
            return Ok(carnes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var carne = _repository.GetById(id);
            if (carne == null)
            {
                return NotFound();
            }
            return Ok(carne);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Carne carne)
        {
            _repository.Add(carne);
            return CreatedAtAction(nameof(GetById), new { id = carne.Id }, carne);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Carne carne)
        {
            var existingCarne = _repository.GetById(id);
            if (existingCarne == null)
            {
                return NotFound();
            }
            _repository.Update(carne);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var carne = _repository.GetById(id);
            if (carne == null)
            {
                return NotFound();
            }
            _repository.Delete(carne);
            return NoContent();
        }
    }
}
