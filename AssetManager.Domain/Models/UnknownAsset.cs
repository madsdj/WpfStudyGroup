using System;

namespace AssetManager.Domain.Models
{
    public class UnknownAsset : Asset
    {
        public UnknownAsset(Guid id, string name, decimal capacity)
            : base(id: id, name: name, capacity: capacity)
        {
        }
    }
}
