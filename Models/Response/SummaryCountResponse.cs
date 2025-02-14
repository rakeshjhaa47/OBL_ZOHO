namespace OBL_Zoho.Models.Response
{
    public class SummaryCountResponse
    {
        public SummaryCountResponse()
        {
            data = new List<DatumCount>();
            info = new InfoCount();
        }
        public List<DatumCount> data { get; set; }
        public InfoCount info { get; set; }
    }

    public class DatumCount
    {
        public decimal? Total_Amount { get; set; }
        public string Stage { get; set; }
        public int Total_Count { get; set; }
        public decimal? Tile_Total { get; set; }
        public decimal? Final_Tile_Total { get; set; }
    }

    public class InfoCount
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    


}
