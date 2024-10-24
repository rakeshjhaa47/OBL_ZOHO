using OBL_Zoho.Models.Response;

namespace OBL_Zoho.Services.Interfaces
{
    public interface IConnectService
    {
        Task<BaseResponse> GenerateRefreshTokenForOblConnect();

        Task<BaseResponse> CpSummaryAsync( string Assigned_CP_By_Agent, string Created_Time);

        Task<BaseResponse> CpDashboardAsync(string Closing_Date, string Created_Time, string Assigned_CP_By_Agent);

    }
}
