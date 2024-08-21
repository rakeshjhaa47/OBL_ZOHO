using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
    public class SalesPersonNotesResponse
    {
        public List<SalesPersonDatum> data { get; set; }
    }
    public class SalesPersonApproval
    {
        public bool @delegate { get; set; }
        public bool approve { get; set; }
        public bool reject { get; set; }
        public bool resubmit { get; set; }
    }

    public class CategoryDetailsFromAPP
    {
        public DateTime? Modified_Time { get; set; }
        public string Category { get; set; }

        [JsonProperty("$field_states")]
        public object? field_states { get; set; }
        public DateTime? Created_Time { get; set; }
        public string Size { get; set; }
        public ParentId Parent_Id { get; set; }
        public int? Box { get; set; }
        public DateTime? Entry_Date { get; set; }
        public int? Sq_Mt { get; set; }
        public Layout Layout { get; set; }

        [JsonProperty("$in_merge")]
        public bool in_merge { get; set; }
        public string id { get; set; }

        [JsonProperty("$zia_visions")]
        public object? zia_visions { get; set; }
    }

    public class SalesPersonContactName
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class SalesPersonCreatedBy
    {
        public string name { get; set; }
        public string id { get; set; }
        public string email { get; set; }
    }

    public class SalesPersonDatum
    {
        public string? FLS_Follow_Up_Remarks_B2B { get; set; }
        public string? L2_Purchase_Value_if_purchased { get; set; }
        public SalesPersonOwner Owner { get; set; }
        public string? GCLID { get; set; }
        public string? L2_Owner { get; set; }

        [JsonProperty("$field_states")]
        public string? field_states { get; set; }
        public string? Remarks_of_Junk_Lead { get; set; }
        public DateTime? Recent_Stage_Update_Date_Time { get; set; }
        public string? OBL_Exec_Amount { get; set; }
        public object? Qualification_Date { get; set; }
        public object? L2_Call_Status { get; set; }
        public object? Enquiry_Remarks { get; set; }
        public object? File_Upload { get; set; }
        public object? Firm_Name { get; set; }

        [JsonProperty("$process_flow")]
        public bool? process_flow { get; set; }
        public string? Stage { get; set; }
        public object? KEYWORDID { get; set; }

        [JsonProperty("$approval")]
        public SalesPersonApproval approval { get; set; }
        public int? Cost_per_Click { get; set; }
        public object? gaconnectorfields1__Browser { get; set; }
        public object? Current_Lead_Status { get; set; }
        public object? PMT_Channel_Partner { get; set; }
        public object? Subtotal { get; set; }
        public string ZM_Code { get; set; }
        public object? gaconnectorfields1__Longitude { get; set; }
        public object? Interested_Lead_B2B_Date { get; set; }
        public object? State_Union_Territority { get; set; }
        public object? State_Code { get; set; }
        public object? Lead_Assignment_Physical_visit_remarks_B2B { get; set; }
        public object? Contact_Email { get; set; }
        public object? Lead_Response_Medium { get; set; }
        public object? Ad_Click_Date { get; set; }
        public string? Forecast_Category__s { get; set; }
        public object? gaconnectorfields1__First_Click_Source { get; set; }
        public object? PMT_Opp_Id { get; set; }
        public object? Area_in_City { get; set; }
        public object? Tile_Buying_Assistance_Required { get; set; }
        public object? Sqft_Price { get; set; }
        public object? gaconnectorfields1__Latitude { get; set; }
        public object? gaconnectorfields1__Time_Zone { get; set; }
        public object? Ad { get; set; }
        public object? Firm_Name_if_any { get; set; }
        public object? Meeting_Address { get; set; }
        public object? L1_Remarks { get; set; }
        public DateTime? Qualification_Stage_Change_Date { get; set; }
        public string Qualified_Type { get; set; }

        [JsonProperty("$review_process")]
        public SalesPersonReviewProcess review_process { get; set; }
        public object? Currently_Active_Business { get; set; }
        public string Modified_By_Custom { get; set; }
        public object? SKU_3_Name_B2B { get; set; }
        public string Sales_Person_Name { get; set; }
        public object? Existing_Business { get; set; }
        public object? Lead_Status { get; set; }
        public object? Sub_source { get; set; }
        public object? gaconnectorfields1__First_Click_Referrer { get; set; }
        public object? gaconnectorfields1__Last_Click_Medium { get; set; }
        public object? PMT_Lead_Id { get; set; }
        public object? L2_Purchase_Invoice_Date { get; set; }
        public object? ADID { get; set; }
        public object? SKU_3_Quantity_B2B { get; set; }
        public string Employee_Department { get; set; }
        public object? Final_Status_received_from_SP { get; set; }
        public object? SKU_1_Name_B2B { get; set; }
        public DateTime? Lead_Created_Time { get; set; }
        public List<CategoryDetailsFromAPP> Category_Details_from_APP { get; set; }
        public List<object?> SKUs_B2B { get; set; }
        public object? SKU_4_Price_B2B { get; set; }

        [JsonProperty("$orchestration")]
        public bool orchestration { get; set; }
        public SalesPersonContactName Contact_Name { get; set; }
        public object? gaconnectorfields1__Number_of_Website_Visits { get; set; }
        public Layout Layout { get; set; }
        public int Positive { get; set; }
        public object? gaconnectorfields1__IP_Address { get; set; }
        public int? Total_Sq_Mt { get; set; }
        public object? Sampling_From_HO_Store_Remarks_B2B { get; set; }
        public object? Lead_Source { get; set; }
        public object? Remarks_Not_picking_1 { get; set; }
        public object? Remarks_Not_picking_2 { get; set; }

        [JsonProperty("$pathfinder")]
        public bool pathfinder { get; set; }
        public object? Remarks_Not_picking_3 { get; set; }
        public object? SKU_1_Quantity_B2B { get; set; }
        public object? NP_3_Date { get; set; }
        public object? gaconnectorfields1__First_Click_Content { get; set; }

        [JsonProperty("$currency_symbol")]
        public string currency_symbol { get; set; }
        public object? Dealer_Recommended_Purchased { get; set; }
        public object? Purchase_Date { get; set; }
        public DateTime? Last_Activity_Time { get; set; }
        public object? BH_Name { get; set; }
        public int Negative { get; set; }
        public string Deal_Name { get; set; }
        public object? Remarks { get; set; }
        public List<object?> Reason_of_NPD_B2B { get; set; }
        public string Previous_Deal_Stage { get; set; }
        public string Zonal_Head { get; set; }
        public object? Remarks_of_quotation_shared { get; set; }
        public object? Zip_Code { get; set; }
        public object? Remarks_of_Sample_shared { get; set; }
        public object? SKU_2_size_B2B { get; set; }
        public object? Rate_the_assistance_of_OBL_customer_service_team { get; set; }
        public string Sales_Person_Email_ID { get; set; }
        public object? SKU_4_Name_B2B { get; set; }
        public object? Project_City { get; set; }
        public object? Previous_Status_B2B_Date { get; set; }
        public string Contact_Phone { get; set; }
        public object? NP_4_Date { get; set; }
        public object? Project_Type1 { get; set; }
        public List<SalesPersonNote> Sales_Person_Notes { get; set; }
        public object? PMT_Closure_Won_Date { get; set; }
        public object? BH_Email_ID { get; set; }
        public object? Not_picking_3 { get; set; }
        public object? Not_picking_2 { get; set; }
        public object? SKU_3_Price_B2B { get; set; }
        public object? PCH { get; set; }
        public object? State { get; set; }
        public bool Cx_Confirmed_Sale { get; set; }
        public object? ZCAMPAIGNID { get; set; }
        public object? Invoice_Sent_B2B_Date { get; set; }

        [JsonProperty("$zia_owner_assignment")]
        public object? zia_owner_assignment { get; set; }
        public object? Not_picking_1 { get; set; }
        public object? Remarks_Sqft_price { get; set; }
        public object? gaconnectorfields1__First_Click_Medium { get; set; }
        public object? OBL_Exec_FLS_lost_lead_Remarks { get; set; }
        public object? L2_First_Attempt_Date_Time1 { get; set; }
        public object? Not_Interested_Reason { get; set; }
        public object? Sales_Person_Remarks { get; set; }
        public object? Dealer_Type { get; set; }
        public object? NP_5_Date { get; set; }
        public object? Tiling_Date_Likely_Purchase_Date { get; set; }
        public string Closing_Date { get; set; }
        public int Cost_per_Conversion { get; set; }
        public SalesPersonModifiedBy Modified_By { get; set; }

        [JsonProperty("$review")]
        public object? review { get; set; }
        public object? SKU_2_Price_B2B { get; set; }
        public object? GADCONFIGID { get; set; }
        public string Store_Name { get; set; }
        public object? PCH_Mobile { get; set; }

        [JsonProperty("$zia_visions")]
        public object? zia_visions { get; set; }
        public object? Project_Pincode { get; set; }
        public object? Junk_Lead_Reason_Remarks_B2B { get; set; }
        public object? Zonal_Manager_Mail { get; set; }
        public DateTime? Modified_Time { get; set; }
        public DateTime? L1_First_Attempt_Date_Time { get; set; }
        public string Days_Difference { get; set; }
        public object? L2_Status { get; set; }
        public object? Device_Type { get; set; }
        public object? Requirement_for { get; set; }
        public object? SKU_4_Quantity_B2B { get; set; }
        public object? StateCode { get; set; }
        public object? Order_Information_B2B_Date { get; set; }
        public object? gaconnectorfields1__Last_Click_Source { get; set; }
        public object? Sales_Person_Customer_Remarks { get; set; }
        public object? Tile_Requirement_Remarks { get; set; }
        public object? Lead_Response_Received_By_Sales_Person { get; set; }
        public object? In_touch_with_someone_in_OBL { get; set; }
        public object? SP_Follow_Up { get; set; }
        public object? I_have_Showroom_Space { get; set; }

        [JsonProperty("$in_merge")]
        public bool in_merge { get; set; }
        public string L2_Agent_Number { get; set; }
        public List<object?> Offer_satisfactory_range_of_tile_design_and_style { get; set; }
        public object? L1_Qualified_Date { get; set; }
        public object? gaconnectorfields1__First_Click_Channel { get; set; }
        public object? L2_Remarks { get; set; }

        [JsonProperty("$approval_state")]
        public string approval_state { get; set; }
        public object? gaconnectorfields1__Last_Click_Term { get; set; }
        public object? PMT_Last_Modified { get; set; }
        public object? gaconnectorfields1__City_from_IP_address { get; set; }
        public object? Sampling_From_Store_B2B_Date { get; set; }
        public object? Lead_Response_Received_By { get; set; }
        public object? gaconnectorfields1__All_Traffic_Sources { get; set; }
        public object? Remarks_of_visit_store { get; set; }

        [JsonProperty("$sharing_permission")]
        public string sharing_permission { get; set; }
        public object? gaconnectorfields1__First_Click_Term { get; set; }
        public string Sales_Person_Phone { get; set; }
        public object? gaconnectorfields1__Time_Spent_on_Website { get; set; }
        public object? Junk_Lead_Date { get; set; }
        public object? Lead_Category { get; set; }
        public object? Ad_Network { get; set; }
        public object? CP_Name { get; set; }
        public string Stages_Date { get; set; }
        public object? OBL_Exec_FLS_change_status_Remarks { get; set; }
        public string id { get; set; }
        public object? SKU_2_Name_B2B { get; set; }
        public bool I_have_verified_that_all_SKU_are_Correct_B2B { get; set; }
        public object? Closed_Won_Date { get; set; }
        public object? SKU_5_size_B2B { get; set; }
        public object? Design_Selection_Remarks { get; set; }
        public object? gaconnectorfields1__GA_Client_ID { get; set; }
        public DateTime? Created_Time { get; set; }
        public object? Zonal_Head_Mail { get; set; }
        public DateTime? Change_Log_Time__s { get; set; }
        public bool Order_Confirmation_Email_Alert { get; set; }
        public object? Availability_of_Showroom_Space_in_Sqft { get; set; }
        public string Sales_Person { get; set; }
        public object? L2_Remark_Date { get; set; }
        public object? Shortlisted_Category { get; set; }
        public object? gaconnectorfields1__Last_Click_Referrer { get; set; }
        public SalesPersonCreatedBy Created_By { get; set; }
        public object? FLS_Quotation_Remarks_B2B { get; set; }
        public string Branch_Area { get; set; }
        public object? Total_SqFt_requirements { get; set; }
        public object? Campaign_Name { get; set; }
        public object? Search_Partner_Network { get; set; }
        public DateTime? Stage_Update_Date_Time { get; set; }
        public int Scoring { get; set; }
        public string Reason_of_Junk_Leads { get; set; }

        [JsonProperty("$canvas_id")]
        public object? canvas_id { get; set; }
        public object? Lead_Closing_Date { get; set; }
        public object? ADGROUPID { get; set; }
        public object? SKU_3_size_B2B { get; set; }
        public string Sales_Person_Emp_ID { get; set; }
        public int Lead_Conversion_Time { get; set; }
        public object? Mapped_Plant_Value { get; set; }
        public object? Lead_Type { get; set; }
        public string ZH_Code { get; set; }
        public int? Overall_Sales_Duration { get; set; }
        public object? gaconnectorfields1__Last_Click_Landing_Page { get; set; }
        public object? Account_Name { get; set; }
        public object? Product_Name0 { get; set; }
        public object? SKU_5_Quantity_B2B { get; set; }
        public object? Dealer_Remarks { get; set; }
        public object? Keyword { get; set; }
        public bool B2B_Cx_Confirmed_Sale { get; set; }
        public object? FLS_Visit_Remarks_B2B { get; set; }
        public object? Remarks_of_NPD { get; set; }
        public object? Amount { get; set; }
        public object? Tiles_Requirement_for { get; set; }
        public object? BH_Employee_ID { get; set; }
        public bool Converted_Opportunity { get; set; }
        public string Mobile { get; set; }
        public string Record_Status__s { get; set; }
        public string Zonal_Manager { get; set; }
        public object? Remark_of_SKU_B2B { get; set; }
        public object? State_Union_Territory_2 { get; set; }
        public object? PMT_Current_Stage { get; set; }
        public string Type { get; set; }
        public object? Ad_Campaign_Name { get; set; }
        public bool Locked__s { get; set; }
        public object? SKU_1_Price_B2B { get; set; }
        public object? gaconnectorfields1__Pages_Visited { get; set; }
        public object? Project_Name_B2B { get; set; }
        public List<object?> Tag { get; set; }
        public object? PMT_Lead_Status { get; set; }
        public object? Project_Lead_from { get; set; }
        public object? NP_6_Date { get; set; }
        public object? Reason_for_Conversion_Failure { get; set; }
        public object? Warm_Lead_B2B_Date { get; set; }
        public List<object?> Sizes_Shortlisted { get; set; }
        public object? Registered_Lead { get; set; }
        public object? Did_you_receive_a_catalog_from_Customer_Care { get; set; }
        public object? Lead_Assignment_Order_Confirmation_B2B_Date { get; set; }
        public object? OBL_Con_CP_change_status_Remarks { get; set; }
        public object? NP_2_Date { get; set; }
        public object? Sales_Person_Employee_code { get; set; }
        public bool Physical_Visit_Email_Alert { get; set; }
        public object? Shortlisted_SKU { get; set; }
        public object? Sales_Person_Status { get; set; }
        public object? Lead_Type0 { get; set; }
        public object? Dealer_Name { get; set; }
        public object? Design_Selection { get; set; }
        public object? Won_Amount { get; set; }
        public string Visit_Status { get; set; }
        public object? gaconnectorfields1__Operating_System { get; set; }
        public object? BH_Phone { get; set; }
        public object? SKU_5_Name_B2B { get; set; }
        public object? NP_1_Date { get; set; }

        [JsonProperty("$locked_for_me")]
        public bool locked_for_me { get; set; }
        public object? gaconnectorfields1__First_Click_Landing_Page { get; set; }
        public string BM_Code { get; set; }
        public object? Conversion_Exported_On { get; set; }
        public object? FLS_Follow_up_B2B_Date { get; set; }
        public string Remarks_spoken_to_customer { get; set; }
        public object? Display_Cassetees_Mockup { get; set; }
        public object? Click_Type { get; set; }
        public object? Previous_Status { get; set; }

        [JsonProperty("$wizard_connection_path")]
        public object? wizard_connection_path { get; set; }

        [JsonProperty("$editable")]
        public bool editable { get; set; }
        public object? L1_user_Name { get; set; }
        public object? City { get; set; }
        public object? AdGroup_Name { get; set; }
        public object? PCH_Email_ID { get; set; }
        public object? Task_Subject_12 { get; set; }
        public object? gaconnectorfields1__First_Click_Campaign { get; set; }
        public object? OrderConfirmation_SKU_B2B { get; set; }
        public object? SKU_1_size_B2B { get; set; }
        public object? gaconnectorfields1__Last_Click_Channel { get; set; }
        public object? Dealers_Code { get; set; }
        public object? Sampling_From_HO_B2B_Date { get; set; }
        public object? Tile_Requirement_in_Area_Sq_ft { get; set; }
        public string Hours_Difference { get; set; }
        public object? Conversion_Export_Status { get; set; }
        public DateTime? Schedule_Visit_time { get; set; }
        public object? SKU_5_Price_B2B { get; set; }
        public object? gaconnectorfields1__Last_Click_Campaign { get; set; }
        public List<object?> Reasons_of_NPD { get; set; }
        public object? Tele_Sales_Interested_Date_and_Time { get; set; }
        public object? Lead_Response_Medium_Whatsapp_Email_B2B_L2_Calli { get; set; }
        public object? gaconnectorfields1__Last_Click_Content { get; set; }
        public object? Final_Lead_Status { get; set; }
        public object? Due_Date { get; set; }
        public List<object?> How_did_you_first_learn_about_OBL_tiles { get; set; }
        public object? Store_Visit_Remarks_B2B { get; set; }
        public object? Lead_Assignment_Physical_visit_B2B_Date { get; set; }
        public string Zone { get; set; }
        public object? Closed_Lost_Date { get; set; }
        public object? PMT_Project_Contact_No { get; set; }
        public object? gaconnectorfields1__Country_from_IP_address { get; set; }
        public int? Sales_Cycle_Duration { get; set; }
        public string Branch_Manager { get; set; }
        public object? Sales_Person_Employee_Code1 { get; set; }
        public object? SKU_4_size_B2B { get; set; }
        public object? Mcat_Name { get; set; }
        public string Lead_Qualification_Date_Time { get; set; }
        public object? SKU_2_Quantity_B2B { get; set; }
        public List<object?> Tile_Category { get; set; }
        public List<StageHistory> Stage_History { get; set; }

        [JsonProperty("$has_more")]
        public HasMore has_more { get; set; }

    }

    public class HasMore
    {
        public bool OrderConfirmation_SKU_B2B { get; set; }
        public bool Category_Details_from_APP { get; set; }
        public bool SKUs_B2B { get; set; }
        public bool Sales_Person_Notes { get; set; }
    }

    public class SalesPersonLayout
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class SalesPersonModifiedBy
    {
        public string name { get; set; }
        public string id { get; set; }
        public string email { get; set; }
    }

    public class SalesPersonOwner
    {
        public string name { get; set; }
        public string id { get; set; }
        public string email { get; set; }
    }

    public class ParentId
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class SalesPersonReviewProcess
    {
        public bool approve { get; set; }
        public bool reject { get; set; }
        public bool resubmit { get; set; }
    }

    public class SalesPersonNote
    {
        public DateTime? Modified_Time { get; set; }
        public string Modified_By_Emp_ID { get; set; }
        public DateTime? Notes_Created_Time { get; set; }

        [JsonProperty("$field_states")]
        public object? field_states { get; set; }
        public DateTime? Created_Time { get; set; }
        public ParentId Parent_Id { get; set; }
        public string Modifier_Name { get; set; }
        public SalesPersonLayout Layout { get; set; }

        [JsonProperty("$in_merge")]
        public bool in_merge { get; set; }
        public object? Stage { get; set; }
        public string id { get; set; }

        [JsonProperty("$zia_visions")]
        public object? zia_visions { get; set; }
        public object? Stage_Modified_Date { get; set; }
        public string FLS_Notes { get; set; }
    }
}

