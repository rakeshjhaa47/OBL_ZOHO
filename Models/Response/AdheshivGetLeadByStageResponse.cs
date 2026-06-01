namespace OBL_Zoho.Models.Response
{
    public class AdheshivGetLeadByStageDatum
    {
       // public string Adhesive_Type { get; set; }
        public List<string> Adhesive_Type1 { get; set; }
        public string contactName { get; set; }
        public DateTime Created_Time { get; set; }
        public string Adhesive_Sales_Person_Name { get; set; }
        public string Stage { get; set; }
        public string Stage_Category { get; set; }
        public string id { get; set; }
        public object City { get; set; }
        public int? Qty_required { get; set; }
        public int? Qty_delivered { get; set; }
        public object Mobile { get; set; }
        public string Adhesive_Sales_Person_Emp_ID { get; set; }
        public string Closing_Date { get; set; }
        public object Closed_By { get; set; }
    }

    public class AdheshivGetLeadByStageInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    public class AdheshivGetLeadByStage
    {
        public AdheshivGetLeadByStage()
        {
            data = new List<AdheshivGetLeadByStageDatum>();
            info = new AdheshivGetLeadByStageInfo();
        }
        public List<AdheshivGetLeadByStageDatum> data { get; set; }
        public AdheshivGetLeadByStageInfo info { get; set; }
    }


}