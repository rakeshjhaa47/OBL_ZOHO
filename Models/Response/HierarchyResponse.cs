namespace OBL_Zoho.Models.Response
{
    public class HierarchyResponse
    {
        public string Code { get; set; }
        public HierarchyDetails Details { get; set; }
        public string Message { get; set; }
    }

    public class HierarchyDetails
    {
        public string Output { get; set; }
        public List<string> UserMessage { get; set; }
        public string Output_Type { get; set; }
        public string Id { get; set; }
    }
}
