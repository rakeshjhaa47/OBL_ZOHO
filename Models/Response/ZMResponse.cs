namespace OBL_Zoho.Models.Response
{
    public class ZMResponse
    {
        public List<ZonalManagerData> data { get; set; }
    }
    public class ZonalManagerData
    {
        public string ZM_Name { get; set; }
        public string ZM_Code { get; set; }
        public string id { get; set; }
        public object ZM_Mail_ID { get; set; }
    }

}
