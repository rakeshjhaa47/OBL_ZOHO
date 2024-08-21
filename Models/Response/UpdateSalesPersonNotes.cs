namespace OBL_Zoho.Models.Response
{
    public class UpdateSalesPersonNotes
    {
        public List<Sales_Person_Notes> Sales_Person_Notes { get; set; }
        public string id { get; set; }
    }

    public class UpdateSalesPersonNotesRequest
    {
        public List<SalesPersonNotesUpdate> data { get; set; }
    }

    public class UpdateSalesPersonNotesResponse
    {
        public List<UpdateSalesPersonData> data { get; set; }
    }

    public class SalesPersonNotesUpdate
    {
        public List<Sales_Person_Notes> Sales_Person_Notes { get; set; }
        public string id { get; set; }
    }

    public class UpdateSalesPersonData
    {
        public string code { get; set; }
        public details details { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }
}


