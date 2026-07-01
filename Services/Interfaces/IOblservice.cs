using OBL_Zoho.Models.Request;
using OBL_Zoho.Models.Response;

namespace OBL_Zoho.Services.Interfaces
{
    public interface IOblservice
    {
        Task<BaseResponse> GenerateRefreshToken();
        Task<BaseResponse> GetLeadDetailsAsync(string accessToken, string id);
        Task<BaseResponse> UpdateNotesAsync(string accessToken, UpdateNotesForNewSection obj);
        Task<BaseResponse> GetHierarchyAsync(string accessToken,string empCode);
        Task<BaseResponse> GetLeadByStageAsync(string accessToken, string SalesPersonEmpId, string createdTime, int minSqmt, int maxSqmt, string stageCategory,string closingDate, string nhCode, string zmCode, int offSet, int limit);
        Task<BaseResponse> DashboardAsync(string accessToken, string salesPersonEmpId, string closingDate, string createdTime, string nhCode, string zmCode);
        Task<BaseResponse> AddProjectInstallmentAsync(string accessToken, ProjectInstallmentRequest model);
        Task<BaseResponse> UpdatePmtAsync(string accessToken, UpdatePmtRequest obj);
        
    }
}
