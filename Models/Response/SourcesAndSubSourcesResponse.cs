using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
    public class SourcesAndSubSourcesResponse
    {
        public string? First_Name { get; set; }
        public string? Sub_Source { get; set; }
        public string? Last_Name { get; set; }
        public string? Lead_Category { get; set; }
        public string? Lead_Source { get; set; }
        public string? gaconnectorfields1__Pages_Visited { get; set; }
        public string? Zip_Code { get; set; }
        public string? id { get; set; }
        public string? Type_of_Lead { get; set; }
        public string? Mobile { get; set; }
    }

    public class SourcesAndSubSourcesInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    public class SourcesAndSubSourcesRoot
    {
        public SourcesAndSubSourcesRoot()
        {
            data = new List<SourcesAndSubSourcesResponse>();
            info = new SourcesAndSubSourcesInfo();
        }

        public List<SourcesAndSubSourcesResponse> data { get; set; }
        public SourcesAndSubSourcesInfo info { get; set; }
    }
}