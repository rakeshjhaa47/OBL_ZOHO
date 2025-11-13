using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
    public class SalesPersonResponse
    {
        public string Types { get; set; }
        public string L1_Notes { get; set; }

        [JsonProperty("Parent_Id.Project_Name")]
        public string Parent_IdProject_Name { get; set; }

        [JsonProperty("Parent_Id.Salesperson_Zone")]
        public string Parent_IdSalesperson_Zone { get; set; }

        [JsonProperty("Parent_Id.Tile_Requirment_in_sqmt")]
        public int Parent_IdTile_Requirment_in_sqmt { get; set; }
        public string Remarks { get; set; }

        [JsonProperty("Parent_Id.Sales_Person_Emp_Id")]
        public string Parent_IdSales_Person_Emp_Id { get; set; }

        [JsonProperty("Parent_Id.Owner")]
        public ParentIdOwner Parent_IdOwner { get; set; }
        public string id { get; set; }
        public string Name1 { get; set; }

        [JsonProperty("Parent_Id.Contact_Number")]
        public string Parent_IdContact_Number { get; set; }

        [JsonProperty("Parent_Id.Contact_Person_Details")]
        public string Parent_IdContact_Person_Details { get; set; }

        [JsonProperty("Parent_Id.Sales_person_Branch")]
        public string Parent_IdSales_person_Branch { get; set; }
        public DateTime Created_Time { get; set; }

        [JsonProperty("Parent_Id.Name")]
        public string Parent_IdName { get; set; }

        [JsonProperty("Parent_Id.Contact_Person_Name")]
        public string Parent_IdContact_Person_Name { get; set; }

        [JsonProperty("Parent_Id.Tiling_Month")]
        public string Parent_IdTiling_Month { get; set; }

        [JsonProperty("Parent_Id.Project_Category")]
        public string Parent_IdProject_Category { get; set; }

        [JsonProperty("Parent_Id.Contact_State")]
        public string Parent_IdContact_State { get; set; }

        [JsonProperty("Parent_Id.State")]
        public string Parent_IdState { get; set; }

        [JsonProperty("Parent_Id.City")]
        public string Parent_IdCity { get; set; }

        [JsonProperty("Parent_Id.Contact_City")]
        public string Parent_IdContact_City { get; set; }

        [JsonProperty("Parent_Id.Sales_Person_Email")]
        public string Parent_IdSales_Person_Email { get; set; }

        [JsonProperty("Parent_Id.Pincode")]
        public int Parent_IdPincode { get; set; }

        [JsonProperty("Parent_Id.Contact_Pin_Code")]
        public int Parent_IdContact_Pin_Code { get; set; }
    }

    public class SalesPersonInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    public class ParentIdOwner
    {
        public string id { get; set; }
    }

    public class SalesPersonRoot
    {
        public SalesPersonRoot()
        {
            data = new List<SalesPersonResponse>();
            info = new SalesPersonInfo();
        }
        public List<SalesPersonResponse> data { get; set; }
        public SalesPersonInfo info { get; set; }
    }

}
