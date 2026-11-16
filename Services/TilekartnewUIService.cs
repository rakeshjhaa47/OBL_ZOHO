using Azure;
using Newtonsoft.Json;
using OBL_Zoho.Models.Response;
using OBL_Zoho.Services.Interfaces;
using System.Net.Http.Headers;

namespace OBL_Zoho.Services
{
    public class TilekartnewUIService : ITilekartnewUIService
    {
        private async Task<TilekartUIApiRoot> Dashboard(string accessToken, string secondaryEmail,int offSet)
        {
            StringContent content;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

            content = new StringContent("{\"select_query\": \"select Name, Email, Mobile, City, Priority_Score, Sales_Person_Mobile, Sales_Person_Name, Secondary_Email, Stage, Tile_Requirement_in_Area_Sq_Mtr, Type_of_Customer, Target from Priority_Deals where Secondary_Email = '"+ secondaryEmail + "' limit 200 offset "+offSet+"\"}");

            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return  JsonConvert.DeserializeObject<TilekartUIApiRoot>(result);
        }

        public async Task<BaseResponse> DashboardAsync(string accessToken, string secondaryEmail)
        {
            var response = new TilekartUIApiRoot();
            int offSet = 0;
            while (true)
            {
                var dd = await Dashboard(accessToken, secondaryEmail, offSet);
                if (dd == null || dd?.data == null)
                {
                    break;
                }

                response.data.AddRange(dd.data);

                if (dd.info?.more_records == true)
                {
                    offSet += 200;
                }
                else
                {
                    break;
                }
            }

            response.info = new TilekartUIApiInfo
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };
        }
    }
}
