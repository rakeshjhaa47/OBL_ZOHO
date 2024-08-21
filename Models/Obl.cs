using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace OBL_Zoho.Models;

public partial class Obl
{
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }

    public string? LeadId { get; set; }

    public int? TypeId { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }
    public string DealName { get; set; }
}
