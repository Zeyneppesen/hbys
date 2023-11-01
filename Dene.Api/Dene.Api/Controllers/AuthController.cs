using Dene.Business.Abstract;
using Dene.Entity.Concrete.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dene.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;

        }
        [SwaggerOperation(Summary = "Kullanıcı kayıt ", Description = "<h2> Kullanıcı </h2> Kullanıcı kayıt alanı.")]
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public UserRegisterResponse Register(UserRegisterRequest userRegisterRequest)
        {
            userRegisterRequest.Ip = HttpContext.Connection.RemoteIpAddress?.ToString();


            return _userService.Register(userRegisterRequest);
        }

        [HttpGet]
        [Route("GetUser")]
        //public IActionResult Get()
        //{

        //}

        public GetUserResponse GetUser()
        {
            GetUserRequest request = new GetUserRequest();
            return _userService.GetUser(request);

        }

    }

}