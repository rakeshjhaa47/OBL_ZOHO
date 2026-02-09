namespace OBL_Zoho.Models.Response
{
    public class DeviceIdAndPlatformResponse
    {
        public string code { get; set; }
        public DeviceIdAndPlatformDetails details { get; set; }
        public string message { get; set; }
    }

    public class DeviceIdAndPlatformDetails
    {
        public string output { get; set; }
        public List<string> userMessage { get; set; }
        public string output_type { get; set; }
        public string id { get; set; }
    }
}
