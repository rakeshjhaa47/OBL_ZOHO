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

    }
}