using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
