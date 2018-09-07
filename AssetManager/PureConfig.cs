using AssetManager.DataAccess.Repositories;
using AssetManager.Domain.Repositories;
using AssetManager.ViewModels;
using AssetManager.Views;

namespace AssetManager
{
    public static class PureConfig
    {
        public static MainViewModel ResolveMainViewModel()
        {
            IColorSchemeManager colorSchemeManager = new ColorSchemeManager();
            IAssetRepository assetRepository = new AssetRepository();
            AssetStateRepository assetStateRepository = new AssetStateRepository();
            return new MainViewModel(assetRepository, colorSchemeManager, a => new AssetViewModel(a, assetStateRepository), a => new AssetDetailsViewModel(a, assetStateRepository));
        }
    }
}
