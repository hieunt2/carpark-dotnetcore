using CarPark.API.ViewModels;
using CarPark.Common;
using CarPark.Infrastructure.Ultilities;
using CarPark.Service.Dto;
using CarPark.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarPark.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtManager _jwtManager;

        public UsersController(IUserService userService, IJwtManager jwtManager)
        {
            _userService = userService;
            _jwtManager = jwtManager;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration(UserDto model)
        {
            var user = await _userService.Registration(model);

            if(user == null)
            {
                return Ok(new ResultModel
                {
                    Success = false,
                    Message = Constants.Users.RegisterAccountFail
                });
            }

            return Ok(new ResultModel
            {
                Success = true,
                Message = Constants.Users.RegisterAccountSuccess
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(BaseUserDto model)
        {
            var user = await _userService.GetUserByLogin(model);

            if (user == null)
            {
                return Ok(new LoginResultModel
                {
                    Success = false,
                    Message = Constants.Users.LoginAccountFail
                });
            }

            var tokenString = _jwtManager.GenerateToken();

            return Ok(new LoginResultModel
            {
                Success = true,
                Message = Constants.Users.LoginAccountSuccess,
                Token = tokenString
            });
        }

        [HttpGet]
        [Route("Details")]
        [Authorize]
        public async Task<IActionResult> Details(string email)
        {
            var user = await _userService.GetUserByEmail(email);

            if (user == null)
            {
                return Ok(new ResultModel
                {
                    Success = false,
                    Message = Constants.Users.LoginAccountFail
                });
            }

            return Ok(user);
        }
    }
}
