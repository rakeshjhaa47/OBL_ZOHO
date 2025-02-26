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
        public async Task<IActionResult> CpSummary(string accessToken, string Assigned_CP_By_Agent, string Created_Time)
        {
            return Ok(await _ConnectService.CpSummaryAsync(accessToken, Assigned_CP_By_Agent, Created_Time));
        }

        [HttpPost]
        [Route("cp-dashboard")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CpDashboard(string accessToken, string Closing_Date, string Created_Time, string Assigned_CP_By_Agent)
        {
            return Ok(await _ConnectService.CpDashboardAsync(accessToken, Closing_Date, Created_Time, Assigned_CP_By_Agent));
        }

        [Route("generate-firebase-token-for-connect")]
        [HttpPost]
        public async Task<IActionResult> CreateFireBaseTokenforConnect()
        {
            var response = await _ConnectService.CreateFireBaseTokenForConnect();
            return Ok(response);
        }

        [Route("ConnectAll-Stage")]
        [HttpPost]
        public async Task<IActionResult> ConnectAllStage(string accessToken, string Assigned_CP, string Created_Time, string Stage_Category, string MaxRequirement, string MinRequirement, int limit, int offSet)
        {
            var response = await _ConnectService.ConnectAllStageAsync(accessToken, Assigned_CP, Created_Time, Stage_Category, MaxRequirement, MinRequirement, limit, offSet);
            return Ok(response);
        }

        [Route("Connect-Dashboard")]
        [HttpPost]
        public async Task<IActionResult> ConnectDashboard(string accessToken, string Assigned_CP, string Start_Date, string End_Date)
        {
            var response = await _ConnectService.ConnectDashboardAsync(accessToken, Assigned_CP, Start_Date, End_Date);
            return Ok(response);
        }

        [Route("Summary-Count")]
        [HttpPost]
        public async Task<IActionResult> SummaryCount(string accessToken, string Assigned_CP)
        {
            var response = await _ConnectService.SummaryCountAsync(accessToken, Assigned_CP);
            return Ok(response);
        }


        [Route("Search-Api")]
        [HttpPost]
        public async Task<IActionResult> SearchApi(string accessToken, string Deal_Name,string City,string Assigned_CP, string Stage_Category)
        {
            var response = await _ConnectService.SearchApiAsync(accessToken, Deal_Name,City, Assigned_CP,Stage_Category);
            return Ok(response);
        }

    }
}
