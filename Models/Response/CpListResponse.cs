using System.Text.Json.Serialization;

namespace OBL_Zoho.Models.Response
{
    public class CpListResponse
    {
        public CpListResponse()
        {
            Data = new List<CpList>();
            Info = new CpListInfo();
        }
        public List<CpList> Data { get; set; }
        public CpListInfo Info { get; set; }
    }

    public class CpList
    {
        public string Id { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        public string Cp_Code { get; set; }
        [JsonIgnore]
        public string CP_Name { get; set; }
        public string Assigned_CP_Name { get; set; }

    }
    public class CpListInfo
    {
        public int Count { get; set; }
        public bool More_Records { get; set; }
    }
}
