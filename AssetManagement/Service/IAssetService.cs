using AssetManagement.Models;

namespace AssetManagement.Service
{
    public interface IAssetService
    {
        public Task<IEnumerable<AssetDefinition>> GetAllAssetsService();
            public Task<AssetDefinition> AddAssetDefinitionService(AssetDefinition assetDefinition);
            public  Task<AssetDefinition> UpdateAssetDefinitionService(int id, AssetDefinition assetDefinition);
    }
}
