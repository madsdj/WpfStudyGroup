using System;
using System.Windows.Input;
using AssetManager.Domain.Models;
using AssetManager.Domain.Services;
using Mvvm;

namespace AssetManager.ViewModels
{
    public class AssetDetailsViewModel : ObservableObject
    {
        public delegate AssetDetailsViewModel Factory(Asset model);

        private readonly IRemoteControlService _remoteControlService;

        public AssetDetailsViewModel(Asset model, IRemoteControlService remoteControlService)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            _remoteControlService = remoteControlService ?? throw new ArgumentNullException(nameof(remoteControlService));
        }

        public Asset Model { get; }

        public ICommand StartCommand => new RelayCommand(Start);

        public void Start()
        {
            _remoteControlService.Start(Model.Id);
        }

        public ICommand StopCommand => new RelayCommand(Stop);

        public void Stop()
        {
            _remoteControlService.Stop(Model.Id);
        }
    }
}
