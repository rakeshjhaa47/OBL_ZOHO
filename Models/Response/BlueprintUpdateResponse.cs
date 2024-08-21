using Newtonsoft.Json;

namespace OBL_Zoho.Models.Response
{
#nullable disable

    /*Closed Won*/
    public class BlueprintUpdateRequest_ClosedWon
    {
        public List<BlueprintUpdate_ClosedWon> blueprint { get; set; }
    }

    public class BlueprintUpdate_ClosedWon
    {
        public string transition_id { get; set; }
        public BlueprintDataUpdate_ClosedWon data { get; set; }
    }
    public class Attachment
    {
        [JsonProperty("$file_id")]
        public List<string> file_id { get; set; }

        [JsonProperty("$link_url")]
        public string link_url { get; set; }
    }
    public class BlueprintDataUpdate_ClosedWon
    {
        public List<Attachment> Attachments { get; set; }
        public int Amount { get; set; }
        public string Dealer_Name { get; set; }
        public string Purchase_Date { get; set; }
        public string Closing_Date { get; set; }
        public string Lead_Response_Medium_Whatsapp_Email_B2B_L2_Calli { get; set; }
        public string Dealer_Type { get; set; }
        public string Notes { get; set; }
    }

    /*Closed Lost*/
    public class BlueprintUpdateRequest_ClosedLost
    {
        public List<BlueprintUpdate_ClosedLost> blueprint { get; set; }
    }

    public class BlueprintUpdate_ClosedLost
    {
        public string transition_id { get; set; }
        public BlueprintDataUpdate_ClosedLost data { get; set; }
    }

    public class BlueprintDataUpdate_ClosedLost
    {
        public string Sales_Person_Status { get; set; }
        public string Sales_Person_Customer_Remarks { get; set; }
        public string Closing_Date { get; set; }
        public string Notes { get; set; }
    }

    /*Quotation shared*/
    public class BlueprintUpdateRequest_QuotationShared
    {
        public List<BlueprintUpdate_QuotationShared> blueprint { get; set; }
    }

    public class BlueprintUpdate_QuotationShared
    {
        public string transition_id { get; set; }
        public BlueprintDataUpdate_QuotationShared data { get; set; }
    }

    public class BlueprintDataUpdate_QuotationShared
    {
        public string Remarks_of_quotation_shared { get; set; }
        public string Notes { get; set; }
    }

    /*Sample shared*/
    public class BlueprintUpdateRequest_SampleShared
    {
        public List<BlueprintUpdate_SampleShared> blueprint { get; set; }
    }

    public class BlueprintUpdate_SampleShared
    {
        public string transition_id { get; set; }
        public BlueprintDataUpdate_SampleShared data { get; set; }
    }

    public class BlueprintDataUpdate_SampleShared
    {
        public string Remarks_of_Sample_shared { get; set; }
        public string Notes { get; set; }
    }

    /*Visited store*/
    public class BlueprintUpdateRequest_VisitedStore
    {
        public List<BlueprintUpdate_VisitedStore> blueprint { get; set; }
    }

    public class BlueprintUpdate_VisitedStore
    {
        public string transition_id { get; set; }
        public BlueprintDataUpdate_VisitedStore data { get; set; }
    }

    public class BlueprintDataUpdate_VisitedStore
    {
        public string Remarks_spoken_to_customer { get; set; }
        public string Notes { get; set; }
    }

    /*Sales person pitch*/
    public class BlueprintUpdateRequest_SalesPersonPitch
    {
        public List<BlueprintUpdate_SalesPersonPitch> blueprint { get; set; }
    }

    public class BlueprintUpdate_SalesPersonPitch
    {
        public string transition_id { get; set; }
        public BlueprintDataUpdate_SalesPersonPitch data { get; set; }
    }

    public class BlueprintDataUpdate_SalesPersonPitch
    {
        public string Notes { get; set; }
        public string Remarks_spoken_to_customer { get; set; }
    }

    /*Schedule visit*/
    public class BlueprintUpdateRequest_ScheduleVisit
    {
        public List<BlueprintUpdate_ScheduleVisit> blueprint { get; set; }
    }

    public class BlueprintUpdate_ScheduleVisit
    {
        public string transition_id { get; set; }
        public BlueprintDataUpdate_ScheduleVisit data { get; set; }
    }

    public class BlueprintDataUpdate_ScheduleVisit
    {
        public string Notes { get; set; }
    }


    public class BlueprintUpdateResponse
    {
        public string code { get; set; }
        public BlueprintUpdateDetails details { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }

    public class BlueprintUpdateDetails
    {
        //public validation_error validation_error { get; set; }
    }

    public class validation_error
    {
        public string api_name { get; set; }
        public string message { get; set; }
        public string info_message { get; set; }
    }


    public class BlueprintUpdateRequest_JunkLead
    {
        public List<BlueprintUpdate_JunkLead> blueprint { get; set; }
    }

    public class BlueprintUpdate_JunkLead
    {
        public string transition_id { get; set; }
        public BlueprintDataUpdate_JunkLead data { get; set; }
    }

    public class BlueprintDataUpdate_JunkLead
    {
        public string Reason_of_Junk_Leads { get; set; }
    }

    public class BlueprintUpdateRequest_NonContactableLead
    {
        public List<BlueprintUpdate_NonContactableLead> blueprint { get; set; }
    }

    public class BlueprintUpdate_NonContactableLead
    {
        public string transition_id { get; set; }
        
    }

}
