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
        private readonly IConfiguration _configuration;
        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [SwaggerOperation(Summary = "Guid doğrulama ", Description = "<h2> Guid Doğrulama </h2>  Bilgisayar yazılımlarında bir tanımlayıcı olarak kullanılan eşsiz bir referans numarasıdır.")]
        [AllowAnonymous]
        [HttpGet]
        [Route("Verify/{guid}")]
        public MailVerifyResponse Verify(string guid)
        {
            MailVerifyRequest request = new MailVerifyRequest();
            request.Guid = guid;
            return _userService.Verify(request);
        }

        [SwaggerOperation(Summary = "token kontrol ", Description = "<h2> check </h2>token kontrol alanı.")]
        [Authorize]
        [HttpGet]
        [Route("check")]
        public IActionResult Check()
        {
            return Ok();
        }
        [SwaggerOperation(Summary = "Kullanıcı verilerini getirir. ", Description = "<h2> Kullanıcı veriler </h2>Kullanıcı verilerini listeler.")]
        [Authorize]
        [HttpGet]
        [Route("getinfo")]
        public UserGetInfoResponse GetInfo()
        {
            var request = new UserGetInfoRequest();
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var id = Convert.ToInt64(identity.Claims.ElementAt(0).Value);
                request.UserId = id;
            }
            return _userService.GetInfo(request);
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


        [SwaggerOperation(Summary = "Kullanıcı giriş ", Description = "<h2> Kullanıcı </h2> Kullanıcı giriş alanı.")]
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public UserLoginResponse Login(UserLoginRequest userLoginRequest)
        {
            UserLoginResponse userLoginResponse = _userService.Login(userLoginRequest);
            if (userLoginResponse.Code.Equals("200"))
            {
                userLoginResponse.Token = GetToken(userLoginRequest.isRemember, userLoginResponse.UserId, userLoginResponse.RoleId);
                // userLoginResponse.UserId = 0;
            }
            return userLoginResponse;
        }

        [SwaggerOperation(Summary = "Token Yenileme ", Description = "<h2> Token </h2> Token yenileme alanı.")]
        [AllowAnonymous]
        [HttpPost]
        [Route("RefreshToken")]
        public RefreshTokenResponse RefreshToken(UserLoginRequest request)
        {
            RefreshTokenResponse response = new RefreshTokenResponse();

            UserLoginResponse userLoginResponse = _userService.Login(request);
            if (userLoginResponse.Code.Equals("200"))
            {
                response.Token = GetToken(true, userLoginResponse.UserId);
                userLoginResponse.UserId = 0;
            }

            if (userLoginResponse.Code.Equals("400"))
            {
                response.Code = "400";
                response.Errors.Add("Token yenilenemedi");
                return response;
            }

            response.Code = "200";
            response.Message = "Token yenilenmiştir";
            return response;
        }

        private string GetToken(bool isRemember, long id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                (new[]
                {
                    new Claim("value", id.ToString())

                }),
                expires: isRemember ? DateTime.Now.AddMonths(3) : DateTime.Now.AddHours(24),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string GetToken(bool isRemember, long id, long userid)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                (new[]
                {
                    new Claim("value", id.ToString()),new Claim("roleid", userid.ToString())
                }),
                expires: isRemember ? DateTime.Now.AddMonths(3) : DateTime.Now.AddHours(24),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [SwaggerOperation(Summary = "Parola Değiştirme ", Description = "<h2> Parola </h2> Parola değiştirme alanı.")]
        [HttpPost]
        [Route("ChangePassword")]
        public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
        {

            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var id = Convert.ToInt64(identity.Claims.ElementAt(0).Value);
                var roleid = Convert.ToInt64(identity.Claims.ElementAt(1).Value);
                request.UserId = id;
                request.RoleId = roleid;
            }


            return _userService.ChangePassword(request);
        }

        [SwaggerOperation(Summary = "Şifremi Unuttum ", Description = "<h2> Şifre </h2> Şifremi unutum.")]
        [AllowAnonymous]
        [HttpPost]
        [Route("PasswordForgot")]
        public PasswordForgotResponse PasswordForgot(PasswordForgotRequest request)
        {

            return _userService.PasswordForgot(request);
        }


        [SwaggerOperation(Summary = "Şifremi Sıfırlama ", Description = "<h2> Şifre Sıfırlama </h2> Şifremi sıfırlama alanı.")]
        [AllowAnonymous]
        [HttpPost]
        [Route("PasswordReset")]
        public PasswordResetResponse PasswordReset(PasswordResetRequest request)
        {
            return _userService.PasswordReset(request);
        }

        [SwaggerOperation(Summary = "Profil Bilgisi Güncelleme ", Description = "<h2> Güncelleme </h2> profil bilgisi güncelleme alanı.")]
        [Authorize]
        [HttpPost]
        [Route("PutInfo")]
        public UserPutInfoResponse PutInfo(UserPutInfoRequest request)
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var id = Convert.ToInt64(identity.Claims.ElementAt(0).Value);
                var roleid = Convert.ToInt64(identity.Claims.ElementAt(1).Value);
                request.UserId = id;
                request.RoleId = roleid;
            }

            return _userService.PutInfo(request);
        }
    }
}

