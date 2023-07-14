using Microsoft.AspNetCore.Mvc;
using newcontableapi.Entities;
using newcontableapi.Services;

namespace newcontableapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodosContablesController : ControllerBase
    {
        private readonly IPeriodosContablesService _periodosContablesService;
        public PeriodosContablesController(
            IPeriodosContablesService periodosContablesService
        )
        {
            _periodosContablesService = periodosContablesService;
        }

        /// <summary>Periodos contables list</summary>
        /// <remarks>It is possible return Periodos contables list.</remarks>
        /// <param name="IdPeriodoContable" example="1">Parameters to get Periodos contables.</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 10)]
        public async Task<ActionResult<PeriodoContable>> GetPeriodosContables(int IdPeriodoContable)
        {
            try
            {
                var response = await _periodosContablesService.SelectPeriodoContableService(IdPeriodoContable);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Periodos contables creation</summary>
        /// <remarks>It is possible return Periodos contables creation.</remarks>
        /// <param name="periodoContable">Parameters to post Periodos contables.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Monedas>> PostPeriodosContables(PeriodoContable periodoContable)
        {
            try
            {
                var response = await _periodosContablesService.InsertPeriodoContableService(periodoContable);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Periodos contables update</summary>
        /// <remarks>It is possible return Periodos contables update.</remarks>
        /// <param name="IdPeriodoContable" example="1">Parameters to put Periodos contables.</param>
        /// <param name="periodoContable">Parameters to put Periodos contables.</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Monedas>> PutPeriodosContables(int IdPeriodoContable, PeriodoContable periodoContable)
        {
            try
            {
                var response = await _periodosContablesService.UpdatePeriodoContableService(IdPeriodoContable, periodoContable);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}