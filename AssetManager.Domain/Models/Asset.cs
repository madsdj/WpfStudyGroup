using System;
using Solid;

namespace AssetManager.Domain.Models
{
    public abstract class Asset
    {
        protected Asset(Guid id, string name, decimal capacity)
        {
            if (id == Guid.Empty) throw new ArgumentEmptyGuidException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name == string.Empty) throw new ArgumentEmptyStringException(nameof(name));

            Id = id;
            Name = name;
            Capacity = capacity;
        }

        public Guid Id { get; }
        public string Name { get; }
        public decimal Capacity { get; }
    }
}
