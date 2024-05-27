using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoceController : ControllerBase
    {
        private readonly IRepository<Doce> _repository;

        public DoceController(IRepository<Doce> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var doces = _repository.GetAll();
            return Ok(doces);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var doce = _repository.GetById(id);
            if (doce == null)
            {
                return NotFound();
            }
            return Ok(doce);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Doce doce)
        {
            _repository.Add(doce);
            return CreatedAtAction(nameof(GetById), new { id = doce.Id }, doce);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Doce doce)
        {
            var existingDoce = _repository.GetById(id);
            if (existingDoce == null)
            {
                return NotFound();
            }
            _repository.Update(doce);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var doce = _repository.GetById(id);
            if (doce == null)
            {
                return NotFound();
            }
            _repository.Delete(doce);
            return NoContent();
        }
    }
}
