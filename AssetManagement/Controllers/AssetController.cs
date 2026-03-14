using AssetManagement.Models;
using AssetManagement.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetDefinition>>> GetAllAssets()
        {
            return await _assetService.GetAllAssetsService();
        }

        [HttpPost]
        public async Task<IActionResult> AddAssetDefinition([FromBody] AssetDefinition assetDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asset = await _assetService.AddAssetDefinitionService(assetDefinition);
            return Ok(asset);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssetDefinition(int id, [FromBody] AssetDefinition assetDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asset = await _assetService.UpdateAssetDefinitionService(id, assetDefinition);

            if (asset == null)
            {
                return NotFound();
            }

            return Ok(asset);
        }
    }
}