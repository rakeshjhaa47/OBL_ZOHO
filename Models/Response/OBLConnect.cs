using System.Reflection;
using System.Text.Json.Serialization;

namespace OBL_Zoho.Models.Response
{
    public class OBLConnect
    {

        public OBLConnect()
        {
            data = new List<OBLData>();
            info = new OBLInfo();
        }

        public List<OBLData> data { get; set; }
        public OBLInfo info { get; set; }
    }
    public class OBLData
    {
        public string Sales_Person_Email_ID { get; set; }
        public string Assigned_CP_By_Agent { get; set; }
        public decimal? Tile_Requirement_in_Area_Sq_ft { get; set; }
        public DateTime Created_Time { get; set; }
        public decimal? Amount { get; set; }
        public string? City { get; set; }
        public DateTime? Tiling_Date_Likely_Purchase_Date { get; set; }
        public string PCH_Email_ID { get; set; }
        public decimal? Mobile { get; set; }
        public DateTime? Closing_Date { get; set; }
        public string? Dealer_Name { get; set; }
        public string Deal_Name { get; set; }
        public string Stage { get; set; }
        public string? Zip_Code { get; set; }
        public string id { get; set; }

        public string MobileNumber
        {
            get => Mobile?.ToString() ?? string.Empty;
            set
            {
                // Attempt to parse string to decimal, leave null if invalid
                if (decimal.TryParse(value, out var parsedValue))
                {
                    Mobile = parsedValue;
                }
                else
                {
                    Mobile = null; // Or handle accordingly if you expect a default
                }
            }
        }
    }

    public class OBLInfo
    {
        public int count { get; set; }
        public bool more_records { get; set; }
    }

    



}
