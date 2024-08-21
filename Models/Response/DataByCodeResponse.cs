using OBL_Zoho.Models.Helper;

namespace OBL_Zoho.Models.Response
{
    public class DataByCodeResponse
    {
        public List<AllEmployees> ZH { get; set; }

        public List<AllEmployees> ZM { get; set; }
        public List<AllEmployees> BM { get; set; }
        public List<AllEmployees> Employees { get; set; }
    }
}
