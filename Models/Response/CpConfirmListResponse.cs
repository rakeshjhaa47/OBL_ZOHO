namespace OBL_Zoho.Models.Response
{
    public class CpConfirmListResponse
    {
        public CpConfirmListResponse()
        {
            data = new List<DataCpList>();
            info = new InfoCpList();
        }
        public List<DataCpList> data { get; set; }
        public InfoCpList info { get; set; }
    }

    public class DataCpList
    {
        public object CP_Confirmed_the_Sale { get; set; }
        public string Deal_Name { get; set; }
        public int Amount { get; set; }
        public string id { get; set; }
        public string Assigned_CP_Name { get; set; }
        public string Closing_Date { get; set; }
        public string Sales_Person_Name { get; set; }
    }

    public class InfoCpList
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    


}
