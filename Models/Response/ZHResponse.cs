using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
    public class ZHResponse
    {
        public List<ZHResponseData> data { get; set; } = new();
        public Info info { get; set; } = new();
    }
    public class Approval
    {
        public bool @delegate { get; set; }
        public bool approve { get; set; }
        public bool reject { get; set; }
        public bool resubmit { get; set; }
    }

    public class ContactName
    {
        public string name { get; set; }
        public string id { get; set; }
    }


    public class ZHResponseData
    {
        public string id { get; set; }
        public string Closing_Date { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Contact_Email { get; set; }
        public string Sales_Person_Email_ID { get; set; }
        public object OBL_Exec_FLS_lost_lead_Remarks { get; set; }
        public object OBL_Exec_FLS_change_status_Remarks { get; set; }
        public object OBL_Exec_Amount { get; set; }
        public string Dealer_Name { get; set; }
        public object Dealers_Code { get; set; }
        public string Design_Selection { get; set; }
        public Owner Owner { get; set; }
        public object L2_Owner { get; set; }
        public ModifiedBy Modified_By { get; set; }
        public CreatedBy? Created_By { get; set; }
        public string Type { get; set; }
        public string Qualified_Type { get; set; }
        public string L2_Remarks { get; set; }
        public int? Amount { get; set; }
        public string Stage { get; set; }
        public object CP_Name { get; set; }
        public object Lead_Status { get; set; }
        public L1UserName L1_user_Name { get; set; }
        public Layout Layout { get; set; }
        public string L1_Remarks { get; set; }
        public string Mobile { get; set; }
        public object Total_SqFt_requirements { get; set; }
        public string Sales_Person { get; set; }
        public string L2_Status { get; set; }
        public string Deal_Name { get; set; }
        public object Dealer_Type { get; set; }
        public object Lead_Type { get; set; }
        public object Sales_Person_Employee_code { get; set; }
        public string PCH { get; set; }
        public string PCH_Email_ID { get; set; }
        public DateTime? Lead_Created_Time { get; set; }
        public object Purchase_Date { get; set; }
        public List<string> Tile_Category { get; set; }
        public string Lead_Category { get; set; }
        public string Tiling_Date_Likely_Purchase_Date { get; set; }
        public int? Tile_Requirement_in_Area_Sq_ft { get; set; }
        public DateTime? Created_Time { get; set; }
        public List<Sales_Person_Notes> Sales_Person_Notes { get; set; }
    }

    public class ReviewProcess
    {
        public bool? approve { get; set; }
        public bool? reject { get; set; }
        public bool? resubmit { get; set; }
    }

    
}
