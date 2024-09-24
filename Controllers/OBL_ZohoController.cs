using Microsoft.AspNetCore.Mvc;
using OBL_Zoho.Models;
using OBL_Zoho.Models.Response;
using OBL_Zoho.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Dynamic;
using System.Net.Mime;

namespace OBL_Zoho.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class OBL_ZohoController : ControllerBase
    {
        private readonly IZohoService _zohoService;
        private readonly OblZohoContext _context;

        public OBL_ZohoController(IZohoService zohoService, OblZohoContext context)
        {
            _zohoService = zohoService;
            _context = context;
        }

        /// <summary>
        /// Generate new access token
        /// </summary>
        /// <param name=""></param>
        /// <remarks>API will generate new access token based on refresh token. Access token validity - 1 hour</remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Access token" })]
        [HttpPost]
        [Route("generate-access-token")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GenerateAccessToken()
        {
            return Ok(await _zohoService.GenerateAccessToken());
        }

        /// <summary>
        /// Get records
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks>Max fetch records 200 per page. Max page number 10. (Id, Last_Name, City, Zip_Code, Lead_Category, Tile_Category, Tiling_Date_Likely_Purchase_Date, Mobile, L2_Owner, Lead_Created_Time, PCH_Email_Id, PCH, Sales_Person, Tile_Requirement_in_Area_Sq_ft, Sales_Person_Employee_code, Lead_Type, Dealer_Type, Deal_Name, L2_Status, L1_Team_Remarks, Layout, L1_user_Name, Lead_Status, CP_Name, Stage, Amount, Owner, Modified_by, Created_by, Type, L2_Remarks, Design_Selection, Dealer_Code, Dealer_Name, Schedule_Store_Visit_Date, L2_Date_of_Visit_Planned_Visited, OBL_Exec_Amount, OBL_Exec_FLS_change_status_Remarks, OBL_Exec_FLS_lost_lead_Remarks)</remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Get Records" })]
        [HttpGet]
        [Route("get-records")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetRecords(string accessToken, string pageNumber, string perPageRecord)
        {
            return Ok(await _zohoService.GetRecords(accessToken, pageNumber, perPageRecord));
        }

        /// <summary>
        /// Get records
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks>Fetch record detail by ID (Id, Last_Name, City, Zip_Code, Lead_Category, Tile_Category, Tiling_Date_Likely_Purchase_Date, Mobile, L2_Owner, Lead_Created_Time, PCH_Email_Id, PCH, Sales_Person, Tile_Requirement_in_Area_Sq_ft, Sales_Person_Employee_code, Lead_Type, Dealer_Type, Deal_Name, L2_Status, L1_Team_Remarks, Layout, L1_user_Name, Lead_Status, CP_Name, Stage, Amount, Owner, Modified_by, Created_by, Type, L2_Remarks, Design_Selection, Dealer_Code, Dealer_Name, Schedule_Store_Visit_Date, L2_Date_of_Visit_Planned_Visited, OBL_Exec_Amount, OBL_Exec_FLS_change_status_Remarks, OBL_Exec_FLS_lost_lead_Remarks)</remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Get Records" })]
        [HttpGet]
        [Route("get-record-by-id")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetRecordsById(string accessToken, string id)
        {
            return Ok(await _zohoService.GetRecordsById(accessToken, id));
        }

        /// <summary>
        /// Get records
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks>Fetch record extra vdetail by ID (Id, Attachment, Dealer_Name, Amount, Purchase_Date, Closing_Date, Dealer_Type, Lead_Response_Medium_Whatsapp_Email_B2B_L2_Calli, Sales_Person_Status, Sales_Person_Customer_Remarks, Remarks_of_quotation_shared, Remarks_of_visit_store, Remarks_of_Sample_shared, Remarks_spoken_to_customer, Remarks)</remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Get Records" })]
        [HttpGet]
        [Route("get-extra-record-by-id")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetExtraRecordsById(string accessToken, string id)
        {
            return Ok(await _zohoService.GetRecordsById_Extra(accessToken, id));
        }

        /// <summary>
        /// Get records
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks>Fetch record by person name</remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Get Records" })]
        [HttpGet]
        [Route("get-record-by-name")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetRecordsByName(string accessToken, string name)
        {
            return Ok(await _zohoService.SearchRecordsByName(accessToken, name));
        }

        /// <summary>
        /// Update records
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks> </remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Update Records" })]
        [HttpPost]
        [Route("update-records")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Update(string accessToken, LeadData obj)
        {
            return Ok(await _zohoService.Update(accessToken, obj));
        }

        /// <summary>
        /// Get stage
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks></remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Stage" })]
        [HttpGet]
        [Route("get-stage-name")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetBlueprint(string accessToken, string id)
        {
            return Ok(await _zohoService.GetBlueprint(accessToken, id));
        }

        /// <summary>
        /// Update stage
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks></remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Stage" })]
        [HttpPut]
        [Route("update-stage-closed-won")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateBlueprintWon(string accessToken, string id, BlueprintUpdateRequest_ClosedWon bur)
        {
            return Ok(await _zohoService.UpdateBlueprint_ClosedWon(accessToken, id, bur));
        }

        /// <summary>
        /// Update stage
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks></remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Stage" })]
        [HttpPut]
        [Route("update-stage-closed-lost")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateBlueprintLost(string accessToken, string id, BlueprintUpdateRequest_ClosedLost bur)
        {
            return Ok(await _zohoService.UpdateBlueprint_ClosedLost(accessToken, id, bur));
        }

        /// <summary>
        /// Update stage
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks></remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Stage" })]
        [HttpPut]
        [Route("update-stage-quotation-shared")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateBlueprintQuotationShared(string accessToken, string id, BlueprintUpdateRequest_QuotationShared bur)
        {
            return Ok(await _zohoService.UpdateBlueprint_QuotationShared(accessToken, id, bur));
        }

        /// <summary>
        /// Update stage
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks></remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Stage" })]
        [HttpPut]
        [Route("update-stage-sample-shared")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateBlueprintSampleShared(string accessToken, string id, BlueprintUpdateRequest_SampleShared bur)
        {
            return Ok(await _zohoService.UpdateBlueprint_SampleShared(accessToken, id, bur));
        }

        /// <summary>
        /// Update stage
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks></remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Stage" })]
        [HttpPut]
        [Route("update-stage-visited-store")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateBlueprintVisitedStore(string accessToken, string id, BlueprintUpdateRequest_VisitedStore bur)
        {
            return Ok(await _zohoService.UpdateBlueprint_VisitedStore(accessToken, id, bur));
        }

        /// <summary>
        /// Update stage
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks></remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Stage" })]
        [HttpPut]
        [Route("update-stage-sales-person-pitch")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateBlueprintSalesPersonPitch(string accessToken, string id, BlueprintUpdateRequest_SalesPersonPitch bur)
        {
            return Ok(await _zohoService.UpdateBlueprint_SalesPersonPitch(accessToken, id, bur));
        }

        /// <summary>
        /// Update stage
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks></remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "Stage" })]
        [HttpPut]
        [Route("update-stage-schedule-visit")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateBlueprintScheduleVisit(string accessToken, string id, BlueprintUpdateRequest_ScheduleVisit bur)
        {
            return Ok(await _zohoService.UpdateBlueprint_ScheduleVisit(accessToken, id, bur));
        }

        ///// <summary>
        ///// Get all junk and non contactable leads from database. (type_id - 1 = junk, type_id - 2 = non contatable)
        ///// </summary>
        ///// <param name="AccessToken"></param>
        ///// <remarks></remarks>
        ///// <response code="200">Ok</response>
        //[SwaggerOperation(Tags = new[] { "DB" })]
        //[HttpGet]
        //[Route("get-junk-noncontactable-lead")]
        //[Consumes(MediaTypeNames.Application.Json)]
        //[Produces(MediaTypeNames.Application.Json)]
        //public async Task<IActionResult> GetJunkNonContactbleLead()
        //{
        //    return Ok(await _zohoService.GetJunkNonContactbleLead());
        //}

        /// <summary>
        /// Add junk and non contactable lead to database. (type_id - 1 = junk, type_id - 2 = non contatable)
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks></remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "DB" })]
        [HttpPost]
        [Route("add-junk-lead")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> AddJunkLead(string accessToken, string id, BlueprintUpdateRequest_JunkLead bur)
        {
            return Ok(await _zohoService.UpdateBlueprint_JunkLead(accessToken, id, bur));
        }

        /// <summary>
        /// Add non contactable lead to database. 
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <remarks></remarks>
        /// <response code="200">Ok</response>
        [SwaggerOperation(Tags = new[] { "DB" })]
        [HttpPost]
        [Route("add-non-contactable-lead")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> AddJunkNonContactbleLead(string accessToken, string id, BlueprintUpdateRequest_JunkLead bur)
        {
            return Ok(await _zohoService.UpdateBlueprint_JunkLead(accessToken, id, bur));
        }


        [SwaggerOperation(Tags = new[] { "RecordsWithEmail" })]
        [HttpPost]
        [Route("records-with-email")]
        public async Task<IActionResult> RecordsWithEmail(string accessToken, string email)
        {
            return Ok(await _zohoService.GetRecordsWithEmail(accessToken, email));
        }

        [SwaggerOperation(Tags = new[] { "GetJunkData" })]
        [HttpPost]
        [Route("junk-data")]
        public async Task<IActionResult> GetJunkData(string junkData)
        {
            return Ok(await _zohoService.GetJunkData(junkData));
        }

        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPost]
        [Route("records-with-ems")]
        public async Task<IActionResult> RecordsWithEms(string accessToken, string pchEmailId, bool isEmployee = false)
        {
            return Ok(await _zohoService.GetRecordsWithEms(accessToken, pchEmailId, isEmployee));
        }



        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPost]
        [Route("get-zonal-manager-data")]
        public async Task<IActionResult> GetZonalManagerData(string code)
        {
            return Ok(await _zohoService.GetZonalManagerData(code));
        }

        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPost]
        [Route("get-brach-manager-data")]
        public async Task<IActionResult> GetBranchManagerData(string code)
        {
            return Ok(await _zohoService.GetBranchManagerData(code));
        }


        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPost]
        [Route("get-sales-employee-data")]
        public async Task<IActionResult> GetSalesEmployeeData(string code)
        {
            return Ok(await _zohoService.GetSalesEmployeeData(code));
        }

        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPost]
        [Route("get-sales-employee-personal-data")]
        public async Task<IActionResult> GetSalesEmployeePersonalData(string code)
        {
            return Ok(await _zohoService.GetSalesEmployeePersonalData(code));
        }


        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPost]
        [Route("get-details-by-code")]
        public async Task<IActionResult> GetDetailsByCode(string code)
        {
            return Ok(await _zohoService.GetDetailsByCode(code));
        }

        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPost]
        [Route("get-details-by-zmcode")]
        public async Task<IActionResult> GetDetailsByZMCode(string code)
        {
            return Ok(await _zohoService.GetDetailsByZMCode(code));
        }
        
        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPost]
        [Route("get-data-by-zhcode")]
        public async Task<IActionResult> GetDataByZHCode(string accessToken, string pageNumber, string code)
        {
            return Ok(await _zohoService.GetDataByZHCode(accessToken, pageNumber, code));
        }

        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPost]
        [Route("get-hierachydata")]
        public async Task<IActionResult> HierachyData(string code)
        {
            return Ok(await _zohoService.GetDataByCode(code));
        }

        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPost]
        [Route("get-User-by-code")]
        public async Task<IActionResult> GetUserByCode(string code)
        {
            return Ok(await _zohoService.GetUserByCode(code));
        }

        [SwaggerOperation(Tags = new[] { "Update SalesPersonNotes" })]
        [HttpPut]
        [Route("update-SalesPersonNotes")]
        public async Task<IActionResult> UpdateSalesPersonsNotes(string accessToken, UpdateSalesPersonNotes obj)
        {
            return Ok(await _zohoService.UpdateSalesPersonNotesAsync(accessToken, obj));
        }

        [SwaggerOperation(Tags = new[] { "Get LeadById" })]
        [HttpGet]
        [Route("get-LeadById")]
        public async Task<IActionResult> GetLeadById(string accessToken, string id)
        {
            return Ok(await _zohoService.GetSalesPersonNotesAsync(accessToken, id));
        }

        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPost]
        [Route("get-Employyee-Leads")]
        public async Task<IActionResult> GetEmployyeeLeads(string pchEmailId, bool isEmployee = false)
        {
            return Ok(await _zohoService.GetRecordsWithEmsData(pchEmailId, isEmployee));
        }


        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPost]
        [Route("Get-ZhLeads")]
        public async Task<IActionResult> GetZhLeads(string code)
        {
            return Ok(await _zohoService.GetDataByZHCodeData(code));
        }

        [SwaggerOperation(Tags = new[] { "RecordsWithEms" })]
        [HttpPut]
        [Route("update-FLSDeal")]
        public async Task<IActionResult> UpdateFLSDeal(string accessToken, UpdateOwnerDealRequest obj)
        {
            return Ok(await _zohoService.AssignOwnerDeal(accessToken, obj));
        }

        [SwaggerOperation(Tags = new[] { "Get LeadById" })]
        [HttpGet]
        [Route("get-LeadDetailsBYId")]
        public async Task<IActionResult> GetLeadDetailsBYId(string accessToken, string id)
        {
            return Ok(await _zohoService.GetLeadDetailsBYIdAsync(accessToken, id));
        }

        [SwaggerOperation(Tags = new[] { "SaveWonData" })]
        [HttpPut]
        [Route("save-WonData")]
        public async Task<IActionResult> SaveWonData(string accessToken, CategoryDetailsDatum obj)
        {
            return Ok(await _zohoService.SaveWonDataAsync(accessToken, obj));
        }

        [SwaggerOperation(Tags = new[] { "GetTileArea" })]
        [HttpGet]
        [Route("get-TileArea")]
        public async Task<IActionResult> GetTileArea()
        {
            return Ok(await _zohoService.GetTileAreaAsync());
        }

        [SwaggerOperation(Tags = new[] { "GenerateExcel" })]
        [HttpPost]
        [Route("GenerateExcel")]
        public async Task<IActionResult> GenerateExcel([FromBody] ExpandoObject person)
        {
            if (person == null || !person.Any())
                return BadRequest("No data provided.");

            var response = await _zohoService.GenerateExcelAsync(person);
            return File(response.FileContent, response.ContentType, response.FileName);

        }

        [SwaggerOperation(Tags = new[] { "GetZhLeadSummary" })]
        [HttpPost]
        [Route("GetZhLeadSummary")]
        public async Task<IActionResult> GetZhLeadSummary(string? ZM_Code, string? ZH_Code,string? pch_email_id, string? Sales_Person_Emp_ID)
        {
            return Ok(await _zohoService.GetLeadsForAsync(ZM_Code, ZH_Code, pch_email_id, Sales_Person_Emp_ID));
        }


        [SwaggerOperation(Tags = new[] { "GetActiveLeadByDate" })]
        [HttpPost]
        [Route("GetActiveLeadByDate")]
        public async Task<IActionResult> GetActiveLeadByDate(string PCH_Email_ID, string Start_Date, string End_Date)
        {
            return Ok(await _zohoService.GetActiveLeadsAsync(PCH_Email_ID, Start_Date, End_Date));
        }

        [SwaggerOperation(Tags = new[] { "DealSort" })]
        [HttpPost]
        [Route("DealSort")]
        public async Task<IActionResult> DealSort(string PCH_Email_ID, string Start_Date, string End_Date)
        {
            return Ok(await _zohoService.DealSortDataAsync(PCH_Email_ID, Start_Date, End_Date));
        }


        [SwaggerOperation(Tags = new[] { "GetSummaryDashboard" })]
        [HttpPost]
        [Route("GetSummaryDashboard")]
        public async Task<IActionResult> GetSummaryDashboard(string? ZM_Code, string? ZH_Code, string? PCH_Email_ID, string? Sales_Person_Emp_ID,   string Start_Date, string End_Date)
        {
            return Ok(await _zohoService.ClosedWonAsync(ZM_Code, ZH_Code, PCH_Email_ID, Sales_Person_Emp_ID, Start_Date, End_Date));
        }
    }
}
