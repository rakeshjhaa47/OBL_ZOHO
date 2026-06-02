using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
    public class CountRecordsAndTotalTileResponse
    {
        public List<CountRecordsAndTotalTileData> Data { get; set; }
        public InfoDetails Info { get; set; }
    }

    public class CountRecordsAndTotalTileData
    {
        public double? Total_Amount { get; set; }
        public string Stage { get; set; }
        public int Total_Count { get; set; }
        public double? Tile_Total { get; set; }
        public double? Final_Tile_Total { get; set; }
    }

    public class InfoDetails
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }
}
