namespace OBL_Zoho.Models.Response
{
    namespace OBL_Zoho.Models.Response
    {
        public class ZohoSurveyResponse
        {
            public string Code { get; set; }
            public SurveyDetails Details { get; set; }
            public string Message { get; set; }
        }


        public class SurveyDetails
        {
            public string Output { get; set; }
            public List<string> UserMessage { get; set; }
            public string Output_Type { get; set; }
            public string Id { get; set; }
        }
    }
}
