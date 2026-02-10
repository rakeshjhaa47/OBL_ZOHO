namespace OBL_Zoho.Models.Response
{
    public class AdhesiveLeadsResponse
    {
        public List<AdhesiveLeadsData> Data { get; set; }
        public AdhesiveLeadsInfo Info { get; set; }
    }

    public class AdhesiveLeadsData
    {
        public string Adhesive_Type { get; set; }
        public string Adhesive_Sales_Person_Name { get; set; }
        public string Stage { get; set; }
        public string Stage_Category { get; set; }
        public string Closing_Date { get; set; }
        public int Qty_required { get; set; }
        public string Adhesive_Sales_Person_Emp_ID { get; set; }
        public string Adhesive_BH_Code { get; set; }
        public string Adhesive_NH_Code { get; set; }
    }

    public class AdhesiveLeadsInfo
    {
        public int Count { get; set; }
        public bool More_Records { get; set; }
    }
}
