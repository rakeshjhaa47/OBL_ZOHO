using Microsoft.AspNetCore.Mvc;
using OBL_Zoho.Services.Interfaces;

namespace OBL_Zoho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OBL_Controller : ControllerBase
    {
        private readonly IOblservice _oblservice;

        public OBL_Controller(IOblservice oblservice)
        {
            _oblservice = oblservice;
        }


        [Route(" get-lead-details")]
        [HttpPost]
        public async Task<IActionResult> GetLeadDetails(string accessToken, string SalesPersonEmpId)
        {
            var response = await _oblservice.GetLeadDetailsAsync(accessToken, SalesPersonEmpId);
            return Ok(response);
        }
    }
}
