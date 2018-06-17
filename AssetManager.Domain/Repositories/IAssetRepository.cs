using System.Collections.Immutable;
using AssetManager.Domain.Models;

namespace AssetManager.Domain.Repositories
{
    public interface IAssetRepository
    {
        IImmutableList<Asset> GetAll();
    }
}
