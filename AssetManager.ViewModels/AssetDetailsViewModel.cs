using System;
using System.Windows.Input;
using AssetManager.Domain.Models;
using AssetManager.Domain.Repositories;
using AssetManager.Domain.Services;
using Mvvm;

namespace AssetManager.ViewModels
{
    public class AssetDetailsViewModel : ObservableObject
    {
        public delegate AssetDetailsViewModel Factory(Asset model);

        private readonly IRemoteControlService _remoteControlService;
        private readonly IAssetStateRepository _assetStateRepository;

        public AssetDetailsViewModel(Asset model, IRemoteControlService remoteControlService, IAssetStateRepository assetStateRepository)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            _remoteControlService = remoteControlService ?? throw new ArgumentNullException(nameof(remoteControlService));
            _assetStateRepository = assetStateRepository ?? throw new ArgumentNullException(nameof(assetStateRepository));
        }

        public Asset Model { get; }

        public ICommand StartCommand => new RelayCommand(Start, () => _assetStateRepository.Get(Model.Id) == AssetState.Offline);

        public void Start()
        {
            _remoteControlService.Start(Model.Id);
        }

        public ICommand StopCommand => new RelayCommand(Stop, () => _assetStateRepository.Get(Model.Id) == AssetState.Online);

        public void Stop()
        {
            _remoteControlService.Stop(Model.Id);
        }
    }
}
