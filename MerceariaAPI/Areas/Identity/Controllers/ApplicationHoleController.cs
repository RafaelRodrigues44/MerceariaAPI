using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MerceariaAPI.Areas.Identity.Models;
using MerceariaAPI.Areas.Identity.Repositories;
using System;
using System.Threading.Tasks;

namespace MerceariaAPI.Areas.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationRoleController : ControllerBase
    {
        private readonly RoleRepository _roleRepository;

        public ApplicationRoleController(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: api/ApplicationRole
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleRepository.GetRoles();
            return Ok(roles);
        }

        // GET: api/ApplicationRole/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(string id)
        {
            var role = await _roleRepository.GetRoleById(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // POST: api/ApplicationRole
        [HttpPost]
        public async Task<IActionResult> PostRole(ApplicationRole role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _roleRepository.CreateRole(role);
                return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // PUT: api/ApplicationRole/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(string id, ApplicationRole role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _roleRepository.UpdateRole(role);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // DELETE: api/ApplicationRole/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleRepository.GetRoleById(id);

            if (role == null)
            {
                return NotFound();
            }

            try
            {
                await _roleRepository.DeleteRole(role);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
