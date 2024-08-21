namespace OBL_Zoho.Models.Response
{
#nullable disable
    public class L1
    {
        public List<L1Data> data { get; set; }
        public LeadInfoResponse info { get; set; }
    }

    public class L1Update
    {
        public List<L1Data> data { get; set; }
    }

    public class L1Data
    {
        public string Id { get; set; }
        public string Deal_Name { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Lead_Category { get; set; }
        public List<string> Tile_Category { get; set; }
        public string Tiling_Date_Likely_Purchase_Date { get; set; }
        public string Lead_Number { get; set; }
        public string Contact_Email { get; set; }
        public string L2_Owner { get; set; }
        public string Lead_Qualification_Date_Time { get; set; }
        public string Remarks { get; set; }
        public string Current_Lead_Status { get; set; }
        public string Dealer_Code { get; set; }
        public string BH_Email_Id { get; set; }
        public string BH_Name { get; set; }
        public string Sales_Person { get; set; }

        //public string Lead_Qualification_Date_Time { get; set; }
        //public string Current_Lead_Status { get; set; }
        //public string Tiling_Date { get; set; }
        //public string Status_last_modified { get; set; }
        //public string L2_Owner { get; set; }
        //public string L2_Remarks { get; set; }
        //public string address_line_1 { get; set; }
        //public string address_line_2 { get; set; }
        //public string appointment_date { get; set; }
        //public string lead_status { get; set; }
        //public string converted_amount { get; set; }
        //public string pin_code { get; set; }
        //public string vitrified_area { get; set; }
        //public string purchased_on { get; set; }
        //public string notes_list { get; set; }
        //public string notes_text { get; set; }
        //public string notes_written_by { get; set; }
        //public string notes_writer_designation { get; set; }
        //public string note_date { get; set; }
        //public string lead_from_source { get; set; }
        //public string last_updated { get; set; }
        //public string lead_quallified_date { get; set; }
        //public string amount { get; set; }
    }
}
