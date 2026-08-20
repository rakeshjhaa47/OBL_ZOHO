using Microsoft.AspNetCore.Mvc;
using OBL_Zoho.Models.Request;
using OBL_Zoho.Models.Response;
using OBL_Zoho.Services;
using OBL_Zoho.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

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

        [HttpPost]
        [Route("generate-access-token")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GenerateRefreshToken()
        {
            return Ok(await _oblservice.GenerateRefreshToken());
        }


        [Route("get-lead-details")]
        [HttpPost]
        public async Task<IActionResult> GetLeadDetails(string accessToken, string id)
        {
            var response = await _oblservice.GetLeadDetailsAsync(accessToken, id);
            return Ok(response);
        }

        [Route("dashboard")]
        [HttpPost]
        public async Task<IActionResult> dashboard(string accessToken, string salesPersonEmpId, string closingDate, string createdTime, string nhCode, string zmCode)
        {
            var response = await _oblservice.DashboardAsync(accessToken, salesPersonEmpId, closingDate, createdTime, nhCode, zmCode);
            return Ok(response);
        }

        [HttpPut]
        [Route("update-notes")]
        public async Task<IActionResult> UpdateNotes(string accessToken, UpdateNotesForNewSection obj)
        {
            return Ok(await _oblservice.UpdateNotesAsync(accessToken, obj));
        }

        [HttpGet]
        [Route("get-lead-by-stage")]
        public async Task<IActionResult> GetLeadByStage(string accessToken, string SalesPersonEmpId, string createdTime, int minSqmt, int maxSqmt, string stageCategory, string closingDate, string nhCode, string zmCode, int offSet, int limit)
        {
            return Ok(await _oblservice.GetLeadByStageAsync(accessToken, SalesPersonEmpId, createdTime, minSqmt, maxSqmt, stageCategory, closingDate, nhCode, zmCode, offSet, limit));
        }

        [HttpGet]
        [Route("get-hierarchy-data")]
        public async Task<IActionResult> GetHierarchy(string accessToken, string empCode)
        {
            return Ok(await _oblservice.GetHierarchyAsync(accessToken, empCode));
        }

        [HttpPost]
        [Route("add-projectinstallment")]
        public async Task<IActionResult> AddProjectInstallment(string accessToken, ProjectInstallmentRequest model)
        {
            return Ok(await _oblservice.AddProjectInstallmentAsync(accessToken, model));
        }

        [HttpPost]
        [Route("update-pmt")]
        public async Task<IActionResult> UpdatePmt(string accessToken, UpdatePmtRequest model)
        {
            return Ok(await _oblservice.UpdatePmtAsync(accessToken, model));
        }

        [HttpPost]
        [Route("sources-and-sub-sources")]
        public async Task<IActionResult> SourcesAndSubSources(string accessToken, string startDate, string endDate)
        {
            return Ok(await _oblservice.SourcesAndSubSourcesAsync(accessToken, startDate,endDate));
        }




    }
}
