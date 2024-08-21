namespace OBL_Zoho.Models.Response
{

    public class BMResponse
    {
        public List<BranchManagerData> data { get; set; }
    }
    public class BranchManagerData
    {
        public string BH_Name { get; set; }
        public string BH_mail_ID { get; set; }
        public string id { get; set; }
        public object BH_Emp_ID { get; set; }
    }
}
