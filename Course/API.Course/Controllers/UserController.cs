using API.Course.Business.Entities;
using API.Course.Business.Repositories;
using API.Course.Configurations;
using API.Course.Filters;
using API.Course.Models;
using API.Course.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Course.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public UserController(
            IUserRepository userRepository,
            IAuthenticationService authenticationService
            )
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }


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
            User user = _userRepository.GetUser(loginViewModelInput.Login);

            if(user == null)
            {
                return BadRequest("Error when trying access.");
            }

            //if (user.Password != loginViewModelInput.Password.GenerateCryptographicPassword())
            //{
            //    return BadRequest("Error when trying access.");
            //}

            var userViewModelOutput = new UserViewModelOutput()
            {
                Code = user.Code,
                Login = loginViewModelInput.Login,
                email = user.Email
            };

            var token = _authenticationService.GenerateToken(userViewModelOutput);

            return Ok(new
            {
                Token = token,
                User = userViewModelOutput
            });
        }

        /// <summary>
        /// This service allow to register a new user that not exists.
        /// </summary>
        /// <param name="registerViewModelInput">register View Model</param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Authentication success", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Required fields", Type = typeof(FieldValidateViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Internal error", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("register")]
        [ValidateModelStateCustom]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {

            //var pendingMigrations = context.Database.GetPendingMigrations();

            //if(pendingMigrations.Count() > 0)
            //{
            //    context.Database.Migrate();
            //}

            var user = new User();
            user.Login = registerViewModelInput.Login;
            user.Email = registerViewModelInput.Email;
            user.Password = registerViewModelInput.Password;


            _userRepository.Add(user);
            _userRepository.Commit();

            return Created("", registerViewModelInput);
        }
    }
}
