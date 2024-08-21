namespace OBL_Zoho.Models.Response
{
    public class DataByZMCodeResponse
    {
        public List<DataByZMCode> data { get; set; }
        public Info info { get; set; }
    }

    public class DataByZMCode
    {
        public string BH_Emp_ID { get; set; }
        public string BH_Name { get; set; }
        public string Sales_Person_Email { get; set; }
        public string id { get; set; }
        public string Sales_Person_Name { get; set; }
        public object BH_mail_ID { get; set; }
        public string Name { get; set; }
    }
}
