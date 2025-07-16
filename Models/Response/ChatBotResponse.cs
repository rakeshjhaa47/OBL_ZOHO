namespace OBL_Zoho.Models.Response
{
    public class ChatBotResponse
    {
        public string Assigned_CP_By_Agent { get; set; }
        public object? CP_Allocated_Date { get; set; }
        public string Deal_Name { get; set; }
        public int? Amount { get; set; }
        public object Tile_Requirement_in_Area_Sq_Mtr { get; set; }
        public string Stage { get; set; }
        public string id { get; set; }
        public string Assigned_CP_Name { get; set; }
        public string Sales_Person_Name { get; set; }
        public string Closing_Date { get; set; }
        public string Sales_Person_Emp_ID { get; set; }
    }

   

    public class ChatBotInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    public class ChatBotRoot
    {
        public ChatBotRoot()
        {
            Data = new List<ChatBotResponse>();
            Info = new ChatBotInfo();
        }
        public List<ChatBotResponse> Data { get; set; }
        public ChatBotInfo Info { get; set; }
    }
}
