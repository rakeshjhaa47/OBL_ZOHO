using System;
using System.Collections.Generic;

namespace OBL_Zoho.DBModels;

public partial class AspNetRole
{
    public string Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<AspNetUser> Users { get; set; } = new List<AspNetUser>();
}
