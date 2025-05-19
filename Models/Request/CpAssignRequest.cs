namespace OBL_Zoho.Models.Request
{
    public class CpAssignRequest
    {
        //public CpAssignRequest()
        //{
        //    Data = new List<CpAssignRequestData>();
        //}
        public List<CpAssignRequestData> data { get; set; }
    }

    public class CpAssignRequestData
    {
        public string id { get; set; }
        public string assigned_CP_By_Agent { get; set; }
        public string assigned_CP_Name { get; set; }
    }
}
