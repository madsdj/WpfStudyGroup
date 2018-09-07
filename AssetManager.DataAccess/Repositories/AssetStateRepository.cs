using System;
using System.Collections.Generic;
using AssetManager.Domain.Models;
using AssetManager.Domain.Repositories;
using AssetManager.Domain.Services;

namespace AssetManager.DataAccess.Repositories
{
    public class AssetStateRepository : IAssetStateRepository, IRemoteControlService
    {
        private readonly Dictionary<Guid, AssetState> _states = new Dictionary<Guid, AssetState>();

        public AssetState Get(Guid assetId)
        {
            if (_states.TryGetValue(assetId, out AssetState state)) return state;
            return AssetState.Online;
        }

        public void Start(Guid assetId)
        {
            _states[assetId] = AssetState.Online;
        }

        public void Stop(Guid assetId)
        {
            _states[assetId] = AssetState.Offline;
        }
    }
}
