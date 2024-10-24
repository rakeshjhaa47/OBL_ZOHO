namespace OBL_Zoho.Models.Response
{
    public class OBLConnect
    {

        public OBLConnect()
        {
            data = new List<OBLData>();
            info = new OBLInfo();
        }

        public List<OBLData> data { get; set; }
        public OBLInfo info { get; set; }
    }
    public class OBLData
    {
        public string Sales_Person_Email_ID { get; set; }
        public string Assigned_CP_By_Agent { get; set; }
        public object Tile_Requirement_in_Area_Sq_ft { get; set; }
        public DateTime Created_Time { get; set; }
        public object Amount { get; set; }
        public object City { get; set; }
        public object Tiling_Date_Likely_Purchase_Date { get; set; }
        public string PCH_Email_ID { get; set; }
        public string Mobile { get; set; }
        public object Closing_Date { get; set; }
        public object Dealer_Name { get; set; }
        public string Deal_Name { get; set; }
        public string Stage { get; set; }
        public object Zip_Code { get; set; }
        public string id { get; set; }
    }

    public class OBLInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    



}
