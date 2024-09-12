namespace OBL_Zoho.Models.Response
{
    public class LeadDataResponse
    {
        public LeadDataResponse()
        {
            data = new List<DealListData>();
            dealDataInfo = new DealDataInfo();
        }
        public List<DealListData> data { get; set; }
        public DealDataInfo dealDataInfo { get; set; }
    }

    public class DealListData
    {
        public object Total_Amount { get; set; }
        public string Stage { get; set; }
        public int Total_Count { get; set; }
        public int Tile_Total { get; set; }
    }

    public class DealDataInfo
    {
        public int? count { get; set; }
        public bool? more_records { get; set; }
    }

    


}
