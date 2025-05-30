using Newtonsoft.Json;
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
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Cp_Code { get; set; }

        [JsonProperty("CP_Name")]
        public string Assigned_CP_Name { get; set; }

        [JsonProperty("Sales_Person.Name")]
        public string Sales_Person_Name { get; set; }

    }
    public class CpListInfo
    {
        public int Count { get; set; }
        public bool More_Records { get; set; }
    }
}
