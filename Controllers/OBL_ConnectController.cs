using Microsoft.AspNetCore.Mvc;
using OBL_Zoho.Services;
using OBL_Zoho.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace OBL_Zoho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OBL_ConnectController : ControllerBase
    {
        private readonly IConnectService _ConnectService;

        public OBL_ConnectController(IConnectService connectService)
        {
            _ConnectService = connectService;
        }

        [HttpPost]
        [Route("generate-access-token-for-connect")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GenerateRefreshTokenForConnect()
        {
            return Ok(await _ConnectService.GenerateRefreshTokenForOblConnect());
        }

        [HttpPost]
        [Route("cp-summary")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CpSummary(string accessToken, string Assigned_CP_By_Agent,string Created_Time)
        {
            return Ok(await _ConnectService.CpSummaryAsync(accessToken,Assigned_CP_By_Agent, Created_Time));
        }

        [HttpPost]
        [Route("cp-dashboard")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CpDashboard(string accessToken, string Closing_Date,string Created_Time,string Assigned_CP_By_Agent )
        {
            return Ok(await _ConnectService.CpDashboardAsync(accessToken,Closing_Date, Created_Time,Assigned_CP_By_Agent));
        }


        [SwaggerOperation(Tags = new[] { "Access token" })]
        [HttpPost]
        [Route("CreateFireBaseTokenforConnect")]
        public async Task<IActionResult> CreateFireBaseTokenforConnect()
        {

            try
            {
                var response = await _ConnectService.FireBaseToken();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error creating Firebase token", Details = ex.Message });
            }
        }
    }
}
