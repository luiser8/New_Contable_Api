using Microsoft.AspNetCore.Mvc;
using newcontableapi.Entities;
using newcontableapi.Services;

namespace newcontableapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentroCostosController : ControllerBase
    {
        private readonly ICentroCostosService _centroCostosService;
        public CentroCostosController(
            ICentroCostosService centroCostosService
        )
        {
            _centroCostosService = centroCostosService;
        }

        /// <summary>CentroCostos list</summary>
        /// <remarks>It is possible return CentroCostos list.</remarks>
        /// <param name="IdCentroCostos" example="1">Parameters to get CentroCostos.</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 10)]
        public async Task<ActionResult<CentroCostos>> GetCentroCostos(int IdCentroCostos)
        {
            try
            {
                var response = await _centroCostosService.SelectCentroCostosService(IdCentroCostos);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>CentroCostos creation</summary>
        /// <remarks>It is possible return CentroCostos creation.</remarks>
        /// <param name="centroCostos">Parameters to post CentroCostos.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CentroCostos>> PostCentroCostos(CentroCostos centroCostos)
        {
            try
            {
                var response = await _centroCostosService.InsertCentroCostosService(centroCostos);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>CentroCostos update</summary>
        /// <remarks>It is possible return CentroCostos update.</remarks>
        /// <param name="IdCentroCostos" example="1">Parameters to put CentroCostos.</param>
        /// <param name="centroCostos">Parameters to put CentroCostos.</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CentroCostos>> PutCentroCostos(int IdCentroCostos, CentroCostos centroCostos)
        {
            try
            {
                var response = await _centroCostosService.UpdateCentroCostosService(IdCentroCostos, centroCostos);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}