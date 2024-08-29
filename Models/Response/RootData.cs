namespace OBL_Zoho.Models.Response
{
    public class RootData
    {
        public RootData()
        {
            data = new List<DatumData>();
            info = new InfoData();
        }
        public List<DatumData> data { get; set; }
        public InfoData info { get; set; }
    }

    public class DatumData
    {
        public string Sales_Person_Email_ID { get; set; }
        public int? Tile_Requirement_in_Area_Sq_ft { get; set; }
        public DateTime Created_Time { get; set; }
        private object _amount;
        public object Amount
        {
            get => _amount ?? 0m;
            set => _amount = value;
        }
        public string City { get; set; }
        public string Tiling_Date_Likely_Purchase_Date { get; set; }
        public string PCH_Email_ID { get; set; }
        public string Mobile { get; set; }
        public string Closing_Date { get; set; }
        public object Dealer_Name { get; set; }
        public string Deal_Name { get; set; }
        public string Stage { get; set; }
        public string Zip_Code { get; set; }
        public string id { get; set; }
    }

    public class InfoData
    {
        public int? count { get; set; }
        public bool? more_records { get; set; }
    }

}
