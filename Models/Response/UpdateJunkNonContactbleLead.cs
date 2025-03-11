namespace OBL_Zoho.Models.Response
{
    public class UpdateJunkNonContactbleLead
    {
        public class UpdateRequestNonContactbleJunkLead
        {
            public List<UpdateNonContactbleJunkLead> blueprint { get; set; }
        }
        public class UpdateNonContactbleJunkLead
        {
            public string transition_id { get; set; }
            public UpdateDataUpdate_JunkLead data { get; set; }
        }

        public class UpdateDataUpdate_JunkLead
        {
            public string Reason_of_Non_Contactable { get; set; }
        }
    }
}
