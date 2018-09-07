using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AssetManager.Domain.Models;
using Mvvm;

namespace AssetManager.ViewModels
{
    public class AssetDetailsViewModel : ObservableObject
    {
        public delegate AssetDetailsViewModel Factory(Asset model);

        public AssetDetailsViewModel(Asset model)
        {
            Model = model;
        }

        public Asset Model { get; }

        public ICommand StartCommand => new RelayCommand(Start);

        public void Start()
        {
            throw new NotImplementedException();
        }

        public ICommand StopCommand => new RelayCommand(Stop);

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
