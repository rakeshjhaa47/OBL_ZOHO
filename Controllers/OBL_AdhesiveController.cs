using Microsoft.AspNetCore.Mvc;
using OBL_Zoho.Models.Request;
using OBL_Zoho.Services.Interfaces;

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
        public async Task<IActionResult> Leads(string accessToken, string adhesiveBhCode, string adhesiveNhCode, string adhesiveSalesPersonEmpId, int minQty, int maxQty, string createdTime)
        {
            return Ok(await _service.GetLeadsAsync(accessToken, adhesiveBhCode,adhesiveNhCode,adhesiveSalesPersonEmpId,minQty,maxQty,createdTime));
        }

        [HttpPut("update-deal-timeline")]
        public async Task<IActionResult> UpdateDealTimeline(
          string accessToken,
          [FromBody] AdhesiveDealTimelineRequest request)
        {
            return Ok(await _service.UpdateDealTimelineAsync(accessToken, request));
        }


    }
}
