using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriosController : ControllerBase
    {
        private readonly IRepository<Frios> _repository;

        public FriosController(IRepository<Frios> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var frios = _repository.GetAll();
            return Ok(frios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var frios = _repository.GetById(id);
            if (frios == null)
            {
                return NotFound();
            }
            return Ok(frios);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Frios frios)
        {
            _repository.Add(frios);
            return CreatedAtAction(nameof(GetById), new { id = frios.Id }, frios);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Frios frios)
        {
            var existingFrios = _repository.GetById(id);
            if (existingFrios == null)
            {
                return NotFound();
            }
            _repository.Update(frios);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var frios = _repository.GetById(id);
            if (frios == null)
            {
                return NotFound();
            }
            _repository.Delete(frios);
            return NoContent();
        }
    }
}
