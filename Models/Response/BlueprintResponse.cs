namespace OBL_Zoho.Models.Response
{
#nullable disable

    public class BlueprintResponse
    {
        public Blueprint blueprint { get; set; }
    }

    public class Blueprint
    {
        public ProcessInfo process_info { get; set; }
        public List<Transitions> transitions { get; set; }
    }

    public class ProcessInfo
    {
        public string field_id { get; set; }
        public string escalation { get; set; }
        public bool is_continous { get; set; }
        public string api_name { get; set; }
        public bool continous { get; set; }
        public string field_label { get; set; }
        public string name { get; set; }
        public string column_name { get; set; }
        public string field_value { get; set; }
        public string id { get; set; }
        public string field_name { get; set; }
    }

    public class Transitions
    {
        public List<string> next_transitions { get; set; }
        public BPData data { get; set; }
        public string type { get; set; }
        public string criteria_message { get; set; }
        public string execution_time { get; set; }
        public int sequence { get; set; }
        public string next_field_value { get; set; }
        public string name { get; set; }
        public bool criteria_matched { get; set; }
        public string id { get; set; }
        public string parent_transition { get; set; }
        public List<Fields> fields { get; set; }
        public int percent_partial_save { get; set; }
    }

    public class BPData
    {
        public List<string> Attachments { get; set; }
    }

    public class Fields
    {
        public bool webhook { get; set; }
        public bool colour_code_enabled_by_system { get; set; }
        public Criteria criteria { get; set; }
        public string field_label { get; set; }
        public string tooltip { get; set; }
        public string type { get; set; }
        public Layouts layouts { get; set; }
        public bool field_read_only { get; set; }
        public string display_label { get; set; }
        public bool read_only { get; set; }
        public string association_details { get; set; }
        public MultiModuleLookup multi_module_lookup { get; set; }
        public string id { get; set; }
        public string created_time { get; set; }
        public bool filterable { get; set; }
        public bool visible { get; set; }
        public List<Profiles> profiles { get; set; }
        public ViewType view_type { get; set; }
        public bool separator { get; set; }
        public bool searchable { get; set; }
        public string external { get; set; }
        public string api_name { get; set; }
        public Unique unique { get; set; }
        public bool enable_colour_code { get; set; }
        public List<PickListValue> pick_list_values { get; set; }
        public bool system_mandatory { get; set; }
        public bool virtual_field { get; set; }
        public string json_type { get; set; }
        public string crypt { get; set; }
        public string created_source { get; set; }
        public string content { get; set; }
        public int display_type { get; set; }
        public int ui_type { get; set; }
        public string validation_rule { get; set; }
        public string modified_time { get; set; }
        public EmailParser email_parser { get; set; }
        public Currency currency { get; set; }
        public bool custom_field { get; set; }
        public Lookup lookup { get; set; }
        public int length { get; set; }
        public string column_name { get; set; }
        public string _type { get; set; }
        public bool display_field { get; set; }
        public bool pick_list_values_sorted_lexically { get; set; }
        public bool sortable { get; set; }
        public int transition_sequence { get; set; }
        public string global_picklist { get; set; }
        public string history_tracking { get; set; }
        public string data_type { get; set; }
        public Formula formula { get; set; }
        public string decimal_place { get; set; }
        public MultiSelectLookup multiselectlookup { get; set; }
        public AutoNumber auto_number { get; set; }
    }

    public class Criteria
    {
        public string comparator { get; set; }
        public string field { get; set; }
        public string value { get; set; }
    }

    public class Layouts
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class MultiModuleLookup
    {
    }

    public class Profiles
    {
        public string permission_type { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class ViewType
    {
        public bool view { get; set; }
        public bool edit { get; set; }
        public bool quick_create { get; set; }
        public bool create { get; set; }
    }

    public class Unique
    {
    }

    public class EmailParser
    {
        public bool fields_update_supported { get; set; }
        public bool record_operations_supported { get; set; }
    }

    public class Currency
    {
    }

    public class Lookup
    {
    }

    public class Formula
    {
    }

    public class MultiSelectLookup
    {
    }

    public class AutoNumber
    {
    }

    public class PickListValue
    {
        public string display_value { get; set; }
        public string sequence_number { get; set; }
        public List<string> maps { get; set; }
        public string colour_code { get; set; }
        public string actual_value { get; set; }
        public string id { get; set; }
        public string type { get; set; }

    }

    public class TransitionList
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class SKUs_B2B
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class content
    {
        public string id { get; set; }
        public SKUs_B2B SKUs_B2B { get; set; }
    }

}
