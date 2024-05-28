using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly IRepository<Compra> _repository;

        public CompraController(IRepository<Compra> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var compras = _repository.GetAll();
            return Ok(compras);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var compra = _repository.GetById(id);
            if (compra == null)
            {
                return NotFound();
            }
            return Ok(compra);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Compra compra)
        {
            if (compra == null)
            {
                return BadRequest();
            }
            _repository.Add(compra);
            return CreatedAtAction(nameof(GetById), new { id = compra.CompraId }, compra);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Compra compra)
        {
            if (compra == null || compra.CompraId != id)
            {
                return BadRequest();
            }

            var existingCompra = _repository.GetById(id);
            if (existingCompra == null)
            {
                return NotFound();
            }

            _repository.Update(compra);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var compra = _repository.GetById(id);
            if (compra == null)
            {
                return NotFound();
            }

            _repository.Delete(compra);
            return NoContent();
        }
    }
}
