namespace OBL_Zoho.Models.Response
{
#nullable disable

    public class LeadUpdateResponse
    {
        public List<LeadUpdate> data { get; set; }
    }

    public class LeadUpdate
    {
        public string code { get; set; }
        public string duplicate_field { get; set; }
        public string action { get; set; }
        public details details { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public List<Sales_Person_Notes> Sales_Person_Notes { get; set; }
    }

    public class details
    {
        public DateTime modified_time { get; set; }
        public name_id modified_by { get; set; }
        public DateTime created_time { get; set; }
        public string id { get; set; }
        public name_id created_by { get; set; }
    }

    public class name_id
    {
        public string name { get; set; }
        public string id { get; set; }
    }
}
