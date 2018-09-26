using System;
using System.Collections.Immutable;
using AssetManager.Domain.Models;
using AssetManager.Domain.Repositories;

namespace AssetManager.DataAccess.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        public IImmutableList<Asset> GetAll()
        {
            return ImmutableList.Create<Asset>
            (
                new WindTurbine
                (
                    id: Guid.NewGuid(),
                    name: "WindTurbine 1",
                    capacity: 1,
                    hubHeight: 60,
                    rotorDiameter: 60
                ),
                new WindTurbine
                (
                    id: Guid.NewGuid(),
                    name: "WindTurbine 2",
                    capacity: 1,
                    hubHeight: 60,
                    rotorDiameter: 60
                ),
                new WindTurbine
                (
                    id: Guid.NewGuid(),
                    name: "WindTurbine 3",
                    capacity: 1,
                    hubHeight: 60,
                    rotorDiameter: 60
                ),
                new SolarPanelGroup
                (
                    id: Guid.NewGuid(),
                    name: "SolarPanelGroup 1",
                    capacity: 3,
                    panelCount: 512,
                    horizontalTilt: 45,
                    compassOrientation: 180
                ),
                new SolarPanelGroup
                (
                    id: Guid.NewGuid(),
                    name: "SolarPanelGroup 2",
                    capacity: 2.5M,
                    panelCount: 400,
                    horizontalTilt: 45,
                    compassOrientation: 180
                ),
                new HydroTurbine
                (
                    id: Guid.NewGuid(),
                    name: "HydroTurbine 1",
                    capacity: 2.5M,
                    reservoirCapacity: 100
                ),
                new UnknownAsset
                (
                    id: Guid.NewGuid(),
                    name: "Unknown 1",
                    capacity: 50M
                )
            );
        }
    }
}
