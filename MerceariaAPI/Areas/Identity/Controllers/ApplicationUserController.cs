using MerceariaAPI.Areas.Identity.Models;
using MerceariaAPI.Areas.Identity.Repositories.User;
using MerceariaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerceariaAPI.Areas.Identity.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<TypeUser> _typeUserRepository;

        public ApplicationUserController(IUserRepository userRepository, IRepository<TypeUser> typeUserRepository)
        {
            _userRepository = userRepository;
            _typeUserRepository = typeUserRepository;
        }

        //GET: User/Create
        [HttpGet("/User/Create")]
        public IActionResult Create()
        {
            return View("/Views/User/Create.cshtml");
        }

        [HttpPost("/User/Create")]
        public async Task<IActionResult> Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Crie um novo ApplicationUser com base nos dados do modelo
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };

                // Busque o TypeUser com base no ID fornecido em model.TypeUserId
                var userType =  _typeUserRepository.GetById(model.TypeUser);
                if (userType != null)
                {
                    // Crie o usuário com o repositório
                    await _userRepository.CreateUser(user, model.Password);

                    // Redirecione para a lista de usuários após a criação bem-sucedida
                    return RedirectToAction("List", "User");
                }
                else
                {
                    // Lida com o caso em que o tipo de usuário não foi encontrado
                    // Você pode retornar uma mensagem de erro ou lidar com isso de outra forma, dependendo da sua lógica de negócios
                    ModelState.AddModelError(string.Empty, "Tipo de usuário inválido.");
                    return View("/Views/User/Create.cshtml", model);
                }
            }

            // Se houver erros de validação, retorne a view de criação com o modelo inválido
            return View("/Views/User/Create.cshtml", model);
        }

        // GET: /ApplicationUser/List
        [HttpGet("/User/List")]
        public async Task<IActionResult> List()
        {
            var users = await _userRepository.GetUsers();
            return View("~/Views/User/List.cshtml", users);
        }

        // GET: /ApplicationUser/Edit/{id}
        [HttpGet("/User/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/User/Edit.cshtml", user);
        }

        // GET: /ApplicationUser/Delete/{id}
        [HttpGet("/User/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/User/Delete.cshtml", user);
        }
    }
}
