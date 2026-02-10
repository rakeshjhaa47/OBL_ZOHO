namespace OBL_Zoho.Models.Request
{

    public class AdhesiveDealTimelineRequest
    {
        public string Id { get; set; }
        public List<AdhesiveTimeline> Timleline { get; set; }
    }

    public class AdhesiveTimeline
    {
        public string Emp_id { get; set; }
        public string L1_Notes { get; set; }
        public string Name1 { get; set; }
        public string Remarks { get; set; }
        public string timelineType { get; set; }
        public string Types { get; set; }
        public string Updated_Stage { get; set; }
    }
}
