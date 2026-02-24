namespace OBL_Zoho.Models.Response
{
    public class AdhesiveStageChangeDetails
    {
        public string output { get; set; }
        public List<string> userMessage { get; set; }
        public string output_type { get; set; }
        public string id { get; set; }
    }

    public class AdhesiveStageChangeResponse
    {
        public string code { get; set; }
        public AdhesiveStageChangeDetails details { get; set; }
        public string message { get; set; }
    }
}