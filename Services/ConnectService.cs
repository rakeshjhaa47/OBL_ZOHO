using DocumentFormat.OpenXml.Math;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OBL_Zoho.Models.Response;
using OBL_Zoho.Services.Interfaces;
using System.Net.Http.Headers;

namespace OBL_Zoho.Services
{
    public class ConnectService : IConnectService
    {
        private readonly FirebaseforConnect _firebaseforConnect;

        public ConnectService(IOptions<FirebaseforConnect> options)
        {
            _firebaseforConnect = options.Value;

        }
        public async Task<BaseResponse> GenerateRefreshTokenForOblConnect()
        {
            var request = "https://accounts.zoho.com/oauth/v2/token";

            var client = new HttpClient();
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("refresh_token", "1000.ae08c7feb3cff59a5fe0e16d2eeba2dd.a5f6e4b8a90ced047aa490d16cb90501");
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



        public async Task<BaseResponse> CpSummaryAsync(string accessToken, string Assigned_CP_By_Agent, string Created_Time)
        {
            var response = new OBLConnect();
            int offSet = 0;

            while (true)
            {
                var dd = await CpSummary(accessToken, Assigned_CP_By_Agent, Created_Time, offSet);
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

            response.info = new OBLInfo
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };

        }

        private async Task<OBLConnect> CpSummary(string accessToken,  string Assigned_CP_By_Agent, string Created_Time, int offSet)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            var content = new StringContent($@"{{""select_query"":""select Closing_Date,Tile_Requirement_in_Area_Sq_ft,Stage,Amount,Deal_Name,PCH_Email_ID,Sales_Person_Email_ID,City,Zip_Code,Tiling_Date_Likely_Purchase_Date,Assigned_CP_By_Agent,Mobile,Dealer_Name,Created_Time from Deals where ((Assigned_CP_By_Agent = '{Assigned_CP_By_Agent}') and (Created_Time >= '{Created_Time}')) ORDER BY Tile_Requirement_in_Area_Sq_ft DESC limit 200 offset {offSet}""}}", null, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OBLConnect>(result);
        }

        public async Task<BaseResponse> CpDashboardAsync(string accessToken, string Closing_Date, string Created_Time, string Assigned_CP_By_Agent)
        {
            var response = new CountResponse();
            int offSet = 0;

            while (true)
            {
                var dd = await CpDashboard(accessToken, Closing_Date, Created_Time, Assigned_CP_By_Agent, offSet);
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

            response.info = new CountInfo
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };

        }

        private async Task<CountResponse> CpDashboard(string accessToken, string Closing_Date, string Created_Time, string Assigned_CP_By_Agent, int offSet)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            var content = new StringContent($@"{{""select_query"":""select Stage, COUNT(id) as Total_Count, SUM(Amount) as Total_Amount, SUM(Tile_Requirement_in_Area_Sq_ft) as Tile_Total from Deals where (((Stage = 'Closed Won' and Closing_Date >='{Closing_Date}') or (Stage in ('Qualification', 'Junk Lead', 'Closed Lost', 'Not Contactable - 4', 'Spoken to Customer', 'Quotation Shared', 'Scheduled a visit', 'Visited Store', 'Samples shared') and Created_Time >= '{Created_Time}')) and (Assigned_CP_By_Agent = '{Assigned_CP_By_Agent}')) group by Stage limit 200 offset {offSet}""}}", null, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CountResponse>(result);
        }


        public async Task<BaseResponse> CreateFireBaseTokenForConnect()
        {
            string token;
            string jsonCredential = JsonConvert.SerializeObject(_firebaseforConnect);  
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jsonCredential);

            GoogleCredential credential;
            using (var stream = new MemoryStream(byteArray))
            {
                string[] scopes = new string[]
                {
                    "https://www.googleapis.com/auth/userinfo.email",
                    "https://www.googleapis.com/auth/firebase.database",
                    "https://www.googleapis.com/auth/firebase.messaging"
                };

                try
                {
                    credential = GoogleCredential.FromStream(stream).CreateScoped(scopes);
                }
                catch (Exception ex)
                {

                    throw new Exception("Error loading Firebase credentials", ex);
                }
            }

            try
            {
                token = await credential.UnderlyingCredential.GetAccessTokenForRequestAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating Firebase access token", ex);
            }

            return new BaseResponse
            {
                Response = token
            };

        }

        public async Task<BaseResponse> ConnectAllStageAsync(string accessToken, string Assigned_CP_By_Agent, string Created_Time, string Stage_Category, string MaxRequirement, string MinRequirement, int limit, int offSet)
        {
            var response = new ConnectAllResponse();

            var dd = await ConnectAll(accessToken, Assigned_CP_By_Agent, Created_Time, Stage_Category, MaxRequirement, MinRequirement, limit, offSet);
            if (dd?.data != null)
            {
                response.data.AddRange(dd.data);
            }

            response.info = new InfoAllData
            {
                count = response.data.Count,
                more_records = dd.info.more_records
            };

            return new BaseResponse
            {
                Response = response
            };

        }

        private async Task<ConnectAllResponse> ConnectAll(string accessToken, string Assigned_CP_By_Agent, string Created_Time, string Stage_Category, string MaxRequirement, string MinRequirement,int limit, int offSet)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            var content = new StringContent($@"{{""select_query"":""select Closing_Date,Final_Tile_Requirement_in_Area_Sq_ft,Tile_Requirement_in_Area_Sq_ft,Stage,Amount,Deal_Name,PCH_Email_ID,Sales_Person_Email_ID,City,Zip_Code,Tiling_Date_Likely_Purchase_Date,Mobile,Dealer_Name,Created_Time,Recent_Stage_Update_Date_Time,Stage_Category,Assigned_CP_By_Agent from Deals where ((((Assigned_CP_By_Agent  = '{Assigned_CP_By_Agent}') and (Created_Time > '{Created_Time}')) and (Stage_Category = '{Stage_Category}')) and (Tile_Requirement_in_Area_Sq_ft between '{MinRequirement}' and '{MaxRequirement}')) ORDER BY Tile_Requirement_in_Area_Sq_ft DESC limit {limit} offset {offSet}""}}", null, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);
            if ((int)response.StatusCode == 204)
            {
                return new ConnectAllResponse
                {
                    data = new List<DataResponse>(),
                    info = new InfoAllData()
                };

            }
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ConnectAllResponse>(result); 
        }

        public async Task<BaseResponse> ConnectDashboardAsync(string accessToken, string Assigned_CP_By_Agent, string Start_Date, string End_Date)
        {
            var response = new DashboardResponse();
            int offSet = 0;

            while (true)
            {
                var dd = await ConnectDashboard(accessToken, Assigned_CP_By_Agent, Start_Date, End_Date, offSet);
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

            response.info = new InfoDashboard
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };

        }

        private async Task<DashboardResponse> ConnectDashboard(string accessToken, string Assigned_CP_By_Agent, string Start_Date, string End_Date, int offSet)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            var content = new StringContent($@"{{""select_query"":""select Stage,Amount,Closing_Date,Final_Tile_Requirement_in_Area_Sq_ft from Deals where ((((Assigned_CP_By_Agent = '{Assigned_CP_By_Agent}' and Stage ='Closed Won') and (Closing_Date is not null)) and (Amount is not null)) and (Closing_Date between '{Start_Date}' and '{End_Date}')) limit 200 offset {offSet}""}}", null, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DashboardResponse>(result);
        }


        public async Task<BaseResponse> SummaryCountAsync(string accessToken, string Assigned_CP_By_Agent)
        {
            var response = new SummaryCountResponse();
            int offSet = 0;

            while (true)
            {
                var dd = await SummaryCountApi(accessToken, Assigned_CP_By_Agent, offSet);
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

            response.info = new InfoCount
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };

        }

        private async Task<SummaryCountResponse> SummaryCountApi(string accessToken, string Assigned_CP_By_Agent, int offSet)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");
            var createdTimeThreshold = DateTime.Now.AddDays(-90).ToString("yyyy-MM-ddTHH:mm:ssK");
            var closingDate = DateTime.Now.AddDays(-90).ToString("yyyy-MM-dd");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            var content = new StringContent($@"{{""select_query"":""select Stage, COUNT(id) as Total_Count, SUM(Amount) as Total_Amount, SUM(Tile_Requirement_in_Area_Sq_ft) as Tile_Total, SUM(Final_Tile_Requirement_in_Area_Sq_ft) as Final_Tile_Total from Deals where (((Stage = 'Closed Won' and Closing_Date >='{closingDate}') or (Stage in ('Qualification', 'Junk Lead', 'Closed Lost', 'Not Contactable - 4', 'Spoken to Customer', 'Quotation Shared', 'Scheduled a visit', 'Visited Store', 'Samples shared') and Created_Time >= '{createdTimeThreshold}')) and (Assigned_CP_By_Agent = '{Assigned_CP_By_Agent}')) group by Stage limit 200 offset {offSet}""}}", null, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SummaryCountResponse>(result);
        }
    }
}
