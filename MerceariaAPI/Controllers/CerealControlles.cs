using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CerealController : ControllerBase
    {
        private readonly IRepository<Cereal> _repository;

        public CerealController(IRepository<Cereal> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var cereais = _repository.GetAll();
            return Ok(cereais);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cereal = _repository.GetById(id);
            if (cereal == null)
            {
                return NotFound();
            }
            return Ok(cereal);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cereal cereal)
        {
            _repository.Add(cereal);
            return CreatedAtAction(nameof(GetById), new { id = cereal.Id }, cereal);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Cereal cereal)
        {
            var existingCereal = _repository.GetById(id);
            if (existingCereal == null)
            {
                return NotFound();
            }
            _repository.Update(cereal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cereal = _repository.GetById(id);
            if (cereal == null)
            {
                return NotFound();
            }
            _repository.Delete(cereal);
            return NoContent();
        }
    }
}
