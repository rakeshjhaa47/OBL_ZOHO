using Newtonsoft.Json;
using OBL_Zoho.Models.Request;
using OBL_Zoho.Models.Response;
using OBL_Zoho.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace OBL_Zoho.Services
{
    public class OblAdhesiveService : IOblAdhesiveService
    {
        
        public async Task<BaseResponse> GetHierarchyAsync(string accessToken, AdhesiveHierarchyRequest request)
        {
            var url = "https://www.zohoapis.com/crm/v7/functions/heiarchy_adhesive/actions/execute" +
                      "?auth_type=apikey&zapikey=1003.6ceb2d2934296e02f21ffe5a9adfaf29.155d45a2b6938e2e9c3e20e3caac7d92";

            var content = new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8,
                "application/json");

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);

            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            return new BaseResponse
            {
                Response = JsonConvert.DeserializeObject<HierarchyResponse>(result)
            };
        }

        
        public async Task<BaseResponse> GetDashboardAsync(string accessToken, AdhesiveDashboardRequest request)
        {
            var url = "https://www.zohoapis.com/crm/v8/coql";

            var content = new StringContent(
                JsonConvert.SerializeObject(new { select_query = request.Select_Query }),
                Encoding.UTF8,
                "application/json");

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);

            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<AdhesiveDashboardResponse>(result);

            return new BaseResponse
            {
                Response = (data?.Data == null || !data.Data.Any()) ? null : data
            };
        }

        
        public async Task<BaseResponse> GetLeadsAsync(string accessToken, AdhesiveLeadsRequest request)
        {
            var url = "https://www.zohoapis.com/crm/v8/coql";

            var content = new StringContent(
                JsonConvert.SerializeObject(new { select_query = request.Select_Query }),
                Encoding.UTF8,
                "application/json");

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);

            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<AdhesiveLeadsResponse>(result);

            return new BaseResponse
            {
                Response =  data
            };
        }

        
        public async Task<BaseResponse> UpdateDealTimelineAsync(
            string accessToken,
            AdhesiveDealTimelineRequest request)
        {
            var url = "https://www.zohoapis.com/crm/v8/Deals";

            var zohoRequest = new
            {
                data = new List<object>
                {
                    new
                    {
                        id = request.Id,
                        Timleline = request.Timleline
                    }
                }
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(zohoRequest),
                Encoding.UTF8,
                "application/json");

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);

            var response = await client.PutAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            return new BaseResponse
            {
                Response = JsonConvert.DeserializeObject<AdhesiveDealUpdateResponse>(result)
            };
        }

    }
}
