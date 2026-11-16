using OBL_Zoho.Models.Response;

namespace OBL_Zoho.Services.Interfaces
{
    public interface ITilekartnewUIService
    {
        Task<BaseResponse> DashboardAsync(string accessToken, string secondaryEmail);

    }
}
