using System;

namespace AssetManager.Domain.Models
{
    public class WindTurbine : Asset
    {
        public WindTurbine(Guid id, string name, decimal capacity, decimal hubHeight, decimal rotorDiameter)
            : base(id: id, name: name, capacity: capacity)
        {
            HubHeight = hubHeight;
            RotorDiameter = rotorDiameter;
        }

        public decimal HubHeight { get; }
        public decimal RotorDiameter { get; }
    }
}
