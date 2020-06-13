using Application.Interfaces;
using Application.ViewModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly AppSecret _appSecret;
        private readonly IUserAppService _userAppService;
        public AuthController(IOptions<AppSecret> appSecret,
            IUserAppService userAppService)
        {
            _appSecret = appSecret.Value ??
                throw new ArgumentNullException(nameof(_appSecret));

            _userAppService = userAppService ?? 
                throw new ArgumentNullException(nameof(userAppService));
        }

        [HttpPost]
        [Route("/Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            if (ModelState.IsValid)
            {
                if (await _userAppService.IsValidLogin(userLoginRequest))
                {
                    var token = GenerateJwt(userLoginRequest.Email);
                    return Ok(token);
                }
            }

            return BadRequest("Invalid Login");
        }

        [HttpPost]
        [Route("/SingUp")]
        public async Task<IActionResult> Singup([FromBody] UserSingUpRequest userSingUpRequest)
        {
            if (ModelState.IsValid)
            {
                var userSingUpResponse = await _userAppService.CreateLogin(userSingUpRequest);
                if (userSingUpResponse == null)
                {
                    return BadRequest("E-mail already exist");
                }

                var token = GenerateJwt(userSingUpResponse.Email);
                return Ok(token);
            }

            return BadRequest();
        }

        private object GenerateJwt(string email)
        {
            var authClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, email)
            };

            var key = Encoding.ASCII.GetBytes(_appSecret.Key);

            var token = new JwtSecurityToken(
                issuer: _appSecret.Issuer,
                audience: _appSecret.Audience,
                expires: DateTime.Now.AddMinutes(_appSecret.Expiration),
                claims: authClaims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                );

            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expire = token.ValidTo
            };
        }

    }
}