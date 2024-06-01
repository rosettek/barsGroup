using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger<TaskController> _logger;

        public UserController(IUserService usersService, ILogger<TaskController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [HttpPost]
        [Route("regist")]
        public async Task<ActionResult> Regist([FromBody] RegisterUserRequest registerUser)
        {
            try
            {
                _logger.LogInformation("StartRegist");
                await _usersService.Register(registerUser.name, registerUser.email, registerUser.paswword);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<string> Login([FromBody] LoginUserRequest loginUser)
        {
            var token = await _usersService.Login(loginUser.email, loginUser.paswword);

            ControllerContext.HttpContext.Response.Cookies.Append("test", token);

            return await _usersService.Login(loginUser.email, loginUser.paswword);
        }


        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<List<RegisterUserRequest>>> Get()
        {
            var users = await _usersService.GetAllUser();
            var response = users
                .Select(b => new RegisterUserRequest(b.Name, b.Email, b.PasswordHash));
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("a")]
        public async Task<ActionResult<string>> Asd()
        {
            return Ok("хорошо");
        }
    }
}
