using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using newcontableapi.Entities;
using newcontableapi.Services;

namespace newcontableapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientosContablesController : ControllerBase
    {
        private readonly IAsientosContablesService _asientosContablesService;
        public AsientosContablesController(
            IAsientosContablesService asientosContablesService
        )
        {
            _asientosContablesService = asientosContablesService;
        }

        /// <summary>AsientosContables list</summary>
        /// <remarks>It is possible return AsientosContables list.</remarks>
        /// <param name="FechaDesde" example="01-02-2000">Parameters to get AsientosContables.</param>
        /// <param name="FechaHasta" example="02-02-2000">Parameters to get AsientosContables.</param>
        /// <param name="IdPeriodoContable" example="1">Parameters to get AsientosContables.</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsientosContables(string FechaDesde, string FechaHasta, int IdPeriodoContable)
        {
            try
            {
                var response = await _asientosContablesService.SelectAsientosContablesService(FechaDesde, FechaHasta, IdPeriodoContable);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>AsientosContables creation</summary>
        /// <remarks>It is possible return AsientosContables creation.</remarks>
        /// <param name="asientosContables">Parameters to post AsientosContables.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> PostAsientosContables(AsientosContables asientosContables)
        {
            try
            {
                var response = await _asientosContablesService.InsertAsientosContablesService(asientosContables);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>AsientosContables update</summary>
        /// <remarks>It is possible return AsientosContables update.</remarks>
        /// <param name="IdAsiento" example="1">Parameters to put AsientosContables.</param>
        /// <param name="asientosContables">Parameters to put AsientosContables.</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> PutAsientosContables(int IdAsiento, AsientosContables asientosContables)
        {
            try
            {
                var response = await _asientosContablesService.UpdateAsientosContablesService(IdAsiento, asientosContables);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>AsientosContables update</summary>
        /// <remarks>It is possible return AsientosContables update.</remarks>
        /// <param name="IdAsientoDetalle" example="1">Parameters to put AsientosContables.</param>
        /// <param name="asientosContablesDetalles">Parameters to put AsientosContables.</param>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> PatchAsientosContablesDetalles(int IdAsientoDetalle, AsientosContablesDetalles asientosContablesDetalles)
        {
            try
            {
                var response = await _asientosContablesService.UpdateAsientosContablesDetallesService(IdAsientoDetalle, asientosContablesDetalles);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}