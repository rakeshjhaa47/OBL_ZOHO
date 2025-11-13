using Newtonsoft.Json;
using OBL_Zoho.Models.Response;
using OBL_Zoho.Services.Interfaces;
using System.Net.Http.Headers;

namespace OBL_Zoho.Services
{
    public class OblService : IOblservice
    {
        private async Task<SalesPersonRoot> GetLeadDetails(string accessToken, string SalesPersonEmpId, int offSet)
        {
            StringContent content;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

            content = new StringContent("{\"select_query\": \"select Parent_Id.Sales_Person_Emp_Id,Parent_Id.Name, Parent_Id.Project_Name, Parent_Id.Owner, Parent_Id.Project_Category, Parent_Id.Contact_State, Parent_Id.Contact_Pin_Code, Parent_Id.Contact_Person_Name, Parent_Id.Contact_Person_Details, Parent_Id.Contact_Number, Parent_Id.Tile_Requirment_in_sqmt, Parent_Id.Tiling_Month, Parent_Id.Sales_person_Branch, Parent_Id.Salesperson_Zone, Parent_Id.Sales_Person_Email, Parent_Id.City, Parent_Id.State, Parent_Id.Pincode, Parent_Id.Contact_City, Types, Remarks, Name1, Created_Time, L1_Notes from Notes_Remarks where Parent_Id.Sales_Person_Emp_Id = '"+SalesPersonEmpId+"' limit 200 offset "+offSet+"\"}");

            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SalesPersonRoot>(result);
        }

        public async Task<BaseResponse> GetLeadDetailsAsync(string accessToken, string SalesPersonEmpId)
        {
            var response = new SalesPersonRoot();
            int offSet = 0;
            while (true)
            {
                var dd = await GetLeadDetails(accessToken, SalesPersonEmpId, offSet);
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

            response.info = new SalesPersonInfo
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
