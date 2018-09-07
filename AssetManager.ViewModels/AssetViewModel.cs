using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManager.Domain.Models;
using Mvvm;

namespace AssetManager.ViewModels
{
    public class AssetViewModel : ObservableObject
    {
        public delegate AssetViewModel Factory(Asset model);

        public AssetViewModel(Asset model)
        {
            Model = model;
        }

        public Asset Model { get; }
    }
}
