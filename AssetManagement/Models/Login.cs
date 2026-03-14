using System;
using System.Collections.Generic;

namespace AssetManagement.Models;

public partial class Login
{
    public int Lid { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? UserTypeId { get; set; }

    public virtual UserType? UserType { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
