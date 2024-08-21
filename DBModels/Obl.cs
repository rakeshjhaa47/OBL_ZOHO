using System;
using System.Collections.Generic;

namespace OBL_Zoho.DBModels;

public partial class Obl
{
    public int Id { get; set; }

    public string LeadId { get; set; }

    public int? TypeId { get; set; }

    public string Remarks { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public string DealName { get; set; }
}
