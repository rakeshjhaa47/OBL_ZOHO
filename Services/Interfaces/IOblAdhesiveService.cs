using OBL_Zoho.Models.Request;
using OBL_Zoho.Models.Response;

namespace OBL_Zoho.Services.Interfaces
{
    public interface IOblAdhesiveService
    {
        Task<BaseResponse> GetHierarchyAsync(string accessToken, string empCode);
        Task<BaseResponse> GetDashboardAsync(string accessToken, string adhesiveBhCode, string adhesiveNhCode, string adhesiveSalesPersonEmpId, string closingDate, string createdTime);
        Task<BaseResponse> GetLeadsAsync(string accessToken, string adhesiveBhCode, string adhesiveNhCode, string adhesiveSalesPersonEmpId, int minQty, int maxQty, string createdTime);
        Task<BaseResponse> UpdateDealTimelineAsync(string accessToken, AdhesiveDealTimelineRequest request);
        Task<BaseResponse> GenerateRefreshToken();
        Task<BaseResponse> GetDealByIdAsync(string accessToken, string dealId);
        Task<BaseResponse> AdhesiveStageChangeAsync(string accessToken, AdhesiveStageChange stageChangeRequest);
    }
}
