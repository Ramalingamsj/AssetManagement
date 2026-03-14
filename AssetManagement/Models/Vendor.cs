using System;
using System.Collections.Generic;

namespace AssetManagement.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string? VendorName { get; set; }

    public string? VendorType { get; set; }

    public int? AssetTypeId { get; set; }

    public DateOnly? VendorFrom { get; set; }

    public DateOnly? VendorTo { get; set; }

    public string? VendorAddress { get; set; }

    public virtual ICollection<AssetMaster> AssetMasters { get; set; } = new List<AssetMaster>();

    public virtual AssetType? AssetType { get; set; }

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
