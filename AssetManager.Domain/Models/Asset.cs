using System;

namespace AssetManager.Domain.Models
{
    public abstract class Asset
    {
        protected Asset(Guid id, string name, decimal capacity)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
        }

        public Guid Id { get; }
        public string Name { get; }
        public decimal Capacity { get; }
    }
}
