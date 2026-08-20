//namespace OBL_Zoho.Models.Response
//{
//    public class ChatBotResponse
//    {
//        public string? Assigned_CP_By_Agent { get; set; }
//        public DateTime? CP_Allocated_Date { get; set; }
//        public string? Category { get; set; }
//        public DateTime? Created_Time { get; set; }
//        public List<string>? Sizes_Shortlisted { get; set; }
//        public int? Amount { get; set; }
//        public double? Tile_Requirement_in_Area_Sq_Mtr { get; set; }
//        public string? Stage_Category { get; set; }
//        public string? Assigned_CP_Name { get; set; }
//        public string? Sales_Person_Name { get; set; }
//        public DateTime? Closing_Date { get; set; }
//        public double? Volume_In_Sq_Mtr { get; set; }
//        public string? Sales_Person_Emp_ID { get; set; }
//        public string? Deal_Name { get; set; }
//        public string? Stage { get; set; }
//        public string? id { get; set; }
//    }



//    public class ChatBotInfo
//    {
//        public int count { get; set; }
//        public bool more_records { get; set; }
//    }

//    public class ChatBotRoot
//    {
//        public ChatBotRoot()
//        {
//            Data = new List<ChatBotResponse>();
//            Info = new ChatBotInfo();
//        }
//        public List<ChatBotResponse> Data { get; set; }
//        public ChatBotInfo Info { get; set; }
//    }
//}



using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
    public class ChatBotResponse
    {
        [JsonProperty("Parent_Id.id")]
        public string? Parent_Id_id { get; set; }

        [JsonProperty("Parent_Id.Sales_Person_Emp_ID")]
        public string? Parent_Id_Sales_Person_Emp_ID { get; set; }

        [JsonProperty("Parent_Id.Sales_Person_Name")]
        public string? Parent_Id_Sales_Person_Name { get; set; }

        [JsonProperty("Parent_Id.Assigned_CP_By_Agent")]
        public string? Parent_Id_Assigned_CP_By_Agent { get; set; }

        [JsonProperty("Parent_Id.Assigned_CP_Name")]
        public string? Parent_Id_Assigned_CP_Name { get; set; }

        [JsonProperty("Parent_Id.Deal_Name")]
        public string? Parent_Id_Deal_Name { get; set; }

        [JsonProperty("Parent_Id.Tile_Requirement_in_Area_Sq_Mtr")]
        public double? Parent_Id_Tile_Requirement_in_Area_Sq_Mtr { get; set; }

        [JsonProperty("Parent_Id.Amount")]
        public int? Parent_Id_Amount { get; set; }

        [JsonProperty("Parent_Id.CP_Allocated_Date")]
        public DateTime? Parent_Id_CP_Allocated_Date { get; set; }

        [JsonProperty("Parent_Id.Stage")]
        public string? Parent_Id_Stage { get; set; }

        [JsonProperty("Parent_Id.Closing_Date")]
        public DateTime? Parent_Id_Closing_Date { get; set; }

        [JsonProperty("Parent_Id.Volume_In_Sq_Mtr")]
        public double? Parent_Id_Volume_In_Sq_Mtr { get; set; }

        [JsonProperty("Parent_Id.Created_Time")]
        public DateTime? Parent_Id_Created_Time { get; set; }

        [JsonProperty("Parent_Id.Sizes_Shortlisted")]
        public List<string>? Parent_Id_Sizes_Shortlisted { get; set; }

        [JsonProperty("Parent_Id.Category")]
        public string? Parent_Id_Category { get; set; }

        [JsonProperty("Parent_Id.Stage_Category")]
        public string? Parent_Id_Stage_Category { get; set; }

        [JsonProperty("Parent_Id.Zone")]
        public string? Parent_Id_Zone { get; set; }

        [JsonProperty("Parent_Id.Branch_Area")]
        public string? Parent_Id_Branch_Area { get; set; }

        // Normal fields
        [JsonProperty("Category")]
        public string? Category { get; set; }

        [JsonProperty("Size")]
        public string? Size { get; set; }

        [JsonProperty("Box")]
        public int? Box { get; set; }

        [JsonProperty("Sq_Mt")]
        public double? Sq_Mt { get; set; }

        [JsonProperty("Entry_Date")]
        public DateTime? Entry_Date { get; set; }

        [JsonProperty("id")]
        public string? id { get; set; }
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

    public class ChatBotGroupedResponse
    {
        public string? id { get; set; }
        public List<string>? Sizes_Shortlisted { get; set; }
        public string? Stage_Category { get; set; }
        public string? Assigned_CP_By_Agent { get; set; }
        public string? Zone { get; set; }
        public DateTime? CP_Allocated_Date { get; set; }
        public string? Stage { get; set; }
        public int? Amount { get; set; }
        public double? Volume_In_Sq_Mtr { get; set; }
        public string? Assigned_CP_Name { get; set; }
        public string? Branch_Area { get; set; }
        public string? Sales_Person_Name { get; set; }
        public double? Tile_Requirement_in_Area_Sq_Mtr { get; set; }
        public string? Sales_Person_Emp_ID { get; set; }
        public DateTime? Created_Time { get; set; }
        public string? Deal_Name { get; set; }
        public string? Category { get; set; }
        public DateTime? Closing_Date { get; set; }

        public List<ChatBotCategoryDetail> Category_Details_from_APP { get; set; } = new();
    }

    public class ChatBotCategoryDetail
    {
        public string? id { get; set; }
        public string? Category { get; set; }
        public string? Size { get; set; }
        public int? Box { get; set; }
        public double? Sq_Mt { get; set; }
        public DateTime? Entry_Date { get; set; }
    }

    public class ChatBotDealResponse
    {
        public string? id { get; set; }

        public string? Sales_Person_Emp_ID { get; set; }

        public string? Sales_Person_Name { get; set; }

        public string? Assigned_CP_By_Agent { get; set; }

        public string? Assigned_CP_Name { get; set; }

        public string? Deal_Name { get; set; }

        public double? Tile_Requirement_in_Area_Sq_Mtr { get; set; }

        public int? Amount { get; set; }

        public DateTime? CP_Allocated_Date { get; set; }

        public string? Stage { get; set; }

        public DateTime? Closing_Date { get; set; }

        public double? Volume_In_Sq_Mtr { get; set; }

        public DateTime? Created_Time { get; set; }

        public List<string>? Sizes_Shortlisted { get; set; }

        public string? Category { get; set; }

        public string? Stage_Category { get; set; }

        public string? Zone { get; set; }

        public string? Branch_Area { get; set; }
    }

    public class ChatBotDealsRoot
    {
        public ChatBotDealsRoot()
        {
            data = new List<ChatBotDealResponse>();
            info = new ChatBotInfo();
        }

        public List<ChatBotDealResponse> data { get; set; }

        public ChatBotInfo info { get; set; }
    }
}

