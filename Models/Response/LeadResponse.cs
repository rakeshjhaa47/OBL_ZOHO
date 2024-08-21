namespace OBL_Zoho.Models.Response
{
#nullable disable
    public class LeadResponse
    {
        public List<LeadData> data { get; set; }
        public LeadInfoResponse info { get; set; }
    }

    public class LeadData
    {
        public string Closing_Date { get; set; }
        public DateTime Created_Time_Sort { get; set; }
        public string Created_Time { get; set; }
        public string Id { get; set; }
        public string Last_Name { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Lead_Category { get; set; }
        public List<string> Tile_Category { get; set; }
        public string Tiling_Date_Likely_Purchase_Date { get; set; }
        public string Lead_Created_Time { get; set; }
        public DateTime? Lead_Created_Time_Sort { get; set; }
        public string PCH_Email_Id { get; set; }
        public string L2_Owner { get; set; }
        public string PCH { get; set; }
        public string Sales_Person_Employee_code { get; set; }
        public string Lead_Type { get; set; }
        public string Dealer_Type { get; set; }
        public string Deal_Name { get; set; }
        public string L2_Status { get; set; }
        public string Sales_Person { get; set; }
        public string Tile_Requirement_in_Area_Sq_ft { get; set; }
        public string Mobile { get; set; }
        public string L1_Team_Remarks { get; set; }
        public layout Layout { get; set; }
        public l1UserName L1_user_Name { get; set; }
        public string Lead_Status { get; set; }
        public string CP_Name { get; set; }
        public string Stage { get; set; }
        public string Amount { get; set; }
        public string L2_Remarks { get; set; }
        public string Type { get; set; }
        public createdBy Created_By { get; set; }
        public modifiedBy Modified_By { get; set; }
        public owner Owner { get; set; }
        public string Design_Selection { get; set; }
        public string Dealer_Code { get; set; }
        public string Dealer_Name { get; set; }
        public string Schedule_Store_Visit_Date { get; set; }
        public string L2_Date_of_Visit_Planned_Visited { get; set; }
        public string OBL_Exec_Amount { get; set; }
        public string OBL_Exec_FLS_change_status_Remarks { get; set; }
        public string OBL_Exec_FLS_lost_lead_Remarks { get; set; }
        public string Email { get; set; }
        public string Dealers_Code { get; set; }
        public List<Sales_Person_Notes> Sales_Person_Notes { get; set; }

    }

    public class layout
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class l1UserName
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class owner
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class createdBy
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class modifiedBy
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class LeadUpdateRequest
    {
        public List<UpdateData> data { get; set; }

    }

    public class UpdateData
    {
        public string Closing_Date { get; set; }
        public DateTime Created_Time_Sort { get; set; }
        public string Created_Time { get; set; }
        public string Id { get; set; }
        public string Last_Name { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Lead_Category { get; set; }
        public List<string> Tile_Category { get; set; }
        public string Lead_Created_Time { get; set; }
        public DateTime? Lead_Created_Time_Sort { get; set; }
        public string PCH_Email_Id { get; set; }
        public string L2_Owner { get; set; }
        public string PCH { get; set; }
        public string Sales_Person_Employee_code { get; set; }
        public string Lead_Type { get; set; }
        public string Dealer_Type { get; set; }
        public string Deal_Name { get; set; }
        public string L2_Status { get; set; }
        public string Sales_Person { get; set; }
        public string Tile_Requirement_in_Area_Sq_ft { get; set; }
        public string Mobile { get; set; }
        public string L1_Team_Remarks { get; set; }
        public layout Layout { get; set; }
        public l1UserName L1_user_Name { get; set; }
        public string Lead_Status { get; set; }
        public string CP_Name { get; set; }
        public string Stage { get; set; }
        public string Amount { get; set; }
        public string L2_Remarks { get; set; }
        public string Type { get; set; }
        public createdBy Created_By { get; set; }
        public modifiedBy Modified_By { get; set; }
        public owner Owner { get; set; }
        public string Design_Selection { get; set; }
        public string Dealer_Code { get; set; }
        public string Dealer_Name { get; set; }
        public string Schedule_Store_Visit_Date { get; set; }
        public string L2_Date_of_Visit_Planned_Visited { get; set; }
        public string OBL_Exec_Amount { get; set; }
        public string OBL_Exec_FLS_change_status_Remarks { get; set; }
        public string OBL_Exec_FLS_lost_lead_Remarks { get; set; }
        public string Email { get; set; }
        public string Dealers_Code { get; set; }
        public List<Sales_Person_Notes> Sales_Person_Notes { get; set; }

    }
}
