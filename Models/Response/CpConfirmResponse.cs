namespace OBL_Zoho.Models.Response
{
    public class CpConfirmResponse
    {

        public CpConfirmResponse()
        {
            data = new List<CpData>();
            info = new CpInfo();
        }
        public List<CpData> data { get; set; }
        public CpInfo info { get; set; }
    }

    public class CpData
    {
        public int Amount { get; set; }
        public string id { get; set; }
        public string Assigned_CP_Name { get; set; }
        public string Closing_Date { get; set; }
    }

    public class CpInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    


}
