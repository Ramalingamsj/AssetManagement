using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AssetManagement.Models;

public partial class AssetType
{
    public int AssetTypeId { get; set; }

    public string? AssetName { get; set; }

    [JsonIgnore]
    public virtual ICollection<AssetDefinition> AssetDefinitions { get; set; } = new List<AssetDefinition>();

    [JsonIgnore]
    public virtual ICollection<AssetMaster> AssetMasters { get; set; } = new List<AssetMaster>();

    [JsonIgnore]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
    [JsonIgnore]
    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
