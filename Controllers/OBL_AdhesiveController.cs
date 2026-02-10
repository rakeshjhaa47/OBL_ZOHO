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
        public async Task<IActionResult> Hierarchy(
            string accessToken,
            [FromBody] AdhesiveHierarchyRequest request)
        {
            return Ok(await _service.GetHierarchyAsync(accessToken, request));
        }

        [HttpPost("dashboard")]
        public async Task<IActionResult> Dashboard(
            string accessToken,
            [FromBody] AdhesiveDashboardRequest request)
        {
            return Ok(await _service.GetDashboardAsync(accessToken, request));
        }

        [HttpPost("Getleads")]
        public async Task<IActionResult> Leads(
            string accessToken,
            [FromBody] AdhesiveLeadsRequest request)
        {
            return Ok(await _service.GetLeadsAsync(accessToken, request));
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
