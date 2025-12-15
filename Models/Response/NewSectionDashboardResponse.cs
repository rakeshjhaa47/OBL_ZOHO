using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
        public class NewSectionDashboardResponse
        {
            public string stage { get; set; }
            public int? Total_Amount { get; set; }
            public object delivered_tile_area { get; set; }
            public int Leads_Count { get; set; }
            public int req_tile_area { get; set; }
        }

        public class NewSectionDashboardInfo
        {
            public int count { get; set; }
            public bool more_records { get; set; }
        }

        public class NewSectionDashboardRoot
        {
            public NewSectionDashboardRoot()
            {
                data = new List<NewSectionDashboardResponse>();
                info = new NewSectionDashboardInfo();
            }
            public List<NewSectionDashboardResponse> data { get; set; }
            public NewSectionDashboardInfo info { get; set; }
        }
}
