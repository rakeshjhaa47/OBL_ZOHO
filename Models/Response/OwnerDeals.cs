namespace OBL_Zoho.Models.Response
{
    public class OwnerDealsRequest
    {
        public List<UpdateOwnerDealRequest> data { get; set; }
    }
    public class OwnerDealResponse
    {
        public List<OwnerDeal> data { get; set; }
    }
    public class UpdateOwnerDealRequest
    {
        public string Sales_Person_Email_ID { get; set; }
        public string Sales_Person_Emp_ID { get; set; }
        public string Sales_Person_Name { get; set; }
        public string Sales_Person_Phone { get; set; }
        public string Branch_Area { get; set; }
        public string id { get; set; }
    }

    public class OwnerDeal
    {
        public string code { get; set; }
        public Details details { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }

    public class Details
    {
        public DateTime Modified_Time { get; set; }
        public DealsModifiedBy Modified_By { get; set; }
        public DateTime Created_Time { get; set; }
        public string id { get; set; }
        public DealsCreatedBy Created_By { get; set; }
    }
    public class DealsCreatedBy
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class DealsModifiedBy
    {
        public string name { get; set; }
        public string id { get; set; }
    }
}
