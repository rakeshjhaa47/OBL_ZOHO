namespace OBL_Zoho.Models.Response
{
    public class PageLeadResponse
    {

        public PageLeadResponse()
        {
            data = new List<DatumPage>();
            info = new InfoPage();
        }
        public List<DatumPage> data { get; set; }
        public InfoPage info { get; set; }
    }

    public class DatumPage
    {
        public string Deal_Name { get; set; }
        public object Amount { get; set; }
        public string id { get; set; }
        public string City { get; set; }
        public string Sales_Person_Email_ID { get; set; }
        public string PCH_Email_ID { get; set; }
    }

    public class InfoPage
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    


}
