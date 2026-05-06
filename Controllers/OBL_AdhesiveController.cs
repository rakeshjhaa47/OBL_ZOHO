using Microsoft.AspNetCore.Mvc;
using OBL_Zoho.Models.Request;
using OBL_Zoho.Services;
using OBL_Zoho.Services.Interfaces;
using System.Net.Mime;

namespace OBL_Zoho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OBL_AdhesiveController : ControllerBase
    {
        private readonly IOblAdhesiveService _service;

        public OBL_AdhesiveController(IOblAdhesiveService service)
        {
            _service = service;
        }


        [HttpPost]
        [Route("generate-access-token")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GenerateRefreshToken()
        {
            return Ok(await _service.GenerateRefreshToken());
        }


        [HttpPost("hierarchy")]
        public async Task<IActionResult> Hierarchy(string accessToken, string empCode)
        {
            return Ok(await _service.GetHierarchyAsync(accessToken, empCode));
        }

        [HttpPost("dashboard")]
        public async Task<IActionResult> Dashboard(string accessToken, string adhesiveBhCode, string adhesiveNhCode, string adhesiveSalesPersonEmpId, string closingDate, string createdTime)
        {
            return Ok(await _service.GetDashboardAsync(accessToken, adhesiveBhCode,adhesiveNhCode,adhesiveSalesPersonEmpId,closingDate,createdTime));
        }

        [HttpPost("Getleads")]
        public async Task<IActionResult> Leads(string accessToken, string adhesiveBhCode, string adhesiveNhCode, string adhesiveSalesPersonEmpId, int minQty, int maxQty, string createdTime, string stageCategory, int limit, int offSet)
        {
            return Ok(await _service.GetLeadsAsync(accessToken, adhesiveBhCode,adhesiveNhCode,adhesiveSalesPersonEmpId,minQty,maxQty,createdTime,stageCategory, limit,offSet));
        }

        [HttpPut("update-deal-timeline")]
        public async Task<IActionResult> UpdateDealTimeline( string accessToken, [FromBody] AdhesiveDealTimelineRequest request)
        {
            return Ok(await _service.UpdateDealTimelineAsync(accessToken, request));
        }

        [HttpGet("GetDealById")]
        public async Task<IActionResult> GetDealById(string accessToken, string dealId)
        {
            return Ok(await _service.GetDealByIdAsync(accessToken, dealId));
        }

        [HttpPost("AdhesiveStageChange")]
        public async Task<IActionResult> AdhesiveStageChange(string accessToken, [FromBody] AdhesiveStageChange stageChangeRequest)
        {
            return Ok(await _service.AdhesiveStageChangeAsync(accessToken, stageChangeRequest));
        }

        [Route("GetLeadDetailsById")]
        [HttpPost]
        public async Task<IActionResult> GetLeadDetailsById(string accessToken, string id)
        {
            var response = await _service.GetLeadDetailsByIdAsync(accessToken, id);
            return Ok(response);
        }
    }
}
