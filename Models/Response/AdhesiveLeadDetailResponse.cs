using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
    public class AccountName
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class AdhesiveLayout
    {
        public string display_label { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class AdhesiveModifiedBy
    {
        public string name { get; set; }
        public string id { get; set; }
        public string email { get; set; }
    }

    public class AdhesiveOwner
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class AdhesiveContactName
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class AdhesiveSalesPersonId
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class AdhesiveTimeline
    {
        public string Emp_id { get; set; }
        public string L1_Notes { get; set; }
        public string Name1 { get; set; }
        public string nextFollowUpDate { get; set; }
        public string Remarks { get; set; }
        public int? timelineType { get; set; }
        public string Types { get; set; }
        public string Updated_Stage { get; set; }
        public DateTime? Modified_Time { get; set; }
        public DateTime? Created_Time { get; set; }
    }

    public class LeadDetailOutput
    {
        public AccountName Account_Name { get; set; }
        [JsonProperty("Opportunity Id")]
        public string OpportunityId { get; set; }
        public string Adhesive_BH_Code { get; set; }
        public string Adhesive_Sales_Person_Emp_ID { get; set; }
        public string Adhesive_Sales_Person_Name { get; set; }
        public string Adhesive_Type { get; set; }
        public List<string> Adhesive_Type1 { get; set; }
        public string City { get; set; }
        public string Closed_By { get; set; }
        public string Closing_Date { get; set; }
        public string Contact_Email { get; set; }
        public decimal? Final_Amount { get; set; }
        public AdhesiveLayout Layout { get; set; }
        public string Lead_Category { get; set; }
        public string Lead_Source { get; set; }
        public string Mobile { get; set; }
        public AdhesiveModifiedBy Modified_By { get; set; }
        public string Adhesive_NH_Code { get; set; }
        public string Deal_Name { get; set; }
        public int? Qty_required { get; set; }
        public int? Qty_delivered { get; set; }
        public string Sales_Person_Email_ID { get; set; }
        public string Stage { get; set; }
        public string Stage_Category { get; set; }
        public string Sub_source { get; set; }
        public List<object?> Tag { get; set; }
        public string All_Traffic_Sources { get; set; }
        public string Browser { get; set; }
        public AdhesiveOwner Owner { get; set; }
        public AdhesiveContactName Contact_Name { get; set; }
        public AdhesiveSalesPersonId Adhesive_SalesPerson_ID { get; set; }
        public string Contact_Phone { get; set; }
        public List<AdhesiveTimeline> Timleline { get; set; }
        public string Zip_Code { get; set; }
        public DateTime? Modified_Time { get; set; }
        public DateTime? Created_Time { get; set; }

    }

    public class AdhesiveDetails
    {
        public LeadDetailOutput output { get; set; }

        public List<string> userMessage { get; set; }

        public string output_type { get; set; }

        public string id { get; set; }
    }

    public class AdhesiveLeadDetailResponse
    {
        public string code { get; set; }

        public AdhesiveDetails details { get; set; }

        public string message { get; set; }
    }

    public class RawDetails
    {
        public string output { get; set; }

        public List<string> userMessage { get; set; }

        public string output_type { get; set; }

        public string id { get; set; }
    }

    public class RawAdhesiveLeadDetailResponse
    {
        public string code { get; set; }

        public RawDetails details { get; set; }

        public string message { get; set; }
    }
}