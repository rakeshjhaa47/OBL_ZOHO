namespace OBL_Zoho.Models.Response
{
    public class DealerResponse
    {
        public List<DealerData> data { get; set; }
        public Info info { get; set; }
    }

    public class DealerData
    {
        public string Post { get; set; }
        public string Sales_Person_Name { get; set; }
        public string id { get; set; }
    }

    public class DealerInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }
}



