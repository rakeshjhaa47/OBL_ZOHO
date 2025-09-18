
namespace OBL_Zoho.Models.Response
{
    public class FLSLeaderboardResponse
    {
        public FLSLeaderboardResponse()
        {
            Data = new List<FLSLeaderboardData>();
            Info = new FLSLeaderboardDataInfo();
        }
        public List<FLSLeaderboardData> Data { get; set; }
        public FLSLeaderboardDataInfo Info { get; set; }
    }

    public class FLSLeaderboardData
    {
        public decimal Total_Amount { get; set; }
        public string Sales_Person_Emp_ID { get; set; }
        public string BM_Code { get; set; }
        public string Name { get; set; }
    }

    public class FLSLeaderboardDataInfo
    {
        public int Count { get; set; }
        public bool More_Records { get; set; }
    }
}

