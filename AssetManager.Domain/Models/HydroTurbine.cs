using System;

namespace AssetManager.Domain.Models
{
    public class HydroTurbine : Asset
    {
        public HydroTurbine(Guid id, string name, decimal capacity, decimal reservoirCapacity)
            : base(id: id, name: name, capacity: capacity)
        {
            ReservoirCapacity = reservoirCapacity;
        }

        public decimal ReservoirCapacity { get; }
    }
}
