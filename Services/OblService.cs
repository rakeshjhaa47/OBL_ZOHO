using DocumentFormat.OpenXml.Office2010.Excel;
using Newtonsoft.Json;
using OBL_Zoho.Models.Request;
using OBL_Zoho.Models.Response;
using OBL_Zoho.Services.Interfaces;
using System;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;

namespace OBL_Zoho.Services
{
    public class OblService : IOblservice
    {
        private readonly Random _random;
        public OblService()
        {
            _random = new Random();
        }

        public async Task<BaseResponse> GenerateRefreshToken()
        {
            int randomNumber = _random.Next(1, 4); // Generates a number between 1 and 4
            switch (randomNumber)
            {
                case 1:
                    return await GenerateRefreshTokens("1000.1f0b5db913114be8dcc13360f9cc6356.f713c36207076eab3ea11388aaad1f3d");
                case 2:
                    return await GenerateRefreshTokens("1000.c05e3202f8be0e6b0c3c8dc410a2a72c.a5cf467f04a2c43f91356b5a83bcd1ca");
                case 3:
                    return await GenerateRefreshTokens("1000.3d24c491c4d8a5f836778bfe64179a2a.dca8494bc19ed9da52052a4492e51d4d");
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

        public async Task<BaseResponse> GetLeadDetailsAsync(string accessToken, string id)
        {
            var request = "https://www.zohoapis.com/crm/v8/Project_Opp/" + id;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);

            var searchDataResponse = await client.GetAsync(request);
            searchDataResponse.EnsureSuccessStatusCode();
            var result = await searchDataResponse.Content.ReadAsStringAsync();
            var responses = JsonConvert.DeserializeObject<GetLeadDetailsRoot>(result);

            return new BaseResponse
            {
                Response = responses,
            };
        }

        private async Task<NewSectionDashboardRoot> Dashboard(string accessToken, string SalesPersonEmpId, string closingDate, string createdTime,string nhCode,string zmCode,int offSet)
        {
            StringContent content;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");
            string oneYearCreatedTime = DateTime.Now.AddYears(-1).ToString("yyyy-MM-ddTHH:mm:ssK");
            var oneYearBeforeClosingDate = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

            content = new StringContent("{\"select_query\": \"select COUNT(id) as Leads_Count, Lead_Updation_Stage as stage, SUM(Recieved_Amount) as Total_Amount,SUM(Tile_Requirment_in_sqmt) as req_tile_area, SUM(Final_Requirement_Closed) as delivered_tile_area from Project_Opp  where ((((Lead_Updation_Stage = 'Closed Won'  or Lead_Updation_Stage = 'Won in Progress') and ((Tile_Requirment_in_sqmt >= 500 and Closing_Date >='"+oneYearBeforeClosingDate+"') or (Tile_Requirment_in_sqmt < 500 and Closing_Date >='"+closingDate+"'))) or ((Lead_Updation_Stage in ('Qualification','Spoken to customer', 'Not Contactable', 'Requirement Delayed', 'Meeting Done', 'Sampling Stage', 'Quotation Shared/Rate Negotiation', 'Won & Supplied', 'Project Lost')) and ((Tile_Requirment_in_sqmt >= 500 and Created_Time > '"+oneYearCreatedTime+"') or (Tile_Requirment_in_sqmt < 500 and Created_Time > '"+createdTime+"')))) and ((NHCode = '"+nhCode+"' or ZM_code = '"+zmCode+"') or (Sales_Person_Emp_Id = '"+SalesPersonEmpId+"'))) group by Lead_Updation_Stage limit 200 offset "+offSet+"\"}");

            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<NewSectionDashboardRoot>(result);
        }

        public async Task<BaseResponse> DashboardAsync(string accessToken, string SalesPersonEmpId, string closingDate, string createdTime, string nhCode, string zmCode)
        {
            var response = new NewSectionDashboardRoot();
            int offSet = 0;
            while (true)
            {
                var dd = await Dashboard(accessToken, SalesPersonEmpId, closingDate, createdTime,nhCode,zmCode, offSet);
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

            response.info = new NewSectionDashboardInfo
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };
        }

        public async Task<BaseResponse> UpdateNotesAsync(string accessToken, UpdateNotesForNewSection obj)
        {
            var request = "https://www.zohoapis.com/crm/v6/Project_Opp";

            var data = new ProjectOpportunityUpdate()
            {
                id = obj.id,
                Timelines = obj.Timelines.Select(timeline => new Timeline
                {
                    Name1 = timeline.Name1,
                    Emp_Id = timeline.Emp_Id,                
                    L1_Notes = timeline.L1_Notes,
                    Remarks = timeline.Remarks,
                    Types = timeline.Types,
                    Updated_Stage = timeline.Updated_Stage,
                    timelineType = timeline.timelineType
                }).ToList()
            };

            var requestData = new UpdateProjectOpportunityRequest
            {
                data = new List<ProjectOpportunityUpdate> { data }
            };

            var serializedData = JsonConvert.SerializeObject(requestData);
            var buffer = System.Text.Encoding.UTF8.GetBytes(serializedData);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = await client.PutAsync(request, byteContent);
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<UpdateProjectOpportunityResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> GetHierarchyAsync(string accessToken,int empCode)
        {
            var requestUrl = $"https://www.zohoapis.com/crm/v7/functions/test8/actions/execute?auth_type=apikey&zapikey=1003.6ceb2d2934296e02f21ffe5a9adfaf29.155d45a2b6938e2e9c3e20e3caac7d92&EmpCode={empCode}";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);

            var response = await client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<HierarchyResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        private async Task<GetLeadByStageForNewSectionRoot> GetLeadByStage(string accessToken, string SalesPersonEmpId, string createdTime, int minSqmt, int maxSqmt,string stageCategory, string closingDate, string nhCode, string zmCode, int offSet, int limit)
        {
            StringContent content;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");
            string oneYearCreatedTime = DateTime.Now.AddYears(-1).ToString("yyyy-MM-ddTHH:mm:ssK");
            var oneYearBeforeClosingDate = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            bool isClosed = string.Equals(stageCategory, "closed", StringComparison.OrdinalIgnoreCase);

            if (isClosed)
            {
                content = new StringContent("{\"select_query\": \"select Closing_Date, Tile_Requirment_in_sqmt, Final_Requirement_Closed, Contact_Person_Name, Lead_Updation_Stage, Amount, City, Sales_Person_Emp_Id, Contact_City, Contact_Number, Contact_Person_Details, Contact_Pin_Code, Contact_State, Name, Pincode, Project_Category, Project_Name, Salesperson_Name, Salesperson_Zone, State, Tiling_Month, Lost_to, Lost_Lead, Stage_Category from Project_Opp where ( ( (Tile_Requirment_in_sqmt between '"+minSqmt+"' and '"+maxSqmt+"') AND ( (Stage_Category = '"+stageCategory+"') AND ( ( (Tile_Requirment_in_sqmt >= 500 AND Closing_Date > '"+oneYearBeforeClosingDate+"') OR (Tile_Requirment_in_sqmt < 500 AND Closing_Date > '"+closingDate+"') ) ) ) ) AND ((NHCode = '"+nhCode+"' or ZM_code = '"+zmCode+"') or (Sales_Person_Emp_Id = '"+SalesPersonEmpId+"')) ) limit "+limit+" offset "+offSet+"\"}");
            }
            else
            {
                content = new StringContent("{\"select_query\": \"select Closing_Date, Tile_Requirment_in_sqmt, Final_Requirement_Closed, Contact_Person_Name, Lead_Updation_Stage, Amount, City, Sales_Person_Emp_Id, Contact_City, Contact_Number, Contact_Person_Details, Contact_Pin_Code, Contact_State, Name, Pincode, Project_Category, Project_Name, Salesperson_Name, Salesperson_Zone, State, Tiling_Month, Lost_to, Lost_Lead, Stage_Category from Project_Opp where ( ( (Tile_Requirment_in_sqmt between '"+minSqmt+"' and '"+maxSqmt+"') AND ( (Stage_Category in ('"+stageCategory+"')) AND ( ( (Tile_Requirment_in_sqmt >= 500 AND Created_Time > '"+oneYearCreatedTime+"') OR (Tile_Requirment_in_sqmt < 500 AND Created_Time > '"+createdTime+"') ) ) ) ) AND ((NHCode = '"+nhCode+"' or ZM_code = '"+zmCode+"') or  (Sales_Person_Emp_Id = '"+SalesPersonEmpId+"')) ) limit "+limit+" offset "+offSet+"\"}");
            }
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GetLeadByStageForNewSectionRoot>(result);
        }

        public async Task<BaseResponse> GetLeadByStageAsync(string accessToken, string SalesPersonEmpId, string createdTime, int minSqmt, int maxSqmt, string stageCategory, string closingDate, string nhCode, string zmCode, int offSet, int limit)
        {
            var response = new GetLeadByStageForNewSectionRoot();
            
            var dd = await GetLeadByStage(accessToken, SalesPersonEmpId, createdTime, minSqmt, maxSqmt, stageCategory,closingDate,nhCode,zmCode, offSet, limit);
            if (dd?.data != null)
            {
               response.data.AddRange(dd.data);
            }

            response.info = new GetLeadByStageForNewSectionInfo
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };
        }

        public async Task<BaseResponse> AddProjectInstallmentAsync(string accessToken, ProjectInstallmentRequest model)
        {
            var url = "https://www.zohoapis.com/crm/v8/Project_Installment";

            var requestData = new
            {
                data = new List<object>
                {       
                    new
                    {
                        Name = model.Name,
                        Receiver_Emp_Id = model.ReceiverEmpId,
                        Received_Amount = model.ReceivedAmount,

                        Associate_project = new
                        {
                            id = model.AssociateProject.Id
                        },

                        Category_Details = model?.Category_Details?.Select(c => new
                        {
                            Category = c.Category,
                            Box = c.Box,
                            Size = c.Size,
                            Sq_Mt = c.Sq_Mt,
                            Entry_Date = c.Entry_Date.ToString("yyyy-MM-ddTHH:mm:sszzz")
                        }).ToList()
                    }
                }
            };

            var serializedData = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(serializedData, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);

                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<ProjectInstallmentResponse>(result);

                return new BaseResponse
                {
                    Response = responseObj
                };
            }
        }

        public async Task<BaseResponse> UpdatePmtAsync(string accessToken, UpdatePmtRequest obj)
        {
            var request = "https://www.zohoapis.com/crm/v6/Project_Opp/" + obj.Id;

            var requestData = new
            {
                data = new List<object>
                {
                    new
                    {
                        PMT_No = obj.pmtData,
                    }
                }
            };

            var serializedData = JsonConvert.SerializeObject(requestData);
            var buffer = Encoding.UTF8.GetBytes(serializedData);

            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);

            var response = await client.PutAsync(request, byteContent);
            var result = await response.Content.ReadAsStringAsync();

            var userResponse = JsonConvert.DeserializeObject<PmtResponse>(result);

            return new BaseResponse
            {
                Response = userResponse
            };
        }

    }
}
