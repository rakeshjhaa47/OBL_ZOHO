namespace OBL_Zoho.Models.Response
{
    public class AdhesiveDashboardResponse
    {
        public List<AdhesiveDashboardData> Data { get; set; }
        public AdhesiveDashboardInfo Info { get; set; }
    }

    public class AdhesiveDashboardData
    {
        public string Stage { get; set; }
        public int Total_Count { get; set; }
        public decimal Qty_Total { get; set; }
    }

    public class AdhesiveDashboardInfo
    {
        public int Count { get; set; }
        public bool More_Records { get; set; }
    }
}
