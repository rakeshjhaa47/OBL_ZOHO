namespace OBL_Zoho.Models.Response
{
    public class EmailResponse
    {
        public List<EmailResponseData> data { get; set; }
    }
    public class EmailResponseData
    {
        public string Sales_Person_Email { get; set; }
        public string id { get; set; }
    }
}
