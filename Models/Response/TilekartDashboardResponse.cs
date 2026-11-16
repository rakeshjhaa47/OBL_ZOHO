namespace OBL_Zoho.Models.Response
{
    public class TilekartDashboardResponse
    {
        public string? Email { get; set; }
        public string? Type_of_Customer { get; set; }
        public decimal? Tile_Requirement_in_Area_Sq_Mtr { get; set; }
        public string? City { get; set; }
        public string? Mobile { get; set; }
        public string? Sales_Person_Name { get; set; }
        public string? Name { get; set; }
        public decimal? Target { get; set; }
        public string? Stage { get; set; }
        public string? Sales_Person_Mobile { get; set; }
        public string? id { get; set; }
        public decimal? Priority_Score { get; set; }
        public string? Secondary_Email { get; set; }
    }

    public class TilekartUIApiInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    public class TilekartUIApiRoot
    {
        public TilekartUIApiRoot()
        {
            data = new List<TilekartDashboardResponse>();
            info = new TilekartUIApiInfo();
        }

        public List<TilekartDashboardResponse> data { get; set; }
        public TilekartUIApiInfo info { get; set; }
    }
}