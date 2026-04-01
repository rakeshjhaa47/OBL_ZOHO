using Newtonsoft.Json;

public class AdhesiveSalesPersonID
{
    public string? name { get; set; }
    public string? id { get; set; }
}

public class AdhesiveApproval
{
    public bool? @delegate { get; set; }
    public bool? takeover { get; set; }
    public bool? approve { get; set; }
    public bool? reject { get; set; }
    public bool? recall { get; set; }
    public bool? resubmit { get; set; }
}

public class CreatedBy
{
    public string? name { get; set; }
    public string? id { get; set; }
    public string? email { get; set; }
}

public class Owner
{
    public string? name { get; set; }
    public string? id { get; set; }
    public string? email { get; set; }
}

public class ModifiedBy
{
    public string? name { get; set; }
    public string? id { get; set; }
    public string? email { get; set; }
}

public class ParentId
{
    public string? name { get; set; }
    public string? id { get; set; }
}

public class ReviewProcess
{
    public bool? approve { get; set; }
    public bool? reject { get; set; }
    public bool? resubmit { get; set; }
}

public class AdhesiveLayout
{
    public string? display_label { get; set; }
    public string? name { get; set; }
    public string? id { get; set; }
}

public class LayoutId
{
    public string? display_label { get; set; }
    public string? name { get; set; }
    public string? id { get; set; }
}

public class HasMore
{
    public bool? Timleline { get; set; }
    public bool? OrderConfirmation_SKU_B2B { get; set; }
    public bool? Category_Details_from_APP { get; set; }
    public bool? SKUs_B2B { get; set; }
    public bool? Sales_Person_Notes { get; set; }
}

public class Timleline
{
    public string? Emp_id { get; set; }
    public string? L1_Notes { get; set; }
    public string? Types { get; set; }
    public DateTime? Modified_Time { get; set; }
    public object? nextFollowUpDate { get; set; }

    [JsonProperty("$field_states")]
    public object? field_states { get; set; }

    public DateTime? Created_Time { get; set; }
    public ParentId? Parent_Id { get; set; }

    [JsonProperty("$layout_id")]
    public LayoutId? layout_id { get; set; }

    public int? timelineType { get; set; }
    public AdhesiveLayout? Layout { get; set; }
    public string? Updated_Stage { get; set; }
    public string? Remarks { get; set; }

    [JsonProperty("$in_merge")]
    public bool? in_merge { get; set; }

    public string? id { get; set; }

    [JsonProperty("$zia_visions")]
    public object? zia_visions { get; set; }

    public string? Name1 { get; set; }
}

public class Datum
{
    public object? L2_Purchase_Value_if_purchased { get; set; }
    public Owner? Owner { get; set; }
    public object? GCLID { get; set; }
    public object? L2_Owner { get; set; }

    [JsonProperty("$field_states")]
    public object? field_states { get; set; }

    public object? Remarks_of_Junk_Lead { get; set; }
    public object? Tile_Requirement_in_Area_Sq_Mtr { get; set; }
    public object? Recent_Stage_Update_Date_Time { get; set; }
    public object? Qualification_Date { get; set; }
    public object? L2_Call_Status { get; set; }
    public object? Enquiry_Remarks { get; set; }
    public object? Firm_Name { get; set; }

    [JsonProperty("$process_flow")]
    public bool? process_flow { get; set; }

    public string? Closed_Through_App { get; set; }
    public string? Stage { get; set; }

    [JsonProperty("$approval")]
    public AdhesiveApproval? approval { get; set; }

    public int? Cost_per_Click { get; set; }
    public string? CP_Allocated_Date { get; set; }
    public string? Previously_Assigned_CP { get; set; }

    public DateTime? Qualification_Stage_Change_Date { get; set; }

    [JsonProperty("$review_process")]
    public ReviewProcess? review_process { get; set; }

    public List<object>? SKUs_B2B { get; set; }

    [JsonProperty("$orchestration")]
    public bool? orchestration { get; set; }

    public AdhesiveLayout? Layout { get; set; }

    [JsonProperty("$pathfinder")]
    public bool? pathfinder { get; set; }

    public List<Timleline>? Timleline { get; set; }

    [JsonProperty("$currency_symbol")]
    public string? currency_symbol { get; set; }

    public string? Stage_Category { get; set; }
    public DateTime? Last_Activity_Time { get; set; }
    public string? Deal_Name { get; set; }

    public int? Qty_required { get; set; }
    public bool? Cx_Confirmed_Sale { get; set; }

    [JsonProperty("$zia_owner_assignment")]
    public string? zia_owner_assignment { get; set; }

    public string? Closed_By_FLS_CP { get; set; }

    [JsonProperty("$layout_id")]
    public LayoutId? layout_id { get; set; }

    public string? Closing_Date { get; set; }
    public int? Cost_per_Conversion { get; set; }

    public ModifiedBy? Modified_By { get; set; }

    [JsonProperty("$review")]
    public object? review { get; set; }

    public DateTime? Modified_Time { get; set; }
    public string? Days_Difference { get; set; }

    [JsonProperty("$in_merge")]
    public bool? in_merge { get; set; }

    [JsonProperty("$approval_state")]
    public string? approval_state { get; set; }

    [JsonProperty("$sharing_permission")]
    public string? sharing_permission { get; set; }

    public int? Final_Tile_Requirement_in_Area_Sq_ft { get; set; }

    public string? id { get; set; }
    public DateTime? Created_Time { get; set; }
    public DateTime? Change_Log_Time__s { get; set; }

    public bool? Order_Confirmation_Email_Alert { get; set; }

    public CreatedBy? Created_By { get; set; }

    public AdhesiveSalesPersonID? Adhesive_SalesPerson_ID { get; set; }

    public int? Overall_Sales_Duration { get; set; }
    public bool? Converted_Opportunity { get; set; }

    public string? Record_Status__s { get; set; }
    public bool? Locked__s { get; set; }

    public List<object>? Tag { get; set; }

    public string? Adhesive_Sales_Person_Name { get; set; }
    public bool? Physical_Visit_Email_Alert { get; set; }

    public string? CP_Matched_Unmatched { get; set; }

    public string? Adhesive_Sales_Person_Emp_ID { get; set; }

    public int? Volume_In_Sq_Mtr { get; set; }
    public bool? Updated_Record { get; set; }

    public string? Adhesive_Type { get; set; }

    public List<object>? Reasons_of_NPD { get; set; }

    public int? Sales_Cycle_Duration { get; set; }

    public string? Lead_Qualification_Date_Time { get; set; }

    public List<object>? Tile_Category { get; set; }

    public string Mobile { get; set; }

    [JsonProperty("$locked_for_me")]
    public bool? locked_for_me { get; set; }

    [JsonProperty("$editable")]
    public bool? editable { get; set; }

    [JsonProperty("$wizard_connection_path")]
    public object? wizard_connection_path { get; set; }

    [JsonProperty("$has_more")]
    public HasMore? has_more { get; set; }
}

public class AdhesiveGetLeadByIdResponse
{
    public List<Datum>? data { get; set; }
}