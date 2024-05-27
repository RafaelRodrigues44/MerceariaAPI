using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Repositories;

namespace MerceariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PapelariaController : ControllerBase
    {
        private readonly IRepository<Papelaria> _repository;

        public PapelariaController(IRepository<Papelaria> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = _repository.GetAll();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _repository.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Add(Papelaria produto)
        {
            _repository.Add(produto);
            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Papelaria produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }
            _repository.Update(produto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _repository.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }
            _repository.Delete(produto);
            return NoContent();
        }
    }
}
