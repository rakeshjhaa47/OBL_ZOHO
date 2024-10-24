namespace OBL_Zoho.Models.Response
{
    public class CountResponse
    {


        public CountResponse()
        {
            data = new List<Datacount>();
            info = new CountInfo();
        }
        public List<Datacount> data { get; set; }
        public CountInfo info { get; set; }
    }
    public class Datacount
    {
        public decimal? Total_Amount { get; set; }
        public string Stage { get; set; }
        public int Total_Count { get; set; }
        public decimal? Tile_Total { get; set; }
    }

    public class CountInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    



}
