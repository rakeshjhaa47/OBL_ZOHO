using OBL_Zoho.Models;
using OBL_Zoho.Models.Response;
using System.Dynamic;

namespace OBL_Zoho.Services.Interfaces
{
    public interface IZohoService
    {
        Task<BaseResponse> GenerateAccessToken();
        Task<BaseResponse> GetRecords(string accessToken, string pageNumber, string perPageRecord);
        Task<BaseResponse> GetRecordsById(string accessToken, string id);
        Task<BaseResponse> GetRecordsById_Extra(string accessToken, string id);
        Task<BaseResponse> SearchRecordsByName(string accessToken, string name);
        Task<BaseResponse> GetBlueprint(string accessToken, string id);
        Task<BaseResponse> Update(string accessToken, LeadData obj);
        Task<BaseResponse> UpdateBlueprint_ClosedWon(string accessToken, string id, BlueprintUpdateRequest_ClosedWon bur);
        Task<BaseResponse> UpdateBlueprint_ClosedLost(string accessToken, string id, BlueprintUpdateRequest_ClosedLost bur);
        Task<BaseResponse> UpdateBlueprint_QuotationShared(string accessToken, string id, BlueprintUpdateRequest_QuotationShared bur);
        Task<BaseResponse> UpdateBlueprint_SampleShared(string accessToken, string id, BlueprintUpdateRequest_SampleShared bur);
        Task<BaseResponse> UpdateBlueprint_VisitedStore(string accessToken, string id, BlueprintUpdateRequest_VisitedStore bur);
        Task<BaseResponse> UpdateBlueprint_SalesPersonPitch(string accessToken, string id, BlueprintUpdateRequest_SalesPersonPitch bur);
        Task<BaseResponse> UpdateBlueprint_ScheduleVisit(string accessToken, string id, BlueprintUpdateRequest_ScheduleVisit bur);
        Task<BaseResponse> GetJunkNonContactbleLead();
        Task<BaseResponse> AddJunkNonContactbleLead(Obl obl);
        Task<BaseResponse> GetRecordsWithEmail(string accessToken, string email);
        Task<BaseResponse> GetJunkData(string userId);
        Task<BaseResponse> UpdateBlueprint_JunkLead(string accessToken, string id, BlueprintUpdateRequest_JunkLead bur);
        Task<BaseResponse> UpdateBlueprint_NonContactableLead(string accessToken, string id, BlueprintUpdateRequest_NonContactableLead bur);
        Task<BaseResponse> GetRecordsWithEms(string accessToken, string pchEmailId, bool isEmployee = false);
        Task<BaseResponse> GetSalesEmployeeData(string accessToken, string salesPersonEmpID);
        Task<BaseResponse> GetZonalManagerData( string code);
        Task<BaseResponse> GetBranchManagerData(string code);
        Task<BaseResponse> GetSalesEmployeePersonalData(string emailId);
        Task<BaseResponse> GetDetailsByCode(string code);
        Task<BaseResponse> GetSalesEmployeeData(string code);
        Task<BaseResponse> GetDetailsByZMCode(string code);
        Task<BaseResponse> GetDataByZHCode(string accessToken, string pageNumber, string code);
        Task<DataByCodeResponse> GetDataByCode(string code);
        Task<BaseResponse> GetUserByCode(string code);
        Task<BaseResponse> UpdateSalesPersonNotesAsync(string accessToken, UpdateSalesPersonNotes obj);
        Task<BaseResponse> GetSalesPersonNotesAsync(string accessToken, string id);
        Task<BaseResponse> GetRecordsWithEmsData(string pchEmailId, bool isEmployee);
        Task<BaseResponse> GetDataByZHCodeData(string code);
        Task<BaseResponse> AssignOwnerDeal(string accessToken, UpdateOwnerDealRequest obj);
        Task<BaseResponse> GetLeadDetailsBYIdAsync(string accessToken, string id);
        Task<BaseResponse> SaveWonDataAsync(string accessToken, CategoryDetailsDatum obj);
        Task<BaseResponse> GetTileAreaAsync();
        Task<ExcelResponse> GenerateExcelAsync(ExpandoObject person);
        Task<BaseResponse> GetLeadsForAsync(string? ZM_Code, string? ZH_Code, string Start_Date, string End_Date);

        Task<BaseResponse> GetActiveLeadsAsync(string PCH_Email_ID, string Start_Date, string End_Date);

        Task<BaseResponse> DealSortDataAsync(string PCH_Email_ID, string Start_Date, string End_Date);
    }
}
