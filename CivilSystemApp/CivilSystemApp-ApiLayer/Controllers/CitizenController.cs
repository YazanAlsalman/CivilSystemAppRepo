using CivilSystemApp_ApiLayer.Dtos;
using CivilSystemApp_DAL.CitizenManagers;
using CivilSystemApp_DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CivilSystemApp_ApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitizenController : ControllerBase
    {

        private readonly ILogger<CitizenController> _logger;
        private readonly CRUDCitizenManager _citizenManager;

        public CitizenController(ILogger<CitizenController> logger, CRUDCitizenManager citizenManager)
        {
            _logger = logger;
            _citizenManager = citizenManager;
        }

        [HttpGet("GetCitizenData")]
        public async Task<IActionResult> GetCitizenData()
        {
            try
            {
                var retVal = await _citizenManager.GetCitizensData();
                return Ok(retVal);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error in GetCitizenData" + ex.Message.ToString());
                return StatusCode(500, new
                {
                    ex.Message,
                    ex.StackTrace
                });
            }
        }

        [HttpPost("AddEditCitizenData")]
        public async Task<IActionResult> AddEditCitizenData(CitizenDto citizen)
        {
            try
            {
                var retVal = await _citizenManager.AddEditCitizenData(citizen);
                return Ok(retVal);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error in AddEditCitizenData" + ex.Message.ToString());
                return StatusCode(500, new { ex.Message, ex.StackTrace });
            }
        }

        [HttpDelete("DeleteCitizen")]
        public async Task<IActionResult> DeleteCitizen(int CitizenId)
        {
            try
            {
                var retVal = await _citizenManager.DeleteCitizen(CitizenId);
                return Ok(retVal);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error in DeleteCitizen" + ex.Message.ToString());
                return StatusCode(500, new { ex.Message, ex.StackTrace });
            }
        }

    }
}