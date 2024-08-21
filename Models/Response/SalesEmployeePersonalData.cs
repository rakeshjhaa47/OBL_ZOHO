namespace OBL_Zoho.Models.Response
{
    public class SalesEmployeePersonalDataResponse
    {
        public List<SalesEmployeePersonalData> data { get; set; }
    }
    public class SalesEmployeePersonalData
    {
        public string BH_Emp_ID { get; set; }
        public string ZH_Name { get; set; }
        public object ZM_Mail_ID { get; set; }
        public string ZM_Name { get; set; }
        public object ZH_Email_ID { get; set; }
        public string BH_Name { get; set; }
        public string ZH_Code { get; set; }
        public string ZM_Code { get; set; }
        public string id { get; set; }
        public object BH_mail_ID { get; set; }
    }
}
