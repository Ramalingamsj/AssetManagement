using System;
using System.Collections.Generic;

namespace AssetManagement.Models;

public partial class UserType
{
    public int UserTypeId { get; set; }

    public string? UserType1 { get; set; }

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
