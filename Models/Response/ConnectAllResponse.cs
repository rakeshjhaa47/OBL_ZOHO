namespace OBL_Zoho.Models.Response
{

    public class ConnectAllResponse
    {

        public ConnectAllResponse()
        {
            data = new List<DataResponse>();
            info = new InfoAllData();
        }
        public List<DataResponse> data { get; set; }
        public InfoAllData info { get; set; }
    }
    public class DataResponse
    {
        public string Sales_Person_Email_ID { get; set; }
        public string Assigned_CP_By_Agent { get; set; }
        public int? Tile_Requirement_in_Area_Sq_ft { get; set; }
        public DateTime Created_Time { get; set; }
        public int? Amount { get; set; }
        public DateTime? Recent_Stage_Update_Date_Time { get; set; }
        public string Stage_Category { get; set; }
        public string? City { get; set; }
        public DateTime? Tiling_Date_Likely_Purchase_Date { get; set; }
        public string? PCH_Email_ID { get; set; }
        public double? Final_Tile_Requirement_in_Area_Sq_ft { get; set; }
        public string? Mobile { get; set; }
        public DateTime? Closing_Date { get; set; }
        public string? Dealer_Name { get; set; }
        public string Deal_Name { get; set; }
        public string Stage { get; set; }
        public string? Zip_Code { get; set; }
        public string id { get; set; }
    }

    public class InfoAllData
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    


}
