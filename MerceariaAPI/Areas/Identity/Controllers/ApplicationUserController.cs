using MerceariaAPI.Areas.Identity.Models;
using MerceariaAPI.Areas.Identity.Repositories.User;
using MerceariaAPI.Areas.Identity.Repositories.Type;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerceariaAPI.Areas.Identity.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITypeUserRepository _typeUserRepository;

        public ApplicationUserController(IUserRepository userRepository, ITypeUserRepository typeUserRepository)
        {
            _userRepository = userRepository;
            _typeUserRepository = typeUserRepository;
        }

        //GET: User/Create
        [HttpGet("/User/Create")]
        public IActionResult CreateUser()
        {
            return View("/Views/User/Create.cshtml");
        }

        [HttpPost("/User/Create")]
        public async Task<IActionResult> CreateUser(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    TypeUserId = model.TypeUserId,
                };

                var userType = await _typeUserRepository.GetById(model.TypeUserId);
                if (userType != null)
                {
                    var result = await _userRepository.CreateUser(user, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("List", "User");
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

        // GET: /User/List
        [HttpGet("/User/List")]
        public async Task<IActionResult> List()
        {
            var users = await _userRepository.GetUsers();
            return View("~/Views/User/List.cshtml", users);
        }

        // GET: /User/Edit/{id}
        [HttpGet("/User/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userRepository.GetUserById(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/User/Edit.cshtml", user);
        }

        // GET: /User/Delete/{id}
        [HttpGet("/User/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userRepository.GetUserById(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/User/Delete.cshtml", user);
        }
    }
}
