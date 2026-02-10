using OBL_Zoho.Models.Request;
using OBL_Zoho.Models.Response;

namespace OBL_Zoho.Services.Interfaces
{
    public interface IOblAdhesiveService
    {
        Task<BaseResponse> GetHierarchyAsync(string accessToken, AdhesiveHierarchyRequest request);
        Task<BaseResponse> GetDashboardAsync(string accessToken, AdhesiveDashboardRequest request);
        Task<BaseResponse> GetLeadsAsync(string accessToken, AdhesiveLeadsRequest request);

        Task<BaseResponse> UpdateDealTimelineAsync(string accessToken, AdhesiveDealTimelineRequest request);
    }
}
