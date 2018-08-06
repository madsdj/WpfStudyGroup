namespace AssetManager.ViewModels
{
    public enum ColorScheme
    {
        Dark,
        Light,
        Blue,
        Pink
    }

    public interface IColorSchemeManager
    {
        ColorScheme Current { get; set; }
    }
}
