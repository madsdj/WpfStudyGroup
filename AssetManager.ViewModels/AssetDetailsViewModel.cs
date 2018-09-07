using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
