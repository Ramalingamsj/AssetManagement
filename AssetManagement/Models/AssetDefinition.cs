using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AssetManagement.Models;

public partial class AssetDefinition
{
    public int AssetDid { get; set; }

    public string? AssetDname { get; set; }

    public int? AssetTypeId { get; set; }

    public string? AssetDclass { get; set; }
    [JsonIgnore]
    public virtual ICollection<AssetMaster> AssetMasters { get; set; } = new List<AssetMaster>();

    public virtual AssetType? AssetType { get; set; }
    [JsonIgnore]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
