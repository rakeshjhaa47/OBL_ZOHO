using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
    public class AdhesiveDealUpdateResponse
    {
        public List<AdhesiveDealUpdateData> Data { get; set; }
    }

    public class AdhesiveDealUpdateData
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public AdhesiveDealUpdateDetails Details { get; set; }
    }

    public class AdhesiveDealUpdateDetails
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("modified_time")]
        public string Modified_Time { get; set; }
    }
}
