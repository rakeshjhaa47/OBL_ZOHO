using System.Text.Json.Serialization;

namespace OBL_Zoho.Models.Response
{
    public class DataBH
    {
        public decimal? Total_Amount { get; set; }
        public string? Stage { get; set; }
        public int? Total_Count { get; set; }
        public double? Tile_Total { get; set; }
        public double? Final_Tile_Total { get; set; }
    }

    public class InfoBHData
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    public class RootBHData
    {
        public RootBHData()
        {
            data = new List<DataBH>();
            info = new InfoBHData();
        }
        public List<DataBH> data { get; set; }
        public InfoBHData info { get; set; }

    }


}
