using Microsoft.AspNetCore.Mvc;
using newcontableapi.Entities;
using newcontableapi.Services;

namespace newcontableapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuariosService;
        public UsuariosController(
            IUsuariosService usuariosService
        )
        {
            _usuariosService = usuariosService;
        }

        /// <summary>Usuarios list</summary>
        /// <remarks>It is possible return usuarios list.</remarks>
        /// <param name="IdUsuario" example="1">Parameters to get usuarios.</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 10)]
        public async Task<ActionResult<Usuarios>> GetUsuarios(int IdUsuario)
        {
            try
            {
                var response = await _usuariosService.SelectUsuariosService(IdUsuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Usuarios list</summary>
        /// <remarks>It is possible return usuarios list.</remarks>
        /// <param name="IdUsuario" example="1">Parameters to get usuarios.</param>
        [HttpGet("politicas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 10)]
        public async Task<ActionResult<UsuariosRolPoliticas>> GetUsuariosDetalles(int IdUsuario)
        {
            try
            {
                var response = await _usuariosService.SelectDetallesUsuariosService(IdUsuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Usuarios login</summary>
        /// <remarks>It is possible return usuario login.</remarks>
        /// <param name="loginUsuarios">Parameters to login usuario.</param>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UsuariosAcceso>> LoginUsuarios(LoginUsuarios loginUsuarios)
        {
            try
            {
                var response = await _usuariosService.LoginUsuariosService(loginUsuarios);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Usuarios creation</summary>
        /// <remarks>It is possible return usuario creation.</remarks>
        /// <param name="usuariosDto">Parameters to post usuario.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> PostUsuarios(UsuariosDto usuariosDto)
        {
            try
            {
                var response = await _usuariosService.InsertUsuariosService(usuariosDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Usuarios update</summary>
        /// <remarks>It is possible return usuario update.</remarks>
        /// <param name="IdUsuario" example="1">Parameters to put usuario.</param>
        /// <param name="usuarios">Parameters to put usuario.</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Usuarios>> PutMonedas(int IdUsuario, Usuarios usuarios)
        {
            try
            {
                var response = await _usuariosService.UpdateUsuariosService(IdUsuario, usuarios);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}