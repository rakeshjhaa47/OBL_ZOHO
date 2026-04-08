namespace OBL_Zoho.Models.Request
{
    public class AdhesiveStageChange
    {
        public string lead_id { get; set; }
        public string transition_id { get; set; }
        public string Closing_Date { get; set; }
        public string qty_delivered { get; set; }
        public string nextFollowUpDate { get; set; }
        public int timelineType { get; set; }
        public string remarks { get; set; }
        public string emp_id { get; set; }
        public WonData won_data { get; set; }
    }
    public class WonData
    {
        public decimal won_amount { get; set; }

        public Product Adhesive { get; set; }
        public Product Epoxy { get; set; }
        public Product Grout { get; set; }
    }

    public class Product
    {
        public string type { get; set; }
        public int qty { get; set; }
    }
}