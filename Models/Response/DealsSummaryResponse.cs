using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
    public class DealsSummaryResponse
    {
        public List<DealsSummaryData> data { get; set; }
        public DealerInfo info { get; set; } // Reuse the same Info class
    }

    public class DealsSummaryData
    {
        [JsonProperty("COUNT(id)")]
        public int Count { get; set; }

        public string Sales_Person_Emp_ID { get; set; }

        public string Sales_Person_Name { get; set; }
    }
}
