using OBL_Zoho.Models.Response;

namespace OBL_Zoho.Models.Request
{
    public class BlueprintRequest
    {
        public List<BlueprintData> blueprint { get; set; }

    }
    public class BlueprintData
    {
        public string transition_id { get; set; }
        public BlueprintStoreData data { get; set; }
    }

    public class BlueprintStoreData
    {
        public string Remarks_of_visit_store { get; set; }
    }

}
