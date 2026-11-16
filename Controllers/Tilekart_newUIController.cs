using Microsoft.AspNetCore.Mvc;
using OBL_Zoho.Services.Interfaces;

namespace OBL_Zoho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tilekart_newUIController : ControllerBase
    {
        private readonly ITilekartnewUIService _tilekartnewUIService;
        public Tilekart_newUIController(ITilekartnewUIService tilekartnewUIService)
        {
            _tilekartnewUIService = tilekartnewUIService;
        }

        [Route("dashboard")]
        [HttpPost]
        public async Task<IActionResult> dashboard(string accessToken, string secondaryEmail)
        {
            var response = await _tilekartnewUIService.DashboardAsync(accessToken, secondaryEmail);
            return Ok(response);
        }
    }
}
