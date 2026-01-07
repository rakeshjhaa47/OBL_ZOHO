namespace OBL_Zoho.Models.Response
{
    public class GetLeadByStageForNewSection
    {
        public int? Recieved_Amount { get; set; }
        public string? Sales_Person_Email { get; set; }
        public string? Stage_Category { get; set; }
        public string? Contact_City { get; set; }
        public string? Project_Name { get; set; }
        public string? Closing_Date { get; set; }
        public string? Name { get; set; }
        public string? Sales_person_Branch { get; set; }
        public string? Lost_to { get; set; }
        public string? Contact_Number { get; set; }
        public string? id { get; set; }
        public string? Salesperson_Zone { get; set; }
        public string? Project_Category { get; set; }
        public string? Contact_State { get; set; }
        public DateTime? Created_Time { get; set; }
        public string? Salesperson_Name { get; set; }
        public int? Tile_Requirment_in_sqmt { get; set; }
        public string? City { get; set; }
        public string? Sales_Person_Emp_Id { get; set; }
        public string? Contact_Person_Details { get; set; }
        public int? Contact_Pin_Code { get; set; }  
        public string? State { get; set; }
        public int? estimated_amount { get; set; }
        public string? Lead_Updation_Stage { get; set; }
        public string? Tiling_Month { get; set; }
        public decimal? Final_Requirement_Closed { get; set; }
        public int? Pincode { get; set; }
        public string? Contact_Person_Name { get; set; }
    }
    public class GetLeadByStageForNewSectionInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    public class GetLeadByStageForNewSectionRoot
    {
        public GetLeadByStageForNewSectionRoot()
        {
            data = new List<GetLeadByStageForNewSection>();
            info = new GetLeadByStageForNewSectionInfo();
        }
        public List<GetLeadByStageForNewSection> data { get; set; }
        public GetLeadByStageForNewSectionInfo info { get; set; }
    }
}
