using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AssetManagementContext _context;
        public AssetRepository(AssetManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AssetDefinition>> GetAllAssets()
        {
            if(_context != null)
            {
                return await _context.AssetDefinitions.ToListAsync();
            }
            return null;
        }

        public async Task<AssetDefinition> AddAssetDefinition(AssetDefinition assetDefinition)
        {
           if(_context != null)
            {
                var asset = await _context.AssetDefinitions.AddAsync(assetDefinition);
                await _context.SaveChangesAsync();  
                return assetDefinition;
            }
            return null;
        }

        public async Task<AssetDefinition> UpdateAssetDefinition(int id,AssetDefinition assetDefinition)
        {
            if (id != assetDefinition.AssetDid)
            {
                throw new ArgumentException("ID Mismatch");
            }
            //Get existing employee
            var existingAsset = await _context.AssetDefinitions.FindAsync(id);

            if (existingAsset == null)
            {
                throw new KeyNotFoundException("Employee Not Found");

            }
            //Update th xisting employee with the values
            _context.Entry(existingAsset).CurrentValues.SetValues(assetDefinition);
            await _context.SaveChangesAsync();

            return existingAsset;
        }
    }
}
