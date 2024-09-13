namespace OBL_Zoho.Models.Response
{
    public class DealSortData
    {
        public DealSortData()
        {
            data = new List<SortData>();
            info = new SortDataInfo();
        }

        public List<SortData> data { get; set; }
        public SortDataInfo info { get; set; }
    }
    public class SortData
    {
        public string Sales_Person_Email_ID { get; set; }
        public int Tile_Requirement_in_Area_Sq_ft { get; set; }
        public DateTime Created_Time { get; set; }
        public int? Amount { get; set; }
        public string City { get; set; }
        public string Tiling_Date_Likely_Purchase_Date { get; set; }
        public string PCH_Email_ID { get; set; }
        public string Mobile { get; set; }
        public string Closing_Date { get; set; }
        public string Dealer_Name { get; set; }
        public string Deal_Name { get; set; }
        public string Stage { get; set; }
        public string Zip_Code { get; set; }
        public string id { get; set; }
    }

    public class SortDataInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

}
