namespace OBL_Zoho.Models.Response
{
    public class AdhesiveDashboardDatum
    {
        public string Stage { get; set; }
        public int Qty_Total { get; set; }
        public int Total_Count { get; set; }
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
