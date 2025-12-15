using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
    public class ProjectInstallmentCreatedBy
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class ProjectInstallmentDatum
    {
        public string code { get; set; }
        public ProjectInstallmentDetails details { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }

    public class ProjectInstallmentDetails
    {
        public DateTime Modified_Time { get; set; }
        public ProjectInstallmentModifiedBy Modified_By { get; set; }
        public DateTime Created_Time { get; set; }
        public string id { get; set; }
        public ProjectInstallmentCreatedBy Created_By { get; set; }

        [JsonProperty("$approval_state")]
        public string approval_state { get; set; }
    }

    public class ProjectInstallmentModifiedBy
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class ProjectInstallmentResponse
    {
        public List<ProjectInstallmentDatum> data { get; set; }
    }
}
