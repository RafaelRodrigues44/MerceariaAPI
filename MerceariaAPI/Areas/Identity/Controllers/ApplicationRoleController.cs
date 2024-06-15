using MerceariaAPI.Areas.Identity.Models;
using MerceariaAPI.Areas.Identity.Repositories.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MerceariaAPI.Areas.Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ApplicationRoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public ApplicationRoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplicationRole>> GetRoles()
        {
            return await _roleRepository.GetRoles();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationRole>> GetRoleById(string id)
        {
            var role = await _roleRepository.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            return role;
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationRole>> CreateRole([FromBody] ApplicationRole role)
        {
            await _roleRepository.CreateRole(role);
            return CreatedAtAction(nameof(GetRoleById), new { id = role.Id }, role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] ApplicationRole role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            await _roleRepository.UpdateRole(role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleRepository.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }

            await _roleRepository.DeleteRole(role);
            return NoContent();
        }
    }
}
