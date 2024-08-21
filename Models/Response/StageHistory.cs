namespace OBL_Zoho.Models.Response
{
    public class StageHistory
    {
        public StageHistoryModifiedBy Modified_By { get; set; }
        public DateTime Modified_Time { get; set; }
        public string Stage { get; set; }
        public string id { get; set; }
    }

    public class StageHistoryModifiedBy
    {
        public string name { get; set; }
        public string id { get; set; }
        public string email { get; set; }
    }

    public class Root
    {
        public List<StageHistory> data { get; set; }
    }

}
