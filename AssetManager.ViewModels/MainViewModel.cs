using System;
using System.Collections.Immutable;
using AssetManager.Domain.Models;
using AssetManager.Domain.Repositories;
using Mvvm;

namespace AssetManager.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly IAssetRepository _assetRepository;

        public MainViewModel(IAssetRepository assetRepository, IColorSchemeManager colorSchemeManager)
        {
            _assetRepository = assetRepository ?? throw new ArgumentNullException(nameof(assetRepository));
            ColorSchemeManager = colorSchemeManager ?? throw new ArgumentNullException(nameof(colorSchemeManager));
        }

        public IColorSchemeManager ColorSchemeManager { get; }
        public IImmutableList<Asset> Assets => _assetRepository.GetAll();

        private Asset _selectedAsset;
        public Asset SelectedAsset
        {
            get { return _selectedAsset; }
            set { Set(ref _selectedAsset, value); }
        }
    }
}
