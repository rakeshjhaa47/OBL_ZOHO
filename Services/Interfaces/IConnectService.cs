using OBL_Zoho.Models.Response;

namespace OBL_Zoho.Services.Interfaces
{
    public interface IConnectService
    {
        Task<BaseResponse> GenerateRefreshTokenForOblConnect();

        Task<BaseResponse> CpSummaryAsync(string accessToken, string Assigned_CP_By_Agent, string Created_Time);

        Task<BaseResponse> CpDashboardAsync(string accessToken, string Closing_Date, string Created_Time, string Assigned_CP_By_Agent);

        Task<BaseResponse> CreateFireBaseTokenForConnect();

        Task<BaseResponse> ConnectAllStageAsync(string accessToken, string Assigned_CP_By_Agent, string Created_Time, string Stage_Category, string MaxRequirement, string MinRequirement, int limit, int offSet);

        Task<BaseResponse> ConnectDashboardAsync(string accessToken, string Assigned_CP_By_Agent, string Start_Date, string End_Date);

        Task<BaseResponse> SummaryCountAsync(string accessToken, string Assigned_CP_By_Agent);

        Task<BaseResponse> SearchApiAsync(string accessToken, string Deal_Name, string City, string Assigned_CP, string Stage_Category);


    }
}
