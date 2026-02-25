using DocumentFormat.OpenXml.Bibliography;
using Newtonsoft.Json;
using OBL_Zoho.Models.Request;
using OBL_Zoho.Models.Response;
using OBL_Zoho.Services.Interfaces;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace OBL_Zoho.Services
{
    public class OblAdhesiveService : IOblAdhesiveService
    {
        private readonly Random _random;
        public OblAdhesiveService()
        {
            _random = new Random();
        }

        public async Task<BaseResponse> GenerateRefreshToken()
        {
           
            int randomNumber = _random.Next(1, 3); // Generates a number between 1 and 3
            switch (randomNumber)
            {
                case 1:
                    return await GenerateRefreshTokens("1000.78d886945811640cc8896fd2ccb8edfb.2ffacb3b4513da63b6adca590ed1cd2b");
                case 2:
                    return await GenerateRefreshTokens("1000.9a5744cd5d81e9459f20646843c7489a.c19e166a4341a6119d3811ed55dc0e7e");
                default:
                    throw new InvalidOperationException("Invalid random number generated.");
            }
        }

        public async Task<BaseResponse> GenerateRefreshTokens(string token)
        {
            var request = "https://accounts.zoho.com/oauth/v2/token";

            var client = new HttpClient();
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("refresh_token", token);
            pairs.Add("client_id", "1000.CLKJQBSFMW6SANQRWQ64HKIVYC34VC");
            pairs.Add("client_secret", "163b44b012c0cd6246a3c2716f55e3be00f5d344d9");
            pairs.Add("grant_type", "refresh_token");
            pairs.Add("redirect_uri", "https://www.google.com/");

            var content = new FormUrlEncodedContent(pairs);
            var response = client.PostAsync(request, content).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<AccessTokenResponse>(result);
            return new BaseResponse
            {
                Response = userResponse,
            };
        }

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
                var dd = await Dashboard(accessToken, adhesiveBhCode, adhesiveNhCode, adhesiveSalesPersonEmpId, closingDate, createdTime, offSet);
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

        private async Task<AdhesiveDashboard> Dashboard(string accessToken, string adhesiveBhCode, string adhesiveNhCode, string adhesiveSalesPersonEmpId, string closingDate, string createdTime, int offSet)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v8/coql");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            var content = new StringContent($@"{{""select_query"":""select Stage as stage, COUNT(id) as totalCount,SUM(Qty_required) as qtyReq,SUM(Qty_delivered) as qtyDelivered from Deals where ((((Stage_Category = 'New') and ((Closing_Date >='{closingDate}'))) or ((Stage in ('Qualification', 'Junk Lead', 'Closed Lost', 'Spoken to Customer', 'Quotation Shared','Samples shared')) and ((Created_Time > '{createdTime}')))) and ((Adhesive_Sales_Person_Emp_ID = '{adhesiveSalesPersonEmpId}' or Adhesive_NH_Code = '{adhesiveNhCode}')or Adhesive_BH_Code = '{adhesiveBhCode}')) group by Stage limit 200 offset {offSet}""}}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AdhesiveDashboard>(result);
        }

        public async Task<BaseResponse> GetLeadsAsync(string accessToken, string adhesiveBhCode, string adhesiveNhCode, string adhesiveSalesPersonEmpId, int minQty, int maxQty, string createdTime, string stageCategory,int limit, int offSet)
        {
            var response = new AdheshivGetLeadByStage();
     
            var dd = await GetLead(accessToken, adhesiveBhCode, adhesiveNhCode, adhesiveSalesPersonEmpId, minQty, maxQty, createdTime, offSet, stageCategory, limit);
            if (dd?.data != null)
            {
                response.data.AddRange(dd?.data);
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

        private async Task<AdheshivGetLeadByStage> GetLead(string accessToken, string adhesiveBhCode, string adhesiveNhCode, string adhesiveSalesPersonEmpId, int minQty, int maxQty, string createdTime, int offSet, string stageCategory,int limit)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v8/coql");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            string oneYearCreatedTime = DateTime.Now.AddYears(-1).ToString("yyyy-MM-ddTHH:mm:ssK");
            var content = new StringContent($@"{{""select_query"":""select Deal_Name as contactName,City,Mobile,Adhesive_Type,Adhesive_Sales_Person_Name,Stage,Stage_Category,Closing_Date,Qty_required,Adhesive_Sales_Person_Emp_ID,Created_Time from Deals where ((Qty_required between '{minQty}' and '{maxQty}') and (((Qty_required >= 500 and Created_Time > '{oneYearCreatedTime}') or (Qty_required < 500 and Created_Time > '{createdTime}')) and (((Adhesive_Sales_Person_Emp_ID = '{adhesiveSalesPersonEmpId}' or Adhesive_NH_Code = '{adhesiveNhCode}') or Adhesive_BH_Code = '{adhesiveBhCode}') and (Stage_Category = '{stageCategory}')))) limit {limit} offset {offSet}""}}", null, "application/json");
            request.Content = content;
           
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AdheshivGetLeadByStage>(result);
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
        public async Task<BaseResponse> GetDealByIdAsync(string accessToken, string dealId)
        {
            var result = await GetDealById(accessToken, dealId);
            return new BaseResponse
            {
                Response = result
            };
        }

        private async Task<AdhesiveGetLeadByIdResponse> GetDealById(string accessToken, string dealId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.zohoapis.com/crm/v8/Deals/{dealId}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AdhesiveGetLeadByIdResponse>(result);
        }


        public async Task<BaseResponse> AdhesiveStageChangeAsync(string accessToken, AdhesiveStageChange stageChangeRequest)
        {
            var result = await AdhesiveStageChange(accessToken, stageChangeRequest);
            return new BaseResponse
            {
                Response = result
            };
        }

        private async Task<AdhesiveStageChangeResponse> AdhesiveStageChange(string accessToken, AdhesiveStageChange stageChangeRequest)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v7/functions/adhesive_blueprint/actions/execute?auth_type=apikey&zapikey=1003.6ceb2d2934296e02f21ffe5a9adfaf29.155d45a2b6938e2e9c3e20e3caac7d92");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

            var body = JsonConvert.SerializeObject(stageChangeRequest);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AdhesiveStageChangeResponse>(result);
        }
    }
}
