using OBL_Zoho.Models;
using OBL_Zoho.Models.Request;
using OBL_Zoho.Models.Response;
using System.Dynamic;
using static OBL_Zoho.Models.Response.UpdateJunkNonContactbleLead;

namespace OBL_Zoho.Services.Interfaces
{
    public interface IZohoService
    {
        Task<BaseResponse> GenerateAccessToken();
        Task<BaseResponse> GenerateRefreshToken();
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
        Task<BaseResponse> UpdateJunkNonContactbleLeadAsync(string accessToken, string id, UpdateRequestNonContactbleJunkLead bur);
        Task<BaseResponse> UpdateBlueprint_NonContactableLead(string accessToken, string id, BlueprintUpdateRequest_NonContactableLead bur);
        Task<BaseResponse> GetRecordsWithEms(string accessToken, string pchEmailId, bool isEmployee = false);
        //Task<BaseResponse> GetSalesEmployeeData(string accessToken, string salesPersonEmpID);
        Task<BaseResponse> GetZonalManagerData(string refreshToken,string code);
        Task<BaseResponse> GetBranchManagerData(string refreshToken,string code);
        Task<BaseResponse> GetSalesEmployeePersonalData(string refreshToken,string emailId);
        Task<BaseResponse> GetDetailsByCode(string refreshToken, string code);
        Task<BaseResponse> GetSalesEmployeeData(string refreshToken,string code);
        Task<BaseResponse> GetDetailsByZMCode(string refreshToken, string code);
        Task<BaseResponse> GetDataByZHCode(string accessToken, string pageNumber, string code);
        Task<DataByCodeResponse> GetDataByCode(string code);
        Task<BaseResponse> GetUserByCode(string code);
        Task<BaseResponse> UpdateSalesPersonNotesAsync(string accessToken, UpdateSalesPersonNotes obj);
        Task<BaseResponse> GetSalesPersonNotesAsync(string accessToken, string id);
        Task<BaseResponse> GetRecordsWithEmsData(string refreshToken ,string pchEmailId, bool isEmployee);
        Task<BaseResponse> GetDataByZHCodeData(string refreshToken,string code);
        Task<BaseResponse> AssignOwnerDeal(string accessToken, UpdateOwnerDealRequest obj);
        Task<BaseResponse> GetLeadDetailsBYIdAsync(string accessToken, string id);
        Task<BaseResponse> SaveWonDataAsync(string accessToken, CategoryDetailsDatum obj);
        Task<BaseResponse> GetTileAreaAsync();
        Task<ExcelResponse> GenerateExcelAsync(ExpandoObject person);
        Task<BaseResponse> GetLeadsForAsync(string refreshToken,string? ZM_Code, string? ZH_Code, string? pch_email_id, string? Sales_Person_Emp_ID);

        Task<BaseResponse> GetActiveLeadsAsync(string refreshToken,string PCH_Email_ID, string Start_Date, string End_Date);

        Task<BaseResponse> DealSortDataAsync(string refreshToken,string PCH_Email_ID, string Start_Date, string End_Date);

        Task<BaseResponse> ClosedWonAsync(string refreshToken,string? ZM_Code, string? ZH_Code, string? PCH_Email_ID, string? Sales_Person_Emp_ID, string Start_Date, string End_Date);
        Task<BaseResponse> CreateFireBaseToken();
        Task<BaseResponse> UpdateStageVisitedStoreAsync(string accessToken, string id, BlueprintRequest bur);

        Task<BaseResponse> getLeadsByStageAsync(string refreshToken, string Stage_Category , string Sales_Person_Email_ID , string createdTime, string MaxAreasqft, string MinAreaSqFt, bool isEmployee,int offSet,int limit);

        Task<BaseResponse> OblSearchAsync(string accessToken, string Deal_Name, string City, string? ZM_Code, string Stage_Category, string SalesPersonEmailID, string PCHEmailId);
        Task<BaseResponse> HomePageLeadsAsync(string refreshToken, string PCH_Email_ID, bool isEmployee = false);

        Task<BaseResponse> OblSummaryAsync(string refreshToken, string Sales_Person_Emp_ID, bool isEmployee = false);
        Task<BaseResponse> CpConfirmationAsync(string refreshToken, string ZH_Code, string ZM_Code, string Sales_Person_Email_ID, string PCH_Email_ID, string Closing_Date, string CP_Confirmed_the_Sale);


    }
}
