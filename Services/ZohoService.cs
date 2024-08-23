using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OBL_Zoho.Models;
using OBL_Zoho.Models.Helper;
using OBL_Zoho.Models.Response;
using OBL_Zoho.Services.Interfaces;
using System.Dynamic;
using System.Net.Http.Headers;

namespace OBL_Zoho.Services
{
    public class ZohoService : IZohoService
    {
        private readonly IAppSettingsService _appSettingsService;
        private readonly OblZohoContext _context;

        public ZohoService(IAppSettingsService appSettingsService, OblZohoContext context)
        {
            _appSettingsService = appSettingsService;
            _context = context;
        }

        public async Task<BaseResponse> GenerateAccessToken()
        {
            var refreshToken = _appSettingsService.GetRefreshToken();
            var clientId = _appSettingsService.GetClientId();
            var clientSecret = _appSettingsService.GetClientSecret();

            var request = "https://accounts.zoho.com/oauth/v2/token";

            var client = new HttpClient();
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("refresh_token", refreshToken);
            pairs.Add("client_id", clientId);
            pairs.Add("client_secret", clientSecret);
            pairs.Add("grant_type", "refresh_token");

            var content = new FormUrlEncodedContent(pairs);
            var response = client.PostAsync(request, content).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<AccessTokenResponse>(result);
            await GetAllEmployeeData();
            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> GetRecords(string accessToken, string pageNumber, string perPageRecord)
        {
            /*
            Old data fiiels
            var request = "https://www.zohoapis.com/crm/v4/Deals?fields=Id,Deal_Name,First_Name,Last_Name,Email,Mobile,City,Pincode,Lead_Type,Tile_Category,L_2_Qualified,Lead_Qualification_Date_Time,Current_Lead_Status,Tiling_Date,Status_last_modified,L2_Owner,L2_Remarks,address_line_1,address_line_2,appointment_date,lead_status,converted_amount,pin_code,vitrified_area,purchased_on,notes_list,notes_text,notes_written_by,notes_writer_designation,note_date,lead_from_source,last_updated,lead_quallified_date,amount&sort_by=Created_Time&sort_order=desc&page=" + pageNumber;
            */

            var request = "https://www.zohoapis.com/crm/v4/Deals?fields=Id,Last_Name,City,Zip_Code,Lead_Category,Tile_Category,Tiling_Date_Likely_Purchase_Date,Mobile,L2_Owner,Lead_Created_Time,PCH_Email_Id,PCH,Sales_Person,Tile_Requirement_in_Area_Sq_ft,Sales_Person_Employee_code,Lead_Type,Dealer_Type,Deal_Name,L2_Status,L1_Team_Remarks,Layout,L1_user_Name,Lead_Status,CP_Name,Stage,Amount,Owner,Modified_By,Created_By,Type,L2_Remarks,Design_Selection,Dealer_Code,Dealer_Name,Schedule_Store_Visit_Date,L2_Date_of_Visit_Planned_Visited,OBL_Exec_Amount,OBL_Exec_FLS_change_status_Remarks,OBL_Exec_FLS_lost_lead_Remarks,Sales_Person_Notes&sort_by=Created_Time&sort_order=desc&per_page=" + perPageRecord + "&page=" + pageNumber;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.GetAsync(request).Result;
            var result = await response.Content.ReadAsStringAsync();
            LeadResponse userResponse = JsonConvert.DeserializeObject<LeadResponse>(result);
            List<LeadData> filteredUserResponse = new List<LeadData>();
            userResponse.data.ForEach(x =>
            {
                if (x.Layout.id == "3765105000000091023")
                {
                    filteredUserResponse.Add(x);

                }
            });

            userResponse.data = filteredUserResponse;

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> GetRecordsById(string accessToken, string id)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/" + id + "?fields=Id,Last_Name,City,Zip_Code,Lead_Category,Tile_Category,Tiling_Date_Likely_Purchase_Date,Mobile,L2_Owner,Lead_Created_Time,PCH_Email_Id,PCH,Sales_Person,Tile_Requirement_in_Area_Sq_ft,Sales_Person_Employee_code,Lead_Type,Dealer_Type,Deal_Name,L2_Status,L1_Team_Remarks,Layout,L1_user_Name,Lead_Status,CP_Name,Stage,Amount,Owner,Modified_By,Created_By,Type,L2_Remarks,Design_Selection,Dealer_Code,Dealer_Name,Schedule_Store_Visit_Date,L2_Date_of_Visit_Planned_Visited,OBL_Exec_Amount,OBL_Exec_FLS_change_status_Remarks,OBL_Exec_FLS_lost_lead_Remarks";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.GetAsync(request).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<LeadResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> GetRecordsById_Extra(string accessToken, string id)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/" + id + "?fields=Id,Attachment,Dealer_Name,Amount,Purchase_Date,Closing_Date,Dealer_Type,Lead_Response_Medium_Whatsapp_Email_B2B_L2_Calli,Sales_Person_Status,Sales_Person_Customer_Remarks,Remarks_of_quotation_shared,Remarks_of_visit_store,Remarks_of_Sample_shared,Remarks_spoken_to_customer,Remarks";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.GetAsync(request).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<LeadResponseExtra>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> SearchRecordsByName(string accessToken, string name)
        {
            var request = "https://www.zohoapis.com/crm/v2/Deals/search?criteria=(Sales_Person:equals:" + name + ")";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.GetAsync(request).Result;
            var result = await response.Content.ReadAsStringAsync();
            LeadResponse userResponse = JsonConvert.DeserializeObject<LeadResponse>(result);
            List<LeadData> filteredUserResponse = new List<LeadData>();
            userResponse.data.ForEach(x =>
            {
                if (x.Layout.id == "3765105000000091023")
                {
                    filteredUserResponse.Add(x);
                }
            });

            userResponse.data = filteredUserResponse;

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> Update(string accessToken, LeadData obj)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/upsert";

            var layout = new layout();
            layout.id = obj.Layout.id;
            layout.name = obj.Layout.name;

            var l1UserName = new l1UserName();
            l1UserName.id = obj.L1_user_Name.id;
            l1UserName.name = obj.L1_user_Name.name;

            var owner = new owner();
            owner.id = obj.Owner.id;
            owner.name = obj.Owner.name;
            owner.email = obj.Owner.email;

            var createdBy = new createdBy();
            createdBy.id = obj.Created_By.id;
            createdBy.name = obj.Created_By.name;
            createdBy.email = obj.Created_By.email;

            var modifiedBy = new modifiedBy();
            modifiedBy.id = obj.Modified_By.id;
            modifiedBy.name = obj.Modified_By.name;
            modifiedBy.email = obj.Modified_By.email;

            var data = new UpdateData();
            data.Id = obj.Id;
            data.Deal_Name = obj.Deal_Name;
            data.City = obj.City;
            data.Zip_Code = obj.Zip_Code;
            data.Lead_Category = obj.Lead_Category;
            data.Tile_Category = obj.Tile_Category;
            data.L2_Owner = obj.L2_Owner;
            data.Sales_Person = obj.Sales_Person;
            data.Tile_Requirement_in_Area_Sq_ft = obj.Tile_Requirement_in_Area_Sq_ft;
            data.Last_Name = obj.Last_Name;
            data.Mobile = obj.Mobile;
            data.Lead_Created_Time = obj.Lead_Created_Time;
            data.PCH_Email_Id = obj.PCH_Email_Id;
            data.PCH = obj.PCH;
            data.Sales_Person_Employee_code = obj.Sales_Person_Employee_code;
            data.Lead_Type = obj.Lead_Type;
            data.Dealer_Type = obj.Dealer_Type;
            data.L2_Status = obj.L2_Status;
            data.L1_Team_Remarks = obj.L1_Team_Remarks;
            data.Layout = layout;
            data.L1_user_Name = l1UserName;
            data.Lead_Status = obj.Lead_Status;
            data.CP_Name = obj.CP_Name;
            data.Stage = obj.Stage;
            data.Amount = obj.Amount;
            data.Created_By = createdBy;
            data.Modified_By = modifiedBy;
            data.Owner = owner;
            data.Design_Selection = obj.Design_Selection;

            data.Dealer_Code = obj.Dealer_Code;
            data.Dealers_Code = obj.Dealer_Code;
            data.Dealer_Name = obj.Dealer_Name;
            data.Schedule_Store_Visit_Date = obj.Schedule_Store_Visit_Date;
            data.L2_Date_of_Visit_Planned_Visited = obj.L2_Date_of_Visit_Planned_Visited;
            data.OBL_Exec_Amount = obj.OBL_Exec_Amount == "null" ? null : obj.OBL_Exec_Amount;
            data.OBL_Exec_FLS_change_status_Remarks = obj.OBL_Exec_FLS_change_status_Remarks;
            data.OBL_Exec_FLS_lost_lead_Remarks = obj.OBL_Exec_FLS_lost_lead_Remarks;
            data.Sales_Person_Notes = obj.Sales_Person_Notes.Select(note => new Sales_Person_Notes
            {
                Modifier_Name = note.Modifier_Name,
                Modified_Time = note.Modified_Time,
                Modified_By_Emp_ID = note.Modified_By_Emp_ID,
                Notes_Created_Time = note.Notes_Created_Time,
                Layout = new Layout
                {
                    name = note.Layout.name,
                    id = note.Layout.id
                },
                in_merge = note.in_merge,
                field_states = note.field_states,
                Created_Time = note.Created_Time,
                parent_Id = new Parent_Id
                {
                    name = note.parent_Id.name,
                    id = note.parent_Id.id
                },
                Id = note.Id,
                zia_visions = note.zia_visions,
                FLS_Notes = note.FLS_Notes
            }).ToList();

            var xx = new List<UpdateData>();
            xx.Add(data);

            var ddd = new LeadUpdateRequest();
            ddd.data = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PostAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<LeadUpdateResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> GetBlueprint(string accessToken, string id)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/" + id + "/actions/blueprint";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.GetAsync(request).Result;
            var result = await response.Content.ReadAsStringAsync();
            BlueprintResponse userResponse = JsonConvert.DeserializeObject<BlueprintResponse>(result);

            var transList = new List<TransitionList>();
            userResponse.blueprint.transitions.ForEach(transition =>
            {
                var trans = new TransitionList();
                trans.name = transition.name;
                trans.id = transition.id;
                transList.Add(trans);
            });

            return new BaseResponse
            {
                Response = transList,
            };
        }

        public async Task<BaseResponse> UpdateBlueprint_ClosedWon(string accessToken, string id, BlueprintUpdateRequest_ClosedWon bur)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/" + id + "/actions/blueprint";

            var bdu = new BlueprintDataUpdate_ClosedWon();
            bdu.Attachments = new List<Attachment> { new Attachment { file_id = new List<string> { "ltzse100cc79c84934a77883d3e892b41af8f" }, link_url = "www.zoho.com" } };
            bdu.Amount = bur.blueprint[0].data.Amount;
            bdu.Dealer_Name = bur.blueprint[0].data.Dealer_Name;
            bdu.Purchase_Date = bur.blueprint[0].data.Purchase_Date;
            bdu.Closing_Date = bur.blueprint[0].data.Closing_Date;
            bdu.Lead_Response_Medium_Whatsapp_Email_B2B_L2_Calli = bur.blueprint[0].data.Lead_Response_Medium_Whatsapp_Email_B2B_L2_Calli;
            bdu.Dealer_Type = bur.blueprint[0].data.Dealer_Type;
            bdu.Notes = bur.blueprint[0].data.Notes;

            var bu = new BlueprintUpdate_ClosedWon();
            bu.transition_id = bur.blueprint[0].transition_id;
            bu.data = bdu;

            var xx = new List<BlueprintUpdate_ClosedWon>();
            xx.Add(bu);

            var ddd = new BlueprintUpdateRequest_ClosedWon();
            ddd.blueprint = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PutAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<BlueprintUpdateResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> UpdateBlueprint_ClosedLost(string accessToken, string id, BlueprintUpdateRequest_ClosedLost bur)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/" + id + "/actions/blueprint";

            var bdu = new BlueprintDataUpdate_ClosedLost();
            bdu.Sales_Person_Status = bur.blueprint[0].data.Sales_Person_Status;
            bdu.Sales_Person_Customer_Remarks = bur.blueprint[0].data.Sales_Person_Customer_Remarks;
            bdu.Closing_Date = bur.blueprint[0].data.Closing_Date;
            bdu.Notes = bur.blueprint[0].data.Notes;

            var bu = new BlueprintUpdate_ClosedLost();
            bu.transition_id = bur.blueprint[0].transition_id;
            bu.data = bdu;

            var xx = new List<BlueprintUpdate_ClosedLost>();
            xx.Add(bu);

            var ddd = new BlueprintUpdateRequest_ClosedLost();
            ddd.blueprint = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PutAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<BlueprintUpdateResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> UpdateBlueprint_QuotationShared(string accessToken, string id, BlueprintUpdateRequest_QuotationShared bur)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/" + id + "/actions/blueprint";

            var bdu = new BlueprintDataUpdate_QuotationShared();
            bdu.Remarks_of_quotation_shared = bur.blueprint[0].data.Remarks_of_quotation_shared;
            bdu.Notes = bur.blueprint[0].data.Notes;

            var bu = new BlueprintUpdate_QuotationShared();
            bu.transition_id = bur.blueprint[0].transition_id;
            bu.data = bdu;

            var xx = new List<BlueprintUpdate_QuotationShared>();
            xx.Add(bu);

            var ddd = new BlueprintUpdateRequest_QuotationShared();
            ddd.blueprint = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PutAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<BlueprintUpdateResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> UpdateBlueprint_SampleShared(string accessToken, string id, BlueprintUpdateRequest_SampleShared bur)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/" + id + "/actions/blueprint";

            var bdu = new BlueprintDataUpdate_SampleShared();
            bdu.Remarks_of_Sample_shared = bur.blueprint[0].data.Remarks_of_Sample_shared;
            bdu.Notes = bur.blueprint[0].data.Notes;

            var bu = new BlueprintUpdate_SampleShared();
            bu.transition_id = bur.blueprint[0].transition_id;
            bu.data = bdu;

            var xx = new List<BlueprintUpdate_SampleShared>();
            xx.Add(bu);

            var ddd = new BlueprintUpdateRequest_SampleShared();
            ddd.blueprint = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PutAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<BlueprintUpdateResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> UpdateBlueprint_VisitedStore(string accessToken, string id, BlueprintUpdateRequest_VisitedStore bur)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/" + id + "/actions/blueprint";

            var bdu = new BlueprintDataUpdate_VisitedStore();
            bdu.Remarks_spoken_to_customer = bur.blueprint[0].data.Remarks_spoken_to_customer;
            bdu.Notes = bur.blueprint[0].data.Notes;

            var bu = new BlueprintUpdate_VisitedStore();
            bu.transition_id = bur.blueprint[0].transition_id;
            bu.data = bdu;

            var xx = new List<BlueprintUpdate_VisitedStore>();
            xx.Add(bu);

            var ddd = new BlueprintUpdateRequest_VisitedStore();
            ddd.blueprint = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PutAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<BlueprintUpdateResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> UpdateBlueprint_SalesPersonPitch(string accessToken, string id, BlueprintUpdateRequest_SalesPersonPitch bur)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/" + id + "/actions/blueprint";

            var bdu = new BlueprintDataUpdate_VisitedStore();
            bdu.Notes = bur.blueprint[0].data.Notes;
            bdu.Remarks_spoken_to_customer = bur.blueprint[0].data.Notes;
            var bu = new BlueprintUpdate_VisitedStore();
            bu.transition_id = bur.blueprint[0].transition_id;
            bu.data = bdu;

            var xx = new List<BlueprintUpdate_VisitedStore>();
            xx.Add(bu);

            var ddd = new BlueprintUpdateRequest_VisitedStore();
            ddd.blueprint = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PutAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<BlueprintUpdateResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> UpdateBlueprint_ScheduleVisit(string accessToken, string id, BlueprintUpdateRequest_ScheduleVisit bur)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/" + id + "/actions/blueprint";

            var bdu = new BlueprintDataUpdate_VisitedStore();
            bdu.Notes = bur.blueprint[0].data.Notes;

            var bu = new BlueprintUpdate_VisitedStore();
            bu.transition_id = bur.blueprint[0].transition_id;
            bu.data = bdu;

            var xx = new List<BlueprintUpdate_VisitedStore>();
            xx.Add(bu);

            var ddd = new BlueprintUpdateRequest_VisitedStore();
            ddd.blueprint = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PutAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<BlueprintUpdateResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> GetJunkNonContactbleLead()
        {
            var userResponse = await _context.Obls.ToListAsync();
            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> AddJunkNonContactbleLead(Obl obl)
        {
            _context.Obls.Add(obl);
            await _context.SaveChangesAsync();
            return new BaseResponse
            {
                Response = "added successfully",
            };
        }

        public async Task<BaseResponse> GetJunkData(string userId)
        {
            var data = _context.Obls.Where(x => x.CreatedBy == userId).ToList();

            return new BaseResponse
            {
                Response = new JunkData
                {
                    Junk = data.Where(x => x.TypeId == 1).ToList(),//Junk
                    NonContact = data.Where(x => x.TypeId == 2).ToList()//Non Contactable 
                }
            };
        }
        public async Task<BaseResponse> GetRecordsWithEmail(string accessToken, string email)
        {
            /*
            Old data fiiels
            var request = "https://www.zohoapis.com/crm/v4/Deals?fields=Id,Deal_Name,First_Name,Last_Name,Email,Mobile,City,Pincode,Lead_Type,Tile_Category,L_2_Qualified,Lead_Qualification_Date_Time,Current_Lead_Status,Tiling_Date,Status_last_modified,L2_Owner,L2_Remarks,address_line_1,address_line_2,appointment_date,lead_status,converted_amount,pin_code,vitrified_area,purchased_on,notes_list,notes_text,notes_written_by,notes_writer_designation,note_date,lead_from_source,last_updated,lead_quallified_date,amount&sort_by=Created_Time&sort_order=desc&page=" + pageNumber;
            */

            //var request = "https://www.zohoapis.com/crm/v4/Deals?fields=Id,Last_Name,City,Closing_Date,Zip_Code,Lead_Category,Tile_Category,Tiling_Date_Likely_Purchase_Date,Mobile,L2_Owner,Lead_Created_Time,PCH_Email_Id,PCH,Sales_Person,Tile_Requirement_in_Area_Sq_ft,Sales_Person_Employee_code,Lead_Type,Dealer_Type,Deal_Name,L2_Status,L1_Team_Remarks,Layout,L1_user_Name,Lead_Status,CP_Name,Stage,Amount,Owner,Modified_By,Created_By,Type,L2_Remarks,Design_Selection,Dealer_Code,Dealer_Name,Schedule_Store_Visit_Date,L2_Date_of_Visit_Planned_Visited,Created_Time,OBL_Exec_Amount,OBL_Exec_FLS_change_status_Remarks,OBL_Exec_FLS_lost_lead_Remarks&sort_by=Created_Time&sort_order=desc&per_page=" + 200 + "&page=" + 1;

            var request = $"https://www.zohoapis.com/crm/v3/Deals/search?criteria=(Sales_Person_Email_ID:equals:{email})";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.GetAsync(request).Result;
            var result = await response.Content.ReadAsStringAsync();
            LeadResponse userResponse = JsonConvert.DeserializeObject<LeadResponse>(result);
            List<LeadData> filteredUserResponse = new List<LeadData>();
            userResponse.data.ForEach(x =>
            {
                if (x.Layout.id == "3765105000000091023")
                {
                    x.Lead_Created_Time = x.Created_Time;
                    var date = Convert.ToDateTime(x.Created_Time);
                    x.Created_Time_Sort = date;
                    filteredUserResponse.Add(x);

                }
            });

            userResponse.data = filteredUserResponse.OrderByDescending(x => x.Created_Time_Sort).ToList();

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> UpdateBlueprint_JunkLead(string accessToken, string id, BlueprintUpdateRequest_JunkLead bur)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/" + id + "/actions/blueprint";

            var bdu = new BlueprintUpdateRequest_JunkLead();



            var bu = new BlueprintUpdate_JunkLead();
            bu.transition_id = bur.blueprint[0].transition_id;
            bu.data = bur.blueprint[0].data;

            var xx = new List<BlueprintUpdate_JunkLead>();
            xx.Add(bu);

            var ddd = new BlueprintUpdateRequest_JunkLead();
            ddd.blueprint = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PutAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<BlueprintUpdateResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> UpdateBlueprint_NonContactableLead(string accessToken, string id, BlueprintUpdateRequest_NonContactableLead bur)
        {
            var request = "https://www.zohoapis.com/crm/v4/Deals/" + id + "/actions/blueprint";

            var bdu = new BlueprintUpdateRequest_NonContactableLead();



            var bu = new BlueprintUpdate_NonContactableLead();
            bu.transition_id = bur.blueprint[0].transition_id;

            var xx = new List<BlueprintUpdate_NonContactableLead>();
            xx.Add(bu);

            var ddd = new BlueprintUpdateRequest_NonContactableLead();
            ddd.blueprint = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PutAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<BlueprintUpdateResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> GetRecordsWithEms(string accessToken, string pchEmailId, bool isEmployee = false)
        {
            //var layout = "(Layout:equals:Standard)AND";
            //var url = GetSearchUrl(zhCode, bmCode, zmCode, salesPersonEmpID);


            var isMoreRecords = true;
            var response = new SearchData();
            var pageNumber = 1;
            while (isMoreRecords)
            {
                var dd = await GetDataByEmployee(accessToken, pchEmailId, pageNumber, isEmployee);
                response.data.AddRange(dd.data);
                if (dd.info.more_records != null && dd.info.more_records.Value)
                {
                    pageNumber++;
                }
                else
                {
                    isMoreRecords = false;
                }
            }

            return new BaseResponse { Response = response };

        }

        private static async Task<SearchData> GetDataByEmployee(string accessToken, string pchEmailId, int pageNumber, bool isEmployee = false)
        {
            var request = string.Empty;

            if (isEmployee)
            {
                request = $"https://www.zohoapis.com/crm/v6/Deals/search?criteria=((Layout:equals:Standard)and(Sales_Person_Email_ID:equals:{pchEmailId}))&page={pageNumber} ";
            }
            else
            {
                request = $"https://www.zohoapis.com/crm/v6/Deals/search?criteria=((Layout:equals:Standard)and(PCH_Email_ID:equals:{pchEmailId}))&page={pageNumber}";

            }
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.GetAsync(request).Result;
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SearchData>(result);

        }

        public async Task<BaseResponse> GetSalesEmployeeData(string accessToken, string salesPersonEmpID)
        {
            var request = $"https://www.zohoapis.com/crm/v6/coql";
            //var body = new object{ "select_query"= "select ZH_Code,ZH_Name,ZH_Email_ID,ZM_Code,ZM_Name,ZM_Mail_ID,BH_Emp_ID,BH_Name,BH_mail_ID from Dealer where Sales_Person_Email = '<Sales Email Id>' limit 200 offset 0"};

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.GetAsync(request).Result;
            var result = await response.Content.ReadAsStringAsync();


            return new BaseResponse
            {
                Response = JsonConvert.DeserializeObject<SearchData>(result),
            };
        }

        public async Task<BaseResponse> GetZonalManagerData(string code)
        {
            var token = await GenerateRefreshToken();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", token.Response.access_token);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {token.Response.access_token}");
            var content = new StringContent("{\r\n    \"select_query\": \"select ZM_Code,ZM_Name,ZM_Mail_ID from Dealer where ZH_Code = " + code + " limit 200 offset 0\"\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return new BaseResponse
            {
                Response = JsonConvert.DeserializeObject<ZMResponse>(result),
            };
        }
        public async Task<BaseResponse> GetBranchManagerData(string code)
        {
            var token = await GenerateRefreshToken();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", token.Response.access_token);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {token.Response.access_token}");
            var content = new StringContent("{\r\n    \"select_query\": \"select BH_Name,BH_Emp_ID,BH_mail_ID from Dealer where ZM_Code = " + code + " limit 200 offset 0\"\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return new BaseResponse
            {
                Response = JsonConvert.DeserializeObject<BMResponse>(result),
            };
        }

        public async Task<BaseResponse> GetSalesEmployeeData(string code)
        {
            var token = await GenerateRefreshToken();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", token.Response.access_token);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {token.Response.access_token}");
            var content = new StringContent("{\r\n    \"select_query\": \"select Name,Sales_Person_Name,Sales_Person_Email from Dealer where BH_Emp_ID = " + code + " limit 200 offset 0\"\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return new BaseResponse
            {
                Response = JsonConvert.DeserializeObject<SalesResponse>(result),
            };
        }

        public async Task<BaseResponse> GetSalesEmployeePersonalData(string emailId)
        {
            var token = await GenerateRefreshToken();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", token.Response.access_token);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {token.Response.access_token}");
            var content = new StringContent("{\"select_query\": \"select ZH_Code,ZH_Name,ZH_Email_ID,ZM_Code,ZM_Name,ZM_Mail_ID,BH_Emp_ID,BH_Name,BH_mail_ID from Dealer where Sales_Person_Email  = '" + emailId + "' limit 200 offset 0\"\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return new BaseResponse
            {
                Response = JsonConvert.DeserializeObject<SalesEmployeePersonalDataResponse>(result),
            };
        }

        public async Task<BaseResponse> GetDetailsByCode(string code)
        {
            var token = await GenerateRefreshToken();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", token.Response.access_token);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {token.Response.access_token}");
            var content = new StringContent("{\r\n    \"select_query\": \"select Sales_Person_Email from Dealer where Name='" + code + "' limit 200 offset 0\"\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return new BaseResponse
            {
                Response = JsonConvert.DeserializeObject<EmailResponse>(result),
            };
        }

        public string GetSearchUrl(string zhCode, string bmCode, string zmCode, string salesPersonEmpID)
        {
            string url = string.Empty;
            if (!string.IsNullOrEmpty(zhCode))
            {
                url += $"(ZH_Code:equals:{zhCode})";
            }
            if (!string.IsNullOrEmpty(bmCode))
            {
                if (!string.IsNullOrEmpty(url))
                {
                    url += "and";
                }
                url += $"(BM_Code:equals:{bmCode})";
            }
            if (!string.IsNullOrEmpty(zmCode))
            {
                if (!string.IsNullOrEmpty(url))
                {
                    url += "and";
                }
                url += $"(ZM_Code:equals:{zmCode})";
            }
            if (!string.IsNullOrEmpty(salesPersonEmpID))
            {
                if (!string.IsNullOrEmpty(url))
                {
                    url += "and";
                }
                url += $"(Sales_Person_Email_ID:equals:{salesPersonEmpID})";
            }
            return url;
        }

        public async Task<BaseResponse> GenerateRefreshToken()
        {
            var refreshToken = _appSettingsService.GetRefreshToken();
            var clientId = _appSettingsService.GetClientId();
            var clientSecret = _appSettingsService.GetClientSecret();

            var request = "https://accounts.zoho.com/oauth/v2/token";

            var client = new HttpClient();
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("refresh_token", "1000.409c5512889ce31ce505bf8d6573c66d.bb2e2916a1ba4129a4ce11ab536f1b62");
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

        public async Task<BaseResponse> GetDetailsByZMCode(string code)
        {
            var token = await GenerateRefreshToken();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", token.Response.access_token);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {token.Response.access_token}");
            var content = new StringContent("{\r\n    \"select_query\": \"select BH_Name,BH_Emp_ID,BH_mail_ID,Sales_Person_Email,Name,Sales_Person_Name from Dealer where ZM_Code= '" + code + "' limit 200 offset 0\"\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return new BaseResponse
            {
                Response = JsonConvert.DeserializeObject<DataByZMCodeResponse>(result),
            };
        }

        public async Task<BaseResponse> GetDataByZHCode(string accessToken, string pageNumber, string code)
        {
            ZHResponse zHResponse = new();
            var moreRecords = true;
            int page = 1;
            while (moreRecords)
            {
                var response = await GetDataByPage(accessToken, page, code);
                if (response.info.more_records.HasValue && !response.info.more_records.Value)
                {
                    moreRecords = false;
                }
                zHResponse.data.AddRange(response.data);
                page++;
            }

            return new BaseResponse
            {
                Response = zHResponse,
            };
        }


        public async Task<ZHResponse> GetDataByPage(string accessToken, int pageNumber, string code)
        {
            var date = DateTime.Now.AddDays(-90).ToString("yyyy-MM-dd");
            var employeeData = await GetAllEmployeeData();
            var request = "";
            if (employeeData != null && employeeData.Count > 0 && employeeData.Any(e => e.ZHCode == code))
            {
                request = $"https://www.zohoapis.com/crm/v6/Deals/search?criteria=((PCH_Email_ID:not_equal:null)and(ZH_Code:equals:{code}))&page={pageNumber}";
            }
            else
            {
                request = $"https://www.zohoapis.com/crm/v6/Deals/search?criteria=((PCH_Email_ID:not_equal:null)and(ZM_Code:equals:{code}))&page={pageNumber}";
            }


            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = await client.GetAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            ZHResponse zHResponse = JsonConvert.DeserializeObject<ZHResponse>(result);
            return zHResponse;
        }


        public async Task<List<AllEmployees>> GetAllEmployeeData()
        {
            var request = $"https://pmt.orientapps.com/api_user/";


            var client = new HttpClient();
            var response = await client.GetAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<List<AllEmployees>>(result);
            return employees;
        }

        public async Task<DataByCodeResponse> GetDataByCode(string code)
        {
            var data = await GetAllEmployeeData();
            if (data == null || data.Count == 0) return null;

            var result = new List<AllEmployees>();

            result = data.Where(e => e.ZHCode == code || e.ZMCode == code || e.BMCode == code).ToList();
            if (result == null || result.Count == 0) return null;

            //var zhIds = result.Select(x => x.ZHCode).ToList();
            //var zonalHeads = data.Where(x => zhIds.Contains(x.EmployeeID)).ToList();

            //var zmIds = result.Select(x => x.ZMCode).ToList();
            //var zonalManager = data.Where(x => zmIds.Contains(x.EmployeeID)).ToList();

            //var bmIds = result.Select(x => x.BMCode).ToList();
            //var branchManager = data.Where(x => bmIds.Contains(x.EmployeeID)).ToList();

            //var employees = data.Where(x => !zhIds.Contains(x.EmployeeID) && !zmIds.Contains(x.EmployeeID) && !bmIds.Contains(x.EmployeeID)).ToList();


            List<AllEmployees> zonalHeads;
            List<AllEmployees> zonalManagers;
            List<AllEmployees> branchManagers;
            List<AllEmployees> employees;
            var zhIds = new List<string>();
            var zmIds = new List<string>();
            var bmIds = new List<string>();
            if (result.Any(e => e.ZHCode == code))
            {
                zhIds = result.Where(e => e.ZHCode == code).Select(x => x.ZHCode).ToList();
                zonalHeads = data.Where(x => zhIds.Contains(x.EmployeeID)).ToList();

                zmIds = result.Where(e => zhIds.Contains(e.ZHCode)).Select(x => x.ZMCode).ToList();
                zonalManagers = data.Where(x => zmIds.Contains(x.EmployeeID)).ToList();

                bmIds = result.Where(e => zmIds.Contains(e.ZMCode)).Select(x => x.BMCode).ToList();
                branchManagers = data.Where(x => bmIds.Contains(x.EmployeeID)).ToList();
            }
            else if (result.Any(e => e.ZMCode == code))
            {
                zmIds = result.Where(e => e.ZMCode == code).Select(x => x.ZMCode).ToList();
                zonalManagers = data.Where(x => zmIds.Contains(x.EmployeeID)).ToList();

                zhIds = result.Where(e => zmIds.Contains(e.ZMCode)).Select(x => x.ZHCode).ToList();
                zonalHeads = data.Where(x => zhIds.Contains(x.EmployeeID)).ToList();
                bmIds = result.Where(e => zmIds.Contains(e.ZMCode)).Select(x => x.BMCode).ToList();
                branchManagers = data.Where(x => bmIds.Contains(x.EmployeeID)).ToList();
            }
            else
            {
                bmIds = result.Where(e => e.BMCode == code).Select(x => x.BMCode).ToList();
                branchManagers = data.Where(x => bmIds.Contains(x.EmployeeID)).ToList();

                zmIds = result.Where(e => bmIds.Contains(e.BMCode)).Select(x => x.ZMCode).ToList();
                zonalManagers = data.Where(x => zmIds.Contains(x.EmployeeID)).ToList();

                zhIds = result.Where(e => zmIds.Contains(e.ZMCode)).Select(x => x.ZHCode).ToList();
                zonalHeads = data.Where(x => zhIds.Contains(x.EmployeeID)).ToList();
            }

            employees = data.Where(x => zhIds.Contains(x.ZHCode)
                                        && zmIds.Contains(x.ZMCode)
                                        && bmIds.Contains(x.BMCode)).ToList();

            return new DataByCodeResponse
            {
                ZH = zonalHeads,
                ZM = zonalManagers,
                BM = branchManagers,
                Employees = employees
            };
        }

        public async Task<BaseResponse> GetUserByCode(string code)
        {
            var data = await GetAllEmployeeData();
            if (data == null || data.Count == 0) return null;

            var result = data.Where(e => e.ZHCode == code || e.ZMCode == code).ToList();
            if (result == null || result.Count == 0) return null;

            var user = data.Any(e => e.ZHCode == code) ? 7 : (data.Any(e => e.ZMCode == code) ? 6 : 0);

            return new BaseResponse
            {
                Response = user,
            };
        }

        public async Task<BaseResponse> UpdateSalesPersonNotesAsync(string accessToken, UpdateSalesPersonNotes obj)
        {
            var request = "https://www.zohoapis.com/crm/v6/Deals";

            var data = new SalesPersonNotesUpdate()
            {
                Sales_Person_Notes = obj.Sales_Person_Notes.Select(note => new Sales_Person_Notes
                {
                    Modifier_Name = note.Modifier_Name,
                    Modified_By_Emp_ID = note.Modified_By_Emp_ID,
                    Notes_Created_Time = note.Notes_Created_Time,
                    parent_Id = new Parent_Id
                    {
                        name = note.parent_Id.name,
                        id = note.parent_Id.id
                    },
                    FLS_Notes = note.FLS_Notes,
                }).ToList(),
                id = obj.id
            };

            var xx = new List<SalesPersonNotesUpdate>();
            xx.Add(data);

            var ddd = new UpdateSalesPersonNotesRequest();
            ddd.data = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PutAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<UpdateSalesPersonNotesResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };

        }

        public async Task<BaseResponse> GetSalesPersonNotesAsync(string accessToken, string id)
        {

            var stageHostoryRequest = $"https://www.zohoapis.com/crm/v6/Deals/{id}/Stage_History?fields=Stage,Close_Date,Modified_Time,Modified_By";

            var searchDataRequest = "https://www.zohoapis.com/crm/v6/Deals/" + id;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);

            //Fetch data from the first request
            var stageHistoryResponse = await client.GetAsync(stageHostoryRequest);
            stageHistoryResponse.EnsureSuccessStatusCode();
            var stageHistoryResult = await stageHistoryResponse.Content.ReadAsStringAsync();
            var stageHistoryResponses = JsonConvert.DeserializeObject<Root>(stageHistoryResult);

            // Fetch data from the second request
            var searchDataResponse = await client.GetAsync(searchDataRequest);
            searchDataResponse.EnsureSuccessStatusCode();
            var searchDataResult = await searchDataResponse.Content.ReadAsStringAsync();
            var searchDataResponses = JsonConvert.DeserializeObject<SearchData>(searchDataResult);

            //bind stageHistory Data into searchData
            searchDataResponses.data[0].Stage_History = stageHistoryResponses.data;


            return new BaseResponse
            {
                Response = searchDataResponses,
            };
        }

        private async Task<RootData> GetDataByEmployeeData(string accessToken, string pchEmailId, int offSet, bool isEmployee)
        {
            StringContent content;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");
            var createdTimeThreshold = DateTime.Now.AddDays(-275).ToString("yyyy-MM-ddTHH:mm:ssK");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");

            if (isEmployee)
            {
                content = new StringContent("{\"select_query\": \"select Closing_Date,Tile_Requirement_in_Area_Sq_ft,Stage,Amount,Deal_Name,PCH_Email_ID,Sales_Person_Email_ID,City,Zip_Code,Tiling_Date_Likely_Purchase_Date,Mobile,Dealer_Name,Created_Time from Deals where ((Sales_Person_Email_ID = '" + pchEmailId + "') and (Created_Time >= '" + createdTimeThreshold + "')) limit 200 offset " + offSet + "\"}");

            }
            else
            {
                content = new StringContent("{\"select_query\": \"select Closing_Date,Tile_Requirement_in_Area_Sq_ft,Stage,Amount,Deal_Name,PCH_Email_ID,Sales_Person_Email_ID,City,Zip_Code,Tiling_Date_Likely_Purchase_Date,Mobile,Dealer_Name,Created_Time from Deals where ((PCH_Email_ID = '" + pchEmailId + "') and (Created_Time >= '" + createdTimeThreshold + "')) limit 200 offset " + offSet + "\"}");

            }
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RootData>(result);

        }

        public async Task<BaseResponse> GetRecordsWithEmsData(string pchEmailId, bool isEmployee)
        {
            var response = new RootData();
            int offSet = 0;
            var token = await GenerateRefreshToken();

            while (true)
            {
                var dd = await GetDataByEmployeeData(token.Response.access_token, pchEmailId, offSet, isEmployee);
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

            response.info = new InfoData
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };
        }

        private async Task<RootData> GetDataByZhCodeData(string accessToken, string code, int offSet)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zohoapis.com/crm/v6/coql");
            var createdTimeThreshold = DateTime.Now.AddDays(-275).ToString("yyyy-MM-ddTHH:mm:ssK");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            request.Headers.Add("Authorization", $"Zoho-oauthtoken {accessToken}");
            var content = new StringContent("{\"select_query\": \"select Closing_Date,Tile_Requirement_in_Area_Sq_ft,Stage,Amount,Deal_Name,PCH_Email_ID,Sales_Person_Email_ID,City,Zip_Code,Tiling_Date_Likely_Purchase_Date,Mobile,Dealer_Name,Created_Time from Deals where ((ZH_Code = '" + code + "') and (Created_Time >= '" + createdTimeThreshold + "')) limit 200 offset " + offSet + "\"}");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RootData>(result);

        }

        public async Task<BaseResponse> GetDataByZHCodeData(string code)
        {

            var response = new RootData();
            int offSet = 0;
            var token = await GenerateRefreshToken();

            while (true)
            {
                var dd = await GetDataByZhCodeData(token.Response.access_token, code, offSet);
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

            response.info = new InfoData
            {
                count = response.data.Count,
                more_records = false
            };

            return new BaseResponse
            {
                Response = response
            };
        }

        public async Task<BaseResponse> AssignOwnerDeal(string accessToken, UpdateOwnerDealRequest obj)
        {
            var request = "https://www.zohoapis.com/crm/v6/Deals";


            var data = new UpdateOwnerDealRequest()
            {
                Sales_Person_Email_ID = obj.Sales_Person_Email_ID,
                Sales_Person_Emp_ID = obj.Sales_Person_Emp_ID,
                Sales_Person_Name = obj.Sales_Person_Name,
                Sales_Person_Phone = obj.Sales_Person_Phone,
                Branch_Area = obj.Branch_Area,
                id = obj.id
            };

            var xx = new List<UpdateOwnerDealRequest>();
            xx.Add(data);

            var ddd = new OwnerDealsRequest();
            ddd.data = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PutAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<OwnerDealResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };
        }

        public async Task<BaseResponse> GetLeadDetailsBYIdAsync(string accessToken, string id)
        {

            var stageHostoryRequest = $"https://www.zohoapis.com/crm/v6/Deals/{id}/Stage_History?fields=Stage,Close_Date,Modified_Time,Modified_By";

            var searchDataRequest = "https://www.zohoapis.com/crm/v6/Deals/" + id;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);

            //Fetch data from the first request
            var stageHistoryResponse = await client.GetAsync(stageHostoryRequest);
            stageHistoryResponse.EnsureSuccessStatusCode();
            var stageHistoryResult = await stageHistoryResponse.Content.ReadAsStringAsync();
            var stageHistoryResponses = JsonConvert.DeserializeObject<Root>(stageHistoryResult);

            // Fetch data from the second request
            var searchDataResponse = await client.GetAsync(searchDataRequest);
            searchDataResponse.EnsureSuccessStatusCode();
            var searchDataResult = await searchDataResponse.Content.ReadAsStringAsync();
            var searchDataResponses = JsonConvert.DeserializeObject<SalesPersonNotesResponse>(searchDataResult);

            //bind stageHistory Data into searchData
            searchDataResponses.data[0].Stage_History = stageHistoryResponses.data;


            return new BaseResponse
            {
                Response = searchDataResponses,
            };
        }

        public async Task<BaseResponse> SaveWonDataAsync(string accessToken, CategoryDetailsDatum obj)
        {
            var request = "https://www.zohoapis.com/crm/v6/Deals";

            var data = new CategoryDetailsDatum()
            {
                Category_Details_from_APP = obj.Category_Details_from_APP.Select(x => new CategoryDetailsResponse
                {
                    Category = x.Category,
                    Size = x.Size,
                    Parent_Id = new CategoryDetailsParentId
                    {
                        name = x.Parent_Id.name,
                        id = x.Parent_Id.id
                    },
                    Box = x.Box,
                    Entry_Date = x.Entry_Date,
                    Sq_Mt = x.Sq_Mt
                }).ToList(),
                id = obj.id,
                Total_Sq_Mt = obj.Total_Sq_Mt,
            };

            var xx = new List<CategoryDetailsDatum>();
            xx.Add(data);

            var ddd = new UpdateCategoryDetailsRequest();
            ddd.data = xx;

            var dd = JsonConvert.SerializeObject(ddd);
            var buffer = System.Text.Encoding.UTF8.GetBytes(dd);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);
            var response = client.PutAsync(request, byteContent).Result;
            var result = await response.Content.ReadAsStringAsync();
            dynamic userResponse = JsonConvert.DeserializeObject<UpdateSalesPersonNotesResponse>(result);

            return new BaseResponse
            {
                Response = userResponse,
            };

        }

        public async Task<BaseResponse> GetTileAreaAsync()
        {
            return new BaseResponse
            {
                Response = TileAreaData.Areas
            };
        }


        public async Task<ExcelResponse> GenerateExcelAsync(ExpandoObject person)
        {
            byte[] fileContent;
            // Create a new Excel workbook
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");

                // Add headers and data dynamically
                int column = 1;
                foreach (var kvp in person)
                {
                    // Add header (key as the header)
                    worksheet.Cell(1, column).Value = kvp.Key;

                    // Add value (corresponding value in the next row)
                    worksheet.Cell(2, column).Value = kvp.Value?.ToString() ?? string.Empty;

                    column++;
                }

                // Convert to byte array
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    // Return the file
                    fileContent = stream.ToArray();
                }
            }

            return new ExcelResponse
            {
                FileContent = fileContent,
                FileName = "person.xlsx", 
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" // Set the MIME type
            };
        }
    }
}

