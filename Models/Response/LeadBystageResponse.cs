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
        public decimal? Amount { get; set; }
        public DateTime? Recent_Stage_Update_Date_Time { get; set; }
        public string Stage_Category { get; set; }
        public string? City { get; set; }
        public DateTime? Tiling_Date_Likely_Purchase_Date { get; set; }
        public string? PCH_Email_ID { get; set; }
        public decimal? Final_Tile_Requirement_in_Area_Sq_ft { get; set; }
        public int? Mobile { get; set; }
        public DateTime? Closing_Date { get; set; }
        public string? Dealer_Name { get; set; }
        public string Deal_Name { get; set; }
        public string Stage { get; set; }
        public string? Zip_Code { get; set; }
        public double id { get; set; }
    }

    public class Infodata
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

   


}
