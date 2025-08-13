using DocumentFormat.OpenXml.Math;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OBL_Zoho.Models.Response;
using OBL_Zoho.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OBL_Zoho.Services
{
    public class ConnectService : IConnectService
    {
        private readonly FirebaseforConnect _firebaseforConnect;
        private readonly Random _random;

        public ConnectService(IOptions<FirebaseforConnect> options)
        {
            _firebaseforConnect = options.Value;
            _random = new Random();

        }

        public async Task<BaseResponse> GenerateRefreshTokenForOblConnect()
        {
            int randomNumber = _random.Next(1, 6); // Generates a number between 1 and 6
            switch (randomNumber)
            {
                case 1:
                    return await GenerateRefreshTokens("1000.1f50f37550dbd05ea1f5154ca22a7ad4.d7a7b0f8df61e2a36975874173d72503");
                case 2:
                    return await GenerateRefreshTokens("1000.92173a1fd852c400b2ade75c6624343a.093199d0f13563af753e5426b637766f");
                case 3:
                    return await GenerateRefreshTokens("1000.d1720c3349c8563726a51e72825c1eb0.d4ac73d6154a8325bbeebdaded301249");
                case 4:
                    return await GenerateRefreshTokens("1000.129675f9e9898a0f3ddc3004fad1294f.d5ff4ee8d0e28d817d5a755840b43809");
                case 5:
                    return await GenerateRefreshTokens("1000.646c2fa60233c0766f5e4c8615e10e31.c350390c1b336fe84205a21f5a9fdc27");
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

        public async Task<BaseResponse> ConnectAllStageAsync(string accessToken, string Assigned_CP_By_Agent, string Created_Time, string Stage_Category, string MaxRequirement, string MinRequirement, int limit, int offSet, bool filterByTileRequirementArea)
        {
            var response = new ConnectAllResponse();

            var dd = await ConnectAll(accessToken, Assigned_CP_By_Agent, Created_Time, Stage_Category, MaxRequirement, MinRequirement, limit, offSet, filterByTileRequirementArea);
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

        private async Task<ConnectAllResponse> ConnectAll(string accessToken, string Assigned_CP_By_Agent, string Created_Time, string Stage_Category, string MaxRequirement, string MinRequirement,int limit, int offSet, bool filterByTileRequirementArea = true)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");
            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

            string oneYearCreatedTime = Stage_Category?.ToLower() == "closed" ?  DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd"): DateTime.Now.AddYears(-1).ToString("yyyy-MM-ddTHH:mm:ssK");
            string dateFilterName = Stage_Category?.ToLower() == "closed" ? "Closing_Date" : "Created_Time";

            var content = filterByTileRequirementArea
                          ? new StringContent($@"{{""select_query"":""select L2_Remarks,Tile_Category,Lead_Category,Design_Selection,Tile_Requirement_in_Area_Sq_Mtr,Closing_Date,Modified_time_crmMasters,Final_Tile_Requirement_in_Area_Sq_ft,Tile_Requirement_in_Area_Sq_ft,Stage,Amount,Deal_Name,PCH_Email_ID,Sales_Person_Email_ID,City,Zip_Code,Tiling_Date_Likely_Purchase_Date,Mobile,Dealer_Name,Created_Time,Recent_Stage_Update_Date_Time,Stage_Category,Assigned_CP_By_Agent from Deals where ((((Assigned_CP_By_Agent  = '{Assigned_CP_By_Agent}')  and (Stage_Category = '{Stage_Category}')) and ((Tile_Requirement_in_Area_Sq_Mtr >= 500 and '{dateFilterName}' >= '{oneYearCreatedTime}') or (Tile_Requirement_in_Area_Sq_Mtr < 500 and '{dateFilterName}' >= '{Created_Time}'))) and (Tile_Requirement_in_Area_Sq_ft between '{MinRequirement}' and '{MaxRequirement}')) ORDER BY Tile_Requirement_in_Area_Sq_ft DESC limit {limit} offset {offSet}""}}", null, "application/json")
                          : new StringContent($@"{{""select_query"":""select L2_Remarks,Tile_Category,Lead_Category,Design_Selection,Tile_Requirement_in_Area_Sq_Mtr,Closing_Date,Modified_time_crmMasters,Final_Tile_Requirement_in_Area_Sq_ft,Tile_Requirement_in_Area_Sq_ft,Stage,Amount,Deal_Name,PCH_Email_ID,Sales_Person_Email_ID,City,Zip_Code,Tiling_Date_Likely_Purchase_Date,Mobile,Dealer_Name,Created_Time,Recent_Stage_Update_Date_Time,Stage_Category,Assigned_CP_By_Agent from Deals where ((((Assigned_CP_By_Agent  = '{Assigned_CP_By_Agent}')  and (Stage_Category = '{Stage_Category}')) and ((Tile_Requirement_in_Area_Sq_Mtr >= 500 and '{dateFilterName}' >= '{oneYearCreatedTime}') or (Tile_Requirement_in_Area_Sq_Mtr < 500 and '{dateFilterName}' >= '{Created_Time}'))) and (Tile_Requirement_in_Area_Sq_ft between '{MinRequirement}' and '{MaxRequirement}')) ORDER BY Modified_time_crmMasters DESC limit {limit} offset {offSet}""}}", null, "application/json");

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
            var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            var oneYearBefore = DateTime.Today.AddYears(-1).ToString("yyyy-MM-dd");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            //var content = new StringContent($@"{{""select_query"":""select Stage,Amount,Closing_Date,Final_Tile_Requirement_in_Area_Sq_ft,Tile_Requirement_in_Area_Sq_ft from Deals where ((((Assigned_CP_By_Agent = '{Assigned_CP_By_Agent}' and Stage ='Closed Won') and (Closing_Date is not null)) and (Amount is not null)) and (Closing_Date between '{Start_Date}' and '{End_Date}')) limit 200 offset {offSet}""}}", null, "application/json");
            var content = new StringContent($@"{{""select_query"":""select Stage, Amount, Closing_Date,Tile_Requirement_in_Area_Sq_Mtr, Final_Tile_Requirement_in_Area_Sq_ft from Deals where ((((Assigned_CP_By_Agent = '{Assigned_CP_By_Agent}' and Stage = 'Closed Won') and ((Tile_Requirement_in_Area_Sq_Mtr >= 500 and Closing_Date between '{oneYearBefore}' and '{currentDate}') or (Tile_Requirement_in_Area_Sq_Mtr < 500 and Closing_Date between '{Start_Date}' and '{End_Date}'))) and (Closing_Date is not null)) and (Amount is not null))  limit 200 offset {offSet}""}}", null, "application/json");
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
            var closingDateOneYearBefore = DateTime.Today.AddYears(-1).ToString("yyyy-MM-dd");
            var createdTimeThresholdOneYearBefore = DateTime.Today.AddYears(-1).ToString("yyyy-MM-ddTHH:mm:ssK");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            //var content = new StringContent($@"{{""select_query"":""select Stage, COUNT(id) as Total_Count, SUM(Amount) as Total_Amount, SUM(Tile_Requirement_in_Area_Sq_ft) as Tile_Total, SUM(Final_Tile_Requirement_in_Area_Sq_ft) as Final_Tile_Total from Deals where (((Stage = 'Closed Won' and Closing_Date >='{closingDate}') or (Stage in ('Qualification', 'Junk Lead', 'Closed Lost', 'Not Contactable - 4', 'Spoken to Customer', 'Quotation Shared', 'Scheduled a visit', 'Visited Store', 'Samples shared') and Created_Time >= '{createdTimeThreshold}')) and (Assigned_CP_By_Agent = '{Assigned_CP_By_Agent}')) group by Stage limit 200 offset {offSet}""}}", null, "application/json");
            var content = new StringContent($@"{{""select_query"":""SELECT Stage, COUNT(id) AS Total_Count, SUM(Amount) AS Total_Amount, SUM(Tile_Requirement_in_Area_Sq_ft) AS Tile_Total, SUM(Final_Tile_Requirement_in_Area_Sq_ft) AS Final_Tile_Total FROM Deals WHERE Assigned_CP_By_Agent = '{Assigned_CP_By_Agent}' AND ((Stage = 'Closed Won' AND ((Tile_Requirement_in_Area_Sq_Mtr >= 500 AND Closing_Date >= '{closingDateOneYearBefore}') OR (Tile_Requirement_in_Area_Sq_Mtr < 500 AND Closing_Date >= '{closingDate}'))) OR (Stage in ('Qualification', 'Junk Lead', 'Closed Lost', 'Not Contactable - 4', 'Spoken to Customer', 'Quotation Shared', 'Scheduled a visit', 'Visited Store', 'Samples shared') AND ((Tile_Requirement_in_Area_Sq_Mtr >= 500 AND Created_Time >= '{createdTimeThresholdOneYearBefore}') OR (Tile_Requirement_in_Area_Sq_Mtr < 500 AND Created_Time >= '{createdTimeThreshold}')))) GROUP BY Stage LIMIT 200 OFFSET {offSet}""}}", null, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SummaryCountResponse>(result);
        }


        private async Task<SearchApiResponse> ConnectSearchApiAsync(string accessToken, string Deal_Name, string City, string Assigned_CP, string Stage_Category, int offSet)
        {
            if (!Deal_Name.IsNullOrEmpty())
            {
                Deal_Name = Deal_Name + "%";
            }
            if (!City.IsNullOrEmpty())
            {
                City = City + "%";
            }
            StringContent content;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

            content = new StringContent("{\"select_query\": \"select Closing_Date,Final_Tile_Requirement_in_Area_Sq_ft,Tile_Requirement_in_Area_Sq_ft,Stage,Amount,Deal_Name,PCH_Email_ID,Sales_Person_Email_ID,City,Zip_Code,Tiling_Date_Likely_Purchase_Date,Mobile,Dealer_Name,Created_Time,Recent_Stage_Update_Date_Time,Stage_Category,Assigned_CP_Name from Deals where (((Deal_Name like '"+Deal_Name+"' or City like '"+City+"') and (Assigned_CP_By_Agent = '"+Assigned_CP+"')) and (Stage_Category = '"+Stage_Category+"')) ORDER BY Tile_Requirement_in_Area_Sq_ft DESC limit 200 offset "+offSet+"\"}");

            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SearchApiResponse>(result);
        }

        public async Task<BaseResponse> SearchApiAsync(string accessToken, string Deal_Name, string City, string Assigned_CP, string Stage_Category)
        {
            var response = new SearchApiResponse();
            int offSet = 0;

            while (true)
            {
                var dd = await ConnectSearchApiAsync(accessToken, Deal_Name, City, Assigned_CP, Stage_Category, offSet);
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

            response.info = new InfoSearch
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };
        }

        private async Task<CpConfirmListResponse> ConfirmAsync(string accessToken, string Assigned_CP_By_Agent, string Closing_Date, int offSet)
        {
            StringContent content;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");
            //var createdTimeThreshold = DateTime.Now.AddDays(-275).ToString("yyyy-MM-ddTHH:mm:ssK");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

            content = new StringContent("{\"select_query\": \"select Assigned_CP_Name,Amount,Closing_Date,Deal_Name,CP_Confirmed_the_Sale,Sales_Person_Name,Volume_In_Sq_Mtr from Deals where (((Assigned_CP_By_Agent = '" + Assigned_CP_By_Agent+"' and Stage = 'Closed Won') and (Closing_Date >= '"+Closing_Date+"')) and (Closed_By_FLS_CP = 'FLS')) ORDER BY Closing_Date DESC limit 200 offset "+offSet+"\"}");

            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CpConfirmListResponse>(result);
        }

        public async Task<BaseResponse> CpConfirmationListAsync(string accessToken, string Assigned_CP_By_Agent, string Closing_Date)
        {
            var response = new CpConfirmListResponse();
            int offSet = 0;

            while (true)
            {
                var dd = await ConfirmAsync(accessToken, Assigned_CP_By_Agent,Closing_Date, offSet);
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

            response.info = new InfoCpList
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };
        }



        public async Task<BaseResponse> GenerateRefreshTokenForFileUpload()
        {
            var request = "https://accounts.zoho.com/oauth/v2/token";

            var client = new HttpClient();
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("refresh_token", "1000.c79d9997d08b87230f3b9a91c6510444.4e6c1d8df1408160db59759a41e2aaaa");
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


        public async Task<BaseResponse> UploadFile(string accessToken, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            using var fileStream = file.OpenReadStream();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v2/files");
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

            var client = new HttpClient();

            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(fileStream), "file", file.FileName);
            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<FileUploadResponse>(responseContent);
            return new BaseResponse
            {
                Response = result
            };
        }
    }
}
