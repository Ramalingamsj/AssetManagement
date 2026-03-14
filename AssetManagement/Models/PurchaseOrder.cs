using System;
using System.Collections.Generic;

namespace AssetManagement.Models;

public partial class PurchaseOrder
{
    public int PurchaseId { get; set; }

    public string? OrderNo { get; set; }

    public int? AssetDid { get; set; }

    public int? AssetTypeId { get; set; }

    public int? Quantity { get; set; }

    public int? VendorId { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public string? PurchaseStatus { get; set; }

    public virtual AssetDefinition? AssetD { get; set; }

    public virtual AssetType? AssetType { get; set; }

    public virtual Vendor? Vendor { get; set; }
}
