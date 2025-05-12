namespace OBL_Zoho.Models.Response
{
    public class CpAssignResponse
    {
        public CpAssignResponse()
        {
            Data = new List<CpAssign>();
        }
        public List<CpAssign> Data { get; set; }
    }
    public class CpAssign
    {
        public string code { get; set; }
        public CpAssignDetails details { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }
    public class CpAssignDetails
    {
        public DateTime Modified_Time { get; set; }
        public CpAssignModifiedBy Modified_By { get; set; }
        public DateTime Created_Time { get; set; }
        public string id { get; set; }
        public CpAssignCreatedBy Created_By { get; set; }
    }

    public class CpAssignModifiedBy
    {
        public string name { get; set; }
        public string id { get; set; }
    }
    public class CpAssignCreatedBy
    {
        public string name { get; set; }
        public string id { get; set; }
    }
}
