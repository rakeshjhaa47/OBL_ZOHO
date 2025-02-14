namespace OBL_Zoho.Models.Response
{
    public class DataDashboard
    {
        public int Amount { get; set; }
        public string Stage { get; set; }
        public string id { get; set; }
        public double Final_Tile_Requirement_in_Area_Sq_ft { get; set; }
        public string Closing_Date { get; set; }
    }

    public class InfoDashboard
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    public class DashboardResponse
    {

        public DashboardResponse()
        {
            data = new List<DataDashboard>();
            info = new InfoDashboard();
        }
        public List<DataDashboard> data { get; set; }
        public InfoDashboard info { get; set; }
    }


}
