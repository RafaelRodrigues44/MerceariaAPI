using MerceariaAPI.Areas.Identity.Models;
using MerceariaAPI.Areas.Identity.Repositories.User;
using MerceariaAPI.Areas.Identity.Repositories.Type;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerceariaAPI.Areas.Identity.Controllers
{
    [Route("User")]
    public class ApplicationUserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITypeUserRepository _typeUserRepository;

        public ApplicationUserController(IUserRepository userRepository, ITypeUserRepository typeUserRepository)
        {
            _userRepository = userRepository;
            _typeUserRepository = typeUserRepository;
        }

        [HttpGet("Create")]
        public IActionResult CreateUser()
        {
            return View("/Views/User/Create.cshtml");
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    TypeUserId = model.TypeUserId,
                };

                var userType = await _typeUserRepository.GetById(model.TypeUserId);
                if (userType != null)
                {
                    var result = await _userRepository.CreateUser(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View("/Views/User/Create.cshtml", model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tipo de usuário inválido.");
                    return View("/Views/User/Create.cshtml", model);
                }
            }

            return View("/Views/User/Create.cshtml", model);
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var users = await _userRepository.GetUsers();
            return View("~/Views/User/List.cshtml", users);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/User/Edit.cshtml", user);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(string id, ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }

                user.UserName = model.UserName;
                user.Email = model.Email;
                user.TypeUserId = model.TypeUserId;

                await _userRepository.UpdateUser(user);
                return RedirectToAction("List");
            }

            return View("~/Views/User/Edit.cshtml", model);
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/User/Delete.cshtml", user);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteUser(user);
            return RedirectToAction("List");
        }
    }
}
