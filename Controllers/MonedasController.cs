using Microsoft.AspNetCore.Mvc;
using newcontableapi.Entities;
using newcontableapi.Services;

namespace newcontableapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedasController : ControllerBase
    {
        private readonly IMonedasService _monedasService;
        public MonedasController(
            IMonedasService monedasService
        )
        {
            _monedasService = monedasService;
        }

        /// <summary>Monedas list</summary>
        /// <remarks>It is possible return monedas list.</remarks>
        /// <param name="IdMoneda" example="1">Parameters to get monedas.</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 10)]
        public async Task<ActionResult<Monedas>> GetMonedas(int IdMoneda)
        {
            try
            {
                var response = await _monedasService.SelectMonedasService(IdMoneda);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Monedas creation</summary>
        /// <remarks>It is possible return moneda creation.</remarks>
        /// <param name="monedas">Parameters to post moneda.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Monedas>> PostMonedas(Monedas monedas)
        {
            try
            {
                var response = await _monedasService.InsertMonedasService(monedas);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Monedas update</summary>
        /// <remarks>It is possible return moneda update.</remarks>
        /// <param name="IdMoneda" example="1">Parameters to put moneda.</param>
        /// <param name="monedas">Parameters to put moneda.</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Monedas>> PutMonedas(int IdMoneda, Monedas monedas)
        {
            try
            {
                var response = await _monedasService.UpdateMonedasService(IdMoneda, monedas);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}