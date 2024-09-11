namespace OBL_Zoho.Models.Response
{
    public class DealData
    {
        public List<DealListData> data { get; set; }
        public Info DealDataInfo { get; set; }
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
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    


}
