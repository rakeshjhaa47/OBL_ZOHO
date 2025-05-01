using DocumentFormat.OpenXml.EMMA;

namespace OBL_Zoho.Models.Response
{
    public class CpPendingConfirmationResponse
    {
        public CpPendingConfirmationResponse()
        {
            Data = new List<CpPendingConfirmation>();
            Info = new CpPendingConfirmationInfo();
        }
        public List<CpPendingConfirmation> Data { get; set; }
        public CpPendingConfirmationInfo Info { get; set; }
    }
    public class CpPendingConfirmation
    {
        public string CP_Confirmed_the_Sale { get; set; }
        public string Deal_Name { get; set; }
        public decimal? Amount { get; set; }
        public string Id { get; set; }
        public string Assigned_CP_Name { get; set; }
        public DateTime? Closing_Date { get; set; }
        public string Sales_Person_Name { get; set; }
        public decimal? Volume_In_Sq_Mtr { get; set; }
    }

    public class CpPendingConfirmationInfo
    {
        public int Count { get; set; }
        public bool More_Records { get; set; }
    }
}
