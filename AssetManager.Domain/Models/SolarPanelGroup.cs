using System;

namespace AssetManager.Domain.Models
{
    public class SolarPanelGroup : Asset
    {
        public SolarPanelGroup(Guid id, string name, decimal capacity, int panelCount, decimal horizontalTilt, decimal compassOrientation)
            : base(id: id, name: name, capacity: capacity)
        {
            PanelCount = panelCount;
            HorizontalTilt = horizontalTilt;
            CompassOrientation = compassOrientation;
        }

        public int PanelCount { get; }
        public decimal HorizontalTilt { get; }
        public decimal CompassOrientation { get; }
    }
}
