using Newtonsoft.Json;

public class Approval
{
    public bool @delegate { get; set; }
    public bool takeover { get; set; }
    public bool approve { get; set; }
    public bool reject { get; set; }
    public bool recall { get; set; }
    public bool resubmit { get; set; }
}

public class GetLeadDetailsDatum
{
    public GetLeadDetailsOwner? Owner { get; set; }

    [JsonProperty("$currency_symbol")]
    public string? currency_symbol { get; set; }
    public int? Recieved_Amount { get; set; }
    public object? Final_Requirement_Closed { get; set; }

    [JsonProperty("$field_states")]
    public object? field_states { get; set; }
    public string? Stage_Category { get; set; }
    public string? Contact_City { get; set; }

    [JsonProperty("$sharing_permission")]
    public string? sharing_permission { get; set; }
    public string? Project_Name { get; set; }
    public string? Name { get; set; }
    public DateTime? Last_Activity_Time { get; set; }
    public string? Sales_person_Branch { get; set; }
    public object? Unsubscribed_Mode { get; set; }

    [JsonProperty("$process_flow")]
    public bool? process_flow { get; set; }
    public string? Lost_to { get; set; }

    [JsonProperty("$locked_for_me")]
    public bool? locked_for_me { get; set; }
    public string? id { get; set; }
    public string? Salesperson_Zone { get; set; }

    [JsonProperty("$approval")]
    public Approval? approval { get; set; }
    public DateTime? Created_Time { get; set; }
    public bool? IsConverted { get; set; }
    public string? Lost_Lead { get; set; }
    public int? Tile_Requirment_in_sqmt { get; set; }

    [JsonProperty("$wizard_connection_path")]
    public object? wizard_connection_path { get; set; }

    [JsonProperty("$editable")]
    public bool? editable { get; set; }
    public string? City { get; set; }
    public string? Contact_Person_Details { get; set; }
    public int? Contact_Pin_Code { get; set; }
    public string? State { get; set; }
    public string? Tiling_Month { get; set; }
    public string? Lead_Updation_Stage { get; set; }

    [JsonProperty("$zia_owner_assignment")]
    public string? zia_owner_assignment { get; set; }
    public int? Pincode { get; set; }
    public string? Sales_Person_Email { get; set; }

    [JsonProperty("$review_process")]
    public GetLeadDetailsReviewProcess? review_process { get; set; }

    [JsonProperty("$layout_id")]
    public GetLeadDetailsLayoutId? layout_id { get; set; }
    public string? Closing_Date { get; set; }
    public object? Record_Image { get; set; }

    [JsonProperty("$review")]
    public object? review { get; set; }
    public string? Contact_Number { get; set; }

    [JsonProperty("$zia_visions")]
    public object? zia_visions { get; set; }
    public List<GetLeadDetailsTimeline>? Timelines { get; set; }
    public DateTime? Modified_Time { get; set; }
    public string? Project_Category { get; set; }
    public string? Contact_State { get; set; }
    public object? Unsubscribed_Time { get; set; }
    public string? Salesperson_Name { get; set; }
    public int? Amount { get; set; }
    public string? Contact_Person_Name { get; set; }
    public string? Record_Status__s { get; set; }

    [JsonProperty("$orchestration")]
    public bool? orchestration { get; set; }
    public string? Sales_Person_Emp_Id { get; set; }

    [JsonProperty("$in_merge")]
    public bool? in_merge { get; set; }
    public bool? Locked__s { get; set; }
    public List<object>? Tag { get; set; }

    [JsonProperty("$approval_state")]
    public string? approval_state { get; set; }

    [JsonProperty("$pathfinder")]
    public bool? pathfinder { get; set; }

    [JsonProperty("$has_more")]
    public GetLeadDetailsHasMore? has_more { get; set; }
    [JsonProperty("PMT_No")]
    public string? Pmt_No { get; set; }
}

public class GetLeadDetailsHasMore
{
    public bool Timelines { get; set; }
}

public class GetLeadDetailsLayoutId
{
    public string? display_label { get; set; }
    public string? name { get; set; }
    public string? id { get; set; }
}

public class GetLeadDetailsOwner
{
    public string? name { get; set; }
    public string? id { get; set; }
    public string? email { get; set; }
}

public class GetLeadDetailsParentId
{
    public string? name { get; set; }
    public string? id { get; set; }
}

public class GetLeadDetailsReviewProcess
{
    public bool? approve { get; set; }
    public bool? reject { get; set; }
    public bool? resubmit { get; set; }
}

public class GetLeadDetailsRoot
{
    public List<GetLeadDetailsDatum> data { get; set; }
}

public class GetLeadDetailsTimeline
{
    public string? Types { get; set; }
    public string? L1_Notes { get; set; }
    public DateTime? Modified_Time { get; set; }
    public string? Remarks { get; set; }
    public string? Updated_Stage { get; set; }

    [JsonProperty("$in_merge")]
    public bool? in_merge { get; set; }

    [JsonProperty("$field_states")]
    public object? field_states { get; set; }
    public DateTime? Created_Time { get; set; }
    public DateTime? nextFollowUpDate { get; set; }
    public GetLeadDetailsParentId? Parent_Id { get; set; }
    public string? id { get; set; }

    [JsonProperty("$layout_id")]
    public GetLeadDetailsLayoutId? layout_id { get; set; }

    [JsonProperty("$zia_visions")]
    public object? zia_visions { get; set; }
    public string? Name1 { get; set; }
    public string? timelineType { get; set; }
}
