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
        public async Task<BaseResponse> GetHierarchyAsync(string accessToken, string empCode)
        {
            var requestUrl = $"https://www.zohoapis.com/crm/v7/functions/heiarchy_adhesive/actions/execute?auth_type=apikey&zapikey=1003.6ceb2d2934296e02f21ffe5a9adfaf29.155d45a2b6938e2e9c3e20e3caac7d92";

            var requestData = new
            {
                EmpCode = empCode,

            };

            var serializedData = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(serializedData, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);

                var response = await client.PostAsync(requestUrl, content);
                var result = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<HierarchyResponse>(result);

                return new BaseResponse
                {
                    Response = responseObj,
                };
            }
        }


        public async Task<BaseResponse> GetDashboardAsync(string accessToken, string adhesiveBhCode, string adhesiveNhCode, string adhesiveSalesPersonEmpId, string closingDate, string createdTime)
        {
            var response = new AdhesiveDashboard();
            int offSet = 0;

            while (true)
            {
                var dd = await Dashboard(accessToken, adhesiveBhCode, adhesiveNhCode, adhesiveSalesPersonEmpId,closingDate,createdTime, offSet);
                if (dd == null || dd?.data == null)
                {
                    break;
                }
                response.data.AddRange(dd?.data);

                if (dd.info?.more_records == true)
                {
                    offSet += 200;
                }
                else
                {
                    break;
                }
            }

            response.info = new AdhesivesDashboardInfo
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };

        }

        private async Task<AdhesiveDashboard> Dashboard(string accessToken, string adhesiveBhCode, string adhesiveNhCode, string adhesiveSalesPersonEmpId,string closingDate,string createdTime,  int offSet)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v8/coql");
            //var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            //var oneYearBefore = DateTime.Today.AddYears(-1).ToString("yyyy-MM-dd");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            var content = new StringContent($@"{{""select_query"":""select Stage, COUNT(id) as Total_Count,SUM(Qty_required) as Qty_Total from Deals where ((((Stage = 'Closed Won') and ((Closing_Date >='{closingDate}'))) or ((Stage in ('Qualification', 'Junk Lead', 'Closed Lost', 'Spoken to Customer', 'Quotation Shared','Samples shared')) and ((Created_Time > '{createdTime}')))) and ((Adhesive_Sales_Person_Emp_ID = '{adhesiveSalesPersonEmpId}' or Adhesive_NH_Code = '{adhesiveNhCode}')or Adhesive_BH_Code = '{adhesiveBhCode}')) group by Stage limit 200 offset {offSet}""}}", null, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AdhesiveDashboard>(result);
        }

        public async Task<BaseResponse> GetLeadsAsync(string accessToken, string adhesiveBhCode, string adhesiveNhCode, string adhesiveSalesPersonEmpId,int minQty,int maxQty, string createdTime)
        {
            var response = new AdheshivGetLeadByStageResponse();
            int offSet = 0;

            while (true)
            {
                var dd = await GetLead(accessToken, adhesiveBhCode, adhesiveNhCode, adhesiveSalesPersonEmpId, minQty, maxQty,createdTime ,offSet);
                if (dd == null || dd?.data == null)
                {
                    break;
                }
                response.data.AddRange(dd?.data);

                if (dd.info?.more_records == true)
                {
                    offSet += 200;
                }
                else
                {
                    break;
                }
            }

            response.info = new AdheshivGetLeadByStageInfo
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };

        }

        private async Task<AdheshivGetLeadByStageResponse> GetLead(string accessToken, string adhesiveBhCode, string adhesiveNhCode, string adhesiveSalesPersonEmpId, int minQty, int maxQty,string createdTime, int offSet)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v8/coql");
            //var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            //var oneYearBefore = DateTime.Today.AddYears(-1).ToString("yyyy-MM-dd");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            var content = new StringContent($@"{{""select_query"":""select Adhesive_Type,Adhesive_Sales_Person_Name,Stage,Stage_Category,Closing_Date,Qty_required,Adhesive_Sales_Person_Emp_ID,Adhesive_BH_Code,Adhesive_NH_Code from Deals where ( (((Created_Time > '{createdTime}')) and (((Adhesive_Sales_Person_Emp_ID = '{adhesiveSalesPersonEmpId}' or Adhesive_NH_Code = '{adhesiveNhCode}') or Adhesive_BH_Code = '{adhesiveBhCode}') and (Stage_Category = 'Closed')))) limit 200 offset {offSet}""}}", null, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AdheshivGetLeadByStageResponse>(result);
        }


        public async Task<BaseResponse> UpdateDealTimelineAsync( string accessToken, AdhesiveDealTimelineRequest request)
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
