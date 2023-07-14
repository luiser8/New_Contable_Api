using Microsoft.AspNetCore.Mvc;
using newcontableapi.Entities;
using newcontableapi.Services;

namespace newcontableapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanCuentasController : ControllerBase
    {
        private readonly IPlanCuentasService _planCuentasService;
        public PlanCuentasController(
            IPlanCuentasService planCuentasService
        )
        {
            _planCuentasService = planCuentasService;
        }

        /// <summary>PlanCuentas list</summary>
        /// <remarks>It is possible return PlanCuentas list.</remarks>
        /// <param name="IdPlanCuenta" example="1">Parameters to get PlanCuentas.</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 10)]
        public async Task<ActionResult<PlanCuentas>> GetPlanCuentas(int IdPlanCuenta)
        {
            try
            {
                var response = await _planCuentasService.SelectPlanCuentasService(IdPlanCuenta);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>PlanCuentas creation</summary>
        /// <remarks>It is possible return PlanCuentas creation.</remarks>
        /// <param name="planCuentas">Parameters to post PlanCuentas.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PlanCuentas>> PostPlanCuentas(PlanCuentas planCuentas)
        {
            try
            {
                var response = await _planCuentasService.InsertPlanCuentasService(planCuentas);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>PlanCuentas update</summary>
        /// <remarks>It is possible return PlanCuentas update.</remarks>
        /// <param name="IdPlanCuenta" example="1">Parameters to put PlanCuentas.</param>
        /// <param name="planCuentas">Parameters to put PlanCuentas.</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PlanCuentas>> PutPlanCuentas(int IdPlanCuenta, PlanCuentas planCuentas)
        {
            try
            {
                var response = await _planCuentasService.UpdatePlanCuentasService(IdPlanCuenta, planCuentas);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}