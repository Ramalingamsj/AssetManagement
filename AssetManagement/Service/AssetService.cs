using AssetManagement.Models;
using AssetManagement.Repository;

namespace AssetManagement.Service
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }
        public async Task<IEnumerable<AssetDefinition>> GetAllAssetsService()
        {
            return await _assetRepository.GetAllAssets();
        }
        public async Task<AssetDefinition> AddAssetDefinitionService(AssetDefinition assetDefinition)
        {
            return await _assetRepository.AddAssetDefinition(assetDefinition);
        }
        public async Task<AssetDefinition> UpdateAssetDefinitionService(int id, AssetDefinition assetDefinition)
        {
            return await _assetRepository.UpdateAssetDefinition(id, assetDefinition);
        }
    }
}
