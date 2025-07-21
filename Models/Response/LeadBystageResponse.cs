namespace OBL_Zoho.Models.Response
{
    public class LeadBystageResponse
    {

        public LeadBystageResponse() {
            data = new List<Datumdata>();
            info = new Infodata();
        }
        public List<Datumdata> data { get; set; }
        public Infodata info { get; set; }
    }

    public class Datumdata
    {
        public string Sales_Person_Email_ID { get; set; }
        public int? Tile_Requirement_in_Area_Sq_ft { get; set; }
        public DateTime Created_Time { get; set; }
        public List<string>? Sizes_Shortlisted { get; set; }
        public double? Amount { get; set; }
        public double Tile_Requirement_in_Area_Sq_Mtr { get; set; }
        public DateTime? Recent_Stage_Update_Date_Time { get; set; }
        public string Stage_Category { get; set; }
        public string? City { get; set; }
        public DateTime? Tiling_Date_Likely_Purchase_Date { get; set; }
        public string? PCH_Email_ID { get; set; }
        public decimal? Final_Tile_Requirement_in_Area_Sq_ft { get; set; }
        public string? Mobile { get; set; }
        public string? Assigned_CP_Name { get; set; }
        public DateTime? Closing_Date { get; set; }
        public string? Dealer_Name { get; set; }
        public string? Design_Selection { get; set; }
        public string Deal_Name { get; set; }
        public string Lead_Category { get; set; }
        public string Stage { get; set; }
        public string? Zip_Code { get; set; }
        public string id { get; set; }
        public List<string>? Tile_Category { get; set; }
        public string? Closed_By { get; set; }
        public string? L2_Remarks { get; set; }
        public DateTime? Modified_time_crmMasters { get; set; }
    }

    public class Infodata
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }
}
