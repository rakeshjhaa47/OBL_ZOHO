namespace OBL_Zoho.Models.Response
{
    public class CpConfirmLeadResponse
    {
        public CpConfirmLeadResponse()
        {
            data = new List<CpLeadData>();
            info = new CpLeadInfo();
        }
        public List<CpLeadData> data { get; set; }
        public CpLeadInfo info { get; set; }
    }

    public class CpLeadData
    {
        public string? CP_Confirmed_the_Sale { get; set; }
        public string? Deal_Name { get; set; }
        public int? Amount { get; set; }
        public string? id { get; set; }
        public string? Assigned_CP_Name { get; set; }
        public string? Closing_Date { get; set; }
        public string? Sales_Person_Name { get; set; }

    }

    public class CpLeadInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }
}