using System;
using AssetManager.Domain.Models;

namespace AssetManager.Domain.Repositories
{
    public interface IAssetStateRepository
    {
        AssetState Get(Guid assetId);
    }
}
