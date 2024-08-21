namespace OBL_Zoho.Models.Response
{
    public class SalesResponse
    {
        public List<SalesEmployeeData> data { get; set; }
    }
    public class SalesEmployeeData
    {
        public string Sales_Person_Name { get; set; }
        public string Name { get; set; }
        public string id { get; set; }
        public object Sales_Person_Email { get; set; }
    }
}
