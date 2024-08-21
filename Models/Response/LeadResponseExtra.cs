using System.Reflection;

namespace OBL_Zoho.Models.Response
{
#nullable disable
    public class LeadResponseExtra
    {
        public List<LeadDataExtra> data { get; set; }
        public LeadInfoResponse info { get; set; }
    }

    public class LeadDataExtra
    {
        public string Id { get; set; }
        public string Attachment { get; set; }
        public string Dealer_Name { get; set; }
        public int? Amount { get; set; }
        public string Purchase_Date { get; set; }
        public string Tiling_Date_Likely_Purchase_Date { get; set; }
        public string Closing_Date { get; set; }
        public string Dealer_Type { get; set; }
        public string Lead_Response_Medium_Whatsapp_Email_B2B_L2_Calli { get; set; }
        public string Sales_Person_Status { get; set; }
        public string Sales_Person_Customer_Remarks { get; set; }
        public string Remarks_of_quotation_shared { get; set; }
        public string Remarks_of_visit_store { get; set; }
        public string Remarks_of_Sample_shared { get; set; }
        public string Remarks_spoken_to_customer { get; set; }
        public string Remarks { get; set; }
    }
}
