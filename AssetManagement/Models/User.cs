using System;
using System.Collections.Generic;

namespace AssetManagement.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public int? PhoneNumber { get; set; }

    public int? Lid { get; set; }

    public virtual Login? LidNavigation { get; set; }
}
