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

        public MainViewModel(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository ?? throw new ArgumentNullException(nameof(assetRepository));
        }

        public IImmutableList<Asset> Assets => _assetRepository.GetAll();

        private Asset _selectedAsset;
        public Asset SelectedAsset
        {
            get { return _selectedAsset; }
            set { if (_selectedAsset != value) { _selectedAsset = value; RaisePropertyChanged(); } }
        }
    }
}
