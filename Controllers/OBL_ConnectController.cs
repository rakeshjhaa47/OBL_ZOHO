using Microsoft.AspNetCore.Mvc;
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
        [Route("generate-refresh-token-for-connect")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GenerateRefreshTokenForConnect()
        {
            return Ok(await _ConnectService.GenerateRefreshTokenForOblConnect());
        }

        [HttpPost]
        [Route("obl-connect-sort")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> OBlConnect(string Assigned_CP_By_Agent,string Created_Time)
        {
            return Ok(await _ConnectService.OBLSortConnect(Assigned_CP_By_Agent,Created_Time));
        }

        [HttpPost]
        [Route("summary-count")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Count( string Stage, string Closing_Date,string Created_Time,string Assigned_CP_By_Agent )
        {
            return Ok(await _ConnectService.SummaryCount(Stage,Closing_Date,Created_Time,Assigned_CP_By_Agent));
        }


    }
}
