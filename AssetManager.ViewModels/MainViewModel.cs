using System;
using System.Collections.Immutable;
using System.Linq;
using AssetManager.Domain.Repositories;
using Mvvm;

namespace AssetManager.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly IAssetRepository _assetRepository;
        private readonly AssetViewModel.Factory _assetViewModelFactory;
        private readonly AssetDetailsViewModel.Factory _assetDetailsViewModelFactory;

        public MainViewModel(IAssetRepository assetRepository, IColorSchemeManager colorSchemeManager, AssetViewModel.Factory assetViewModelFactory, AssetDetailsViewModel.Factory assetDetailsViewModelFactory)
        {
            _assetRepository = assetRepository ?? throw new ArgumentNullException(nameof(assetRepository));
            ColorSchemeManager = colorSchemeManager ?? throw new ArgumentNullException(nameof(colorSchemeManager));
            _assetViewModelFactory = assetViewModelFactory ?? throw new ArgumentNullException(nameof(assetViewModelFactory));
            _assetDetailsViewModelFactory = assetDetailsViewModelFactory ?? throw new ArgumentNullException(nameof(assetDetailsViewModelFactory));
        }

        public IColorSchemeManager ColorSchemeManager { get; }
        public IImmutableList<AssetViewModel> Assets => _assetRepository
            .GetAll()
            .Select(a => _assetViewModelFactory(a))
            .ToImmutableList();

        private AssetViewModel _selectedAsset;
        public AssetViewModel SelectedAsset
        {
            get { return _selectedAsset; }
            set
            {
                if (Set(ref _selectedAsset, value))
                {
                    SelectedAssetDetails = value != null ? _assetDetailsViewModelFactory(value.Model) : null;
                }
            }
        }

        private AssetDetailsViewModel _selectedAssetDetails;
        public AssetDetailsViewModel SelectedAssetDetails
        {
            get { return _selectedAssetDetails; }
            private set { Set(ref _selectedAssetDetails, value); }
        }
    }
}
