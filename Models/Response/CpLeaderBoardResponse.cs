namespace OBL_Zoho.Models.Response
{
    public class CpLeaderBoardResponse
    {
        public CpLeaderBoardResponse()
        {
            Data = new List<CpLeaderBoardData>();
            Info = new CpLeaderBoardDataInfo();
        }
        public List<CpLeaderBoardData> Data { get; set; }
        public CpLeaderBoardDataInfo Info { get; set; }
    }

    public class CpLeaderBoardData
    {
        public string Ranking { get; set; }
        public string CP_Name { get; set; } 
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class CpLeaderBoardDataInfo
    {
        public int Count { get; set; }
        public bool More_Records { get; set; }
    }
}
