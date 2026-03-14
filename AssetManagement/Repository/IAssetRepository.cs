using AssetManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Repository
{
    public interface IAssetRepository
    {
        public Task<ActionResult<IEnumerable<AssetDefinition>>> GetAllAssets();
        public Task<AssetDefinition> AddAssetDefinition(AssetDefinition assetDefinition);
        public  Task<AssetDefinition> UpdateAssetDefinition(int id, AssetDefinition assetDefinition);
    }
}
