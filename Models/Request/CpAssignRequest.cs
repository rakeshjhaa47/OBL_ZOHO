namespace OBL_Zoho.Models.Request
{
    public class CpAssignRequest
    {
        public CpAssignRequest()
        {
            Data = new List<CpAssignRequestData>();
        }
        public List<CpAssignRequestData> Data { get; set; }
    }

    public class CpAssignRequestData
    {
        public string Id { get; set; }
        public string Assigned_CP_By_Agent { get; set; }
        public string Assigned_CP_Name { get; set; }
    }
}
