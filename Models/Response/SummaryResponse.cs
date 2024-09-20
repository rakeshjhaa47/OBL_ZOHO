namespace OBL_Zoho.Models.Response
{
    public class SummaryResponse
    {
        public SummaryResponse()
        {
            data = new List<SummaryData>();
            info = new SummaryDataInfo();
        }

        public List<SummaryData> data { get; set; }
        public SummaryDataInfo info { get; set; }
    }

    public class SummaryData
    {
        public int Amount { get; set; }
        public string Stage { get; set; }
        public string id { get; set; }
        public string Closing_Date { get; set; }
    }

    public class SummaryDataInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    


}
