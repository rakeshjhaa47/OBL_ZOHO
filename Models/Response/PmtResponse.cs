namespace OBL_Zoho.Models.Response
{
    public class PmtCreatedBy
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class PmtDatum
    {
        public string code { get; set; }
        public PmtDetails details { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }

    public class PmtDetails
    {
        public DateTime Modified_Time { get; set; }
        public PmtModifiedBy Modified_By { get; set; }
        public DateTime Created_Time { get; set; }
        public string id { get; set; }
        public PmtCreatedBy Created_By { get; set; }
    }

    public class PmtModifiedBy
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class PmtResponse
    {
        public List<PmtDatum> data { get; set; }
    }


}
