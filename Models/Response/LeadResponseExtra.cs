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
        public string Dealer_Name { get; set; }
        public string Dealer_Type { get; set; }
        public string Lead_Response_Medium_Whatsapp_Email_B2B_L2_Calli { get; set; }
        public string Sales_Person_Status { get; set; }
        public string Sales_Person_Customer_Remarks { get; set; }
    }
}
