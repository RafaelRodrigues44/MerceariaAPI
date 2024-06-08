using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Models;
using MerceariaAPI.Areas.Identity.Repositories;
using System.Threading.Tasks;

namespace MerceariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeUserController : ControllerBase
    {
        private readonly ITypeUserRepository _typeUserRepository;

        public TypeUserController(ITypeUserRepository typeUserRepository)
        {
            _typeUserRepository = typeUserRepository;
        }

        // GET: api/TypeUser
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var typesUsers = await _typeUserRepository.GetTypesUsers();
            return Ok(typesUsers);
        }

        // GET: api/TypeUser/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var typeUser = await _typeUserRepository.GetTypeUserById(id);
            if (typeUser == null)
            {
                return NotFound();
            }
            return Ok(typeUser);
        }

        // POST: api/TypeUser
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TypeUser typeUser)
        {
            var createdTypeUser = await _typeUserRepository.CreateTypeUser(typeUser);
            return CreatedAtAction(nameof(Get), new { id = createdTypeUser.Id }, createdTypeUser);
        }

        // PUT: api/TypeUser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TypeUser typeUser)
        {
            var existingTypeUser = await _typeUserRepository.GetTypeUserById(id);
            if (existingTypeUser == null)
            {
                return NotFound();
            }
            typeUser.Id = id; // Ensure the correct ID is set
            await _typeUserRepository.UpdateTypeUser(typeUser);
            return NoContent();
        }

        // DELETE: api/TypeUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var typeUser = await _typeUserRepository.GetTypeUserById(id);
            if (typeUser == null)
            {
                return NotFound();
            }
            await _typeUserRepository.DeleteTypeUser(typeUser);
            return NoContent();
        }
    }
}
