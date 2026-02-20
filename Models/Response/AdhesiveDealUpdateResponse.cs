namespace OBL_Zoho.Models.Response
{
    public class AdhesiveDealUpdateResponse
    {
        public List<AdhesiveDealUpdateData> data { get; set; }
    }

    public class AdhesiveDealUpdateData
    {
        public string code { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public AdhesiveDealUpdateDetails details { get; set; }
    }

    public class AdhesiveDealUpdateDetails
    {
        public string id { get; set; }
        public string Modified_Time { get; set; }
        public string Created_Time { get; set; }
        public AdhesiveDealUpdateUser Modified_By { get; set; }
        public AdhesiveDealUpdateUser Created_By { get; set; }
    }

    public class AdhesiveDealUpdateUser
    {
        public string name { get; set; }
        public string id { get; set; }
    }
}