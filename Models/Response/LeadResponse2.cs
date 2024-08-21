namespace OBL_Zoho.Models.Response
{
#nullable disable
    public class LeadResponse2
    {
        public List<Data> data { get; set; }
        public Info2 info { get; set; }
    }

    public class Data
    {
        public string Email { get; set; }
        //public string Mobile { get; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        //public string Lead_Status { get; }
        //public string Lead_Source { get; }
        //public string L2_Remarks { get; }
        //public string Lead_Category { get; }
        //public string L1_Remarks { get; }
        public string id { get; set; }
        //public string City { get; }
    }

    public class Info2
    {
        public int per_page { get; set; }
        public string next_page_token { get; set; }
        public int count { get; set; }
        public string sort_by { get; set; }
        public int page { get; set; }
        public object previous_page_token { get; set; }
        public DateTime page_token_expiry { get; set; }
        public string sort_order { get; set; }
        public bool more_records { get; set; }
    }
}
