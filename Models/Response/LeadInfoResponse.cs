namespace OBL_Zoho.Models.Response
{
#nullable disable

    public class LeadInfoResponse
    {
        public int per_page { get; set; }
        public string next_page_token { get; set; }
        public int count { get; set; }
        public string sort_by { get; set; }
        public int page { get; set; }
        public object previous_page_token { get; set; }
        public DateTime? page_token_expiry { get; set; }
        public string sort_order { get; set; }
        public bool more_records { get; set; }
    }
}
