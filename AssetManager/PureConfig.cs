using AssetManager.DataAccess.Repositories;
using AssetManager.Domain.Repositories;
using AssetManager.ViewModels;

namespace AssetManager
{
    public static class PureConfig
    {
        public static MainViewModel ResolveMainViewModel()
        {
            IAssetRepository assetRepository = new AssetRepository();
            return new MainViewModel(assetRepository);
        }
    }
}
