using AssetManagement.Models;

namespace AssetManagement.Repository
{
    public interface IAssetRepository
    {
        public Task<IEnumerable<AssetDefinition>> GetAllAssets();
        public Task<AssetDefinition> AddAssetDefinition(AssetDefinition assetDefinition);
        public  Task<AssetDefinition> UpdateAssetDefinition(int id, AssetDefinition assetDefinition);
    }
}
