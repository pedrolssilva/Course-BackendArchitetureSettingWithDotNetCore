using API.Course.Filters;
using API.Course.Models;
using API.Course.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Course.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// This service allow to authenticate active user registered.
        /// </summary>
        /// <param name="loginViewModelInput">Login view model</param>
        /// <returns>return status OK, user data and token in case of success</returns>
        [SwaggerResponse(statusCode: 200, description: "Authentication success", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Required fields", Type = typeof(FieldValidateViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Internal error", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("login")]
        [ValidateModelStateCustom]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            var userViewModelOutput = new UserViewModelOutput()
            {
                Code = 1,
                Login = "leandrobianch",
                email = "leandrobianch@gmail.com"
            };

            var secret = Encoding.ASCII.GetBytes("MzfsT&d9gprP>!9$Es(X!5g@;ef!5sbk:jH\\2.}8ZP'qY#7");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userViewModelOutput.Code.ToString()),
                    new Claim(ClaimTypes.Name, userViewModelOutput.Login),
                    new Claim(ClaimTypes.Email, userViewModelOutput.email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);


            return Ok(new
            {
                Token = token,
                User = userViewModelOutput
            });
        }

        [HttpPost]
        [Route("register")]
        [ValidateModelStateCustom]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            return Created("", registerViewModelInput);
        }
    }
}
