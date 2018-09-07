using System;
using System.Timers;
using AssetManager.Domain.Models;
using AssetManager.Domain.Repositories;
using Mvvm;

namespace AssetManager.ViewModels
{
    public class AssetViewModel : ObservableObject
    {
        public delegate AssetViewModel Factory(Asset model);

        private readonly IAssetStateRepository _assetStateRepository;
        private readonly Timer _timer = new Timer(1000);

        public AssetViewModel(Asset model, IAssetStateRepository assetStateRepository)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            _assetStateRepository = assetStateRepository ?? throw new ArgumentNullException(nameof(assetStateRepository));

            _timer.Elapsed += (s, e) => RaisePropertyChanged(nameof(CurrentState));
            _timer.Start();
        }

        public Asset Model { get; }

        public AssetState CurrentState => _assetStateRepository.Get(Model.Id);
    }
}
