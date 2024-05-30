using Microsoft.AspNetCore.Mvc;
using TaskManager.Contracts.Task;
using TaskManager.Contracts.User;
using UserAuthentication.Domain.Abstractions;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _usersService;

        public UserController(IUserService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        [Route("regist")]
        public async Task Regist([FromBody] LoginUser loginUser)
        {
            await _usersService.Register(loginUser.name, loginUser.email, loginUser.paswword);
        }

        [HttpPost]
        [Route("login")]
        public async Task<string> Login([FromBody] LoginUserResponse loginUser)
        {
            return await _usersService.Login(loginUser.email, loginUser.paswword);
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<List<LoginUser>>> Get()
        {
            var users = await _usersService.GetAllUser();
            var response = users
                .Select(b => new LoginUser(b.Name, b.Email, b.PasswordHash));
            return Ok(response);
        }
    }
}
