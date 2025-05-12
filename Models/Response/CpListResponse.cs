namespace OBL_Zoho.Models.Response
{
    public class CpListResponse
    {
        public CpListResponse()
        {
            Data = new List<CpList>();
            Info = new CpListInfo();
        }
        public List<CpList> Data { get; set; }
        public CpListInfo Info { get; set; }
    }

    public class CpList
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
    public class CpListInfo
    {
        public int Count { get; set; }
        public bool More_Records { get; set; }
    }
}
