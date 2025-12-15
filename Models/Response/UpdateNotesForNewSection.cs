namespace OBL_Zoho.Models.Response
{
    public class UpdateNotesForNewSection
    {
        public string id { get; set; }
        public List<Timeline> Timelines { get; set; }
    }

    public class Timeline
    {
        public string Name1 { get; set; }
        public string Emp_Id { get; set; }    
        public string L1_Notes { get; set; }
        public string Remarks { get; set; }
        public string Types { get; set; }
        public string Updated_Stage { get; set; }
        public string timelineType { get; set; }
    }

    public class ProjectOpportunityUpdate
    {
        public string id { get; set; }
        public List<Timeline> Timelines { get; set; }
    }

    public class UpdateProjectOpportunityRequest
    {
        public List<ProjectOpportunityUpdate> data { get; set; }
    }

    public class UpdateProjectOpportunityResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public List<ResponseData> data { get; set; }
    }

    public class ResponseData
    {
        public string code { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public ResponseDetails details { get; set; }
    }

    public class ResponseDetails
    {
        public string id { get; set; }
        public string Modified_Time { get; set; }
        public User Modified_By { get; set; }
        public string Created_Time { get; set; }
        public User Created_By { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string id { get; set; }
    }
}
