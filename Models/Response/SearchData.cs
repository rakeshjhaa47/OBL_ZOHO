using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
    public class SearchData
    {
        public SearchData()
        {
            data = new List<Datum>();
            info=new Info();
        }
        public List<Datum> data { get; set; }
        public Info info { get; set; }
    }
    public class CreatedBy
    {
        public string name { get; set; }
        public string id { get; set; }
        public string email { get; set; }
    }

    public class Datum
    {
        public string Id { get; set; }
        public object Closing_Date { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Contact_Email { get; set; }
        public string Sales_Person_Email_ID { get; set; }
        public object OBL_Exec_FLS_lost_lead_Remarks { get; set; }
        public object OBL_Exec_FLS_change_status_Remarks { get; set; }
        public object OBL_Exec_Amount { get; set; }
        public object Dealer_Name { get; set; }
        public object Dealers_Code { get; set; }
        public string Design_Selection { get; set; }
        public Owner Owner { get; set; }
        public object L2_Owner { get; set; }
        public ModifiedBy Modified_By { get; set; }
        public CreatedBy Created_By { get; set; }
        public string Type { get; set; }
        public string Qualified_Type { get; set; }
        public string L2_Remarks { get; set; }
        public decimal? Amount { get; set; }
        public string Stage { get; set; }
        public object CP_Name { get; set; }
        public object Lead_Status { get; set; }
        public L1UserName L1_user_Name { get; set; }
        public Layout Layout { get; set; }
        public object L1_Remarks { get; set; }
        public string Mobile { get; set; }
        public object Total_SqFt_requirements { get; set; }
        public string Sales_Person { get; set; }
        public string L2_Status { get; set; }
        public string Deal_Name { get; set; }
        public object Dealer_Type { get; set; }
        public object Lead_Type { get; set; }
        public object Sales_Person_Employee_code { get; set; }
        public object PCH { get; set; }
        public string PCH_Email_ID { get; set; }
        public DateTime? Lead_Created_Time { get; set; }
        public object Purchase_Date { get; set; }
        public List<string> Tile_Category { get; set; }
        public string Lead_Category { get; set; }
        public DateTime? Tiling_Date_Likely_Purchase_Date { get; set; }
        public int? Tile_Requirement_in_Area_Sq_ft { get; set; }
        public DateTime? Created_Time { get; set; }
        public List<Sales_Person_Notes> Sales_Person_Notes { get; set; }
        public List<StageHistory> Stage_History { get; set; }
    }

    public class Info
    {
        public int? per_page { get; set; }
        public int? count { get; set; }
        public string sort_by { get; set; }
        public int? page { get; set; }
        public string sort_order { get; set; }
        public bool? more_records { get; set; }
    }

    public class L1UserName
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Layout
    {
        public string? name { get; set; }
        public string? id { get; set; }
    }

    public class ModifiedBy
    {
        public string name { get; set; }
        public string id { get; set; }
        public string email { get; set; }
    }

    public class Owner
    {
        public string name { get; set; }
        public string id { get; set; }
        public string email { get; set; }
    }

    public class Sales_Person_Notes
    {
        public string? Modifier_Name { get; set; }
        public string? Modified_Time { get; set; }
        public string? Modified_By_Emp_ID { get; set; }
        public string? Notes_Created_Time { get; set; }
        public Layout Layout { get; set; }
        [JsonProperty ("$in_merge")]
        public bool? in_merge { get; set; }
        [JsonProperty("$field_states")]
        public bool? field_states { get; set; }
        public DateTime? Created_Time { get; set; }
        public Parent_Id parent_Id { get; set; }
        public string Id { get; set; }
        [JsonProperty("$zia_visions")]
        public bool? zia_visions { get; set; }
        public string? FLS_Notes { get; set; }
        public string? Stage { get; set; }
        public DateTime? Stage_Modified_Date { get; set; }
    }
    public class Parent_Id
    {
        public string? name { get; set; }
        public string id { get; set; }
    }
}
