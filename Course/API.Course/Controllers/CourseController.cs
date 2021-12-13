using API.Course.Models.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Course.Controllers
{
    [Route("api/v1/courses")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        /// <summary>
        /// Este serviço permite cadastrar curso para o usuário autenticado.
        /// </summary>
        /// <returns>Retorna status 201 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao Cadastrar um curso", Type = typeof(CourseViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput)
        {
            try
            {
                //CourseViewModelInput course = new CourseViewModelInput
                //{
                //    Name = courseViewModelInput.Name,
                //    Description = courseViewModelInput.Description
                //};

                //var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
                //course.CodigoUsuario = codigoUsuario;
                //_cursoRepository.Adicionar(course);
                //_cursoRepository.Commit();

                //var cursoViewModelOutput = new CourseViewModelInput
                //{
                //    Nome = curso.Nome,
                //    Descricao = curso.Descricao,
                //};

                var userCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
                return Created("", courseViewModelInput);
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Este serviço permite obter todos os cursos ativos do usuário.
        /// </summary>
        /// <returns>Retorna status ok e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter os cursos", Type = typeof(CourseViewModelOutput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                //var userCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

                //var courses = _cursoRepository.ObterPorUsuario(userCode)
                //    .Select(s => new CursoViewModelOutput()
                //    {
                //        Nome = s.Nome,
                //        Descricao = s.Descricao
                //    });

                var courses = new List<CourseViewModelOutput>();
                courses.Add(new CourseViewModelOutput()
                {
                    Login = "",
                    Name = "teste",
                    Description = "teste"
                });
                
                return Ok(courses);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }
    }
}
