namespace OBL_Zoho.Models.Response
{
    public class AdheshivGetLeadByStage
    {
        public string contactName { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public string Adhesive_Type { get; set; }
        public string Adhesive_Sales_Person_Name { get; set; }
        public string Stage { get; set; }
        public string Stage_Category { get; set; }
        public string id { get; set; }
        public int? Qty_required { get; set; }
        public string Adhesive_Sales_Person_Emp_ID { get; set; }
        public string Closing_Date { get; set; }
        public string Created_Time { get; set; }
    }
    public class AdheshivGetLeadByStageInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }
    public class AdheshivGetLeadByStageResponse
    {
        public AdheshivGetLeadByStageResponse()
        {
            data = new List<AdheshivGetLeadByStage>();
            info = new AdheshivGetLeadByStageInfo();
        }
        public List<AdheshivGetLeadByStage> data { get; set; }
        public AdheshivGetLeadByStageInfo info { get; set; }
    }
}