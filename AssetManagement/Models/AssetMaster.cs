using System;
using System.Collections.Generic;

namespace AssetManagement.Models;

public partial class AssetMaster
{
    public int AssetMid { get; set; }

    public int? AssetTypeId { get; set; }

    public int? VendorId { get; set; }

    public int? AssetDid { get; set; }

    public string? Model { get; set; }

    public string? Snumber { get; set; }

    public string? Years { get; set; }

    public DateOnly? Updates { get; set; }

    public string? Warranty { get; set; }

    public DateOnly? Amfrom { get; set; }

    public DateOnly? Amto { get; set; }

    public virtual AssetDefinition? AssetD { get; set; }

    public virtual AssetType? AssetType { get; set; }

    public virtual Vendor? Vendor { get; set; }
}
