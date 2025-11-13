using OBL_Zoho.Models.Response;

namespace OBL_Zoho.Services.Interfaces
{
    public interface IOblservice
    {
        Task<BaseResponse> GetLeadDetailsAsync(string accessToken, string SalesPersonEmpId);

    }
}
