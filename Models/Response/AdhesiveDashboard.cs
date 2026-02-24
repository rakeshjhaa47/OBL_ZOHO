namespace OBL_Zoho.Models.Response
{
    public class AdhesiveDashboardDatum
    {
        public string stage { get; set; }
        public int? qtyReq { get; set; }
        public int? totalCount { get; set; }
        public int? qtyDelivered { get; set; }
    }
    public class AdhesivesDashboardInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }
    public class AdhesiveDashboard
    {
        public AdhesiveDashboard()
        {
            data = new List<AdhesiveDashboardDatum>();
            info = new AdhesivesDashboardInfo();
        }
        public List<AdhesiveDashboardDatum> data { get; set; }
        public AdhesivesDashboardInfo info { get; set; }
    }
}