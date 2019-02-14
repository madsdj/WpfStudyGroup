namespace Solid
{
    public interface IMaybe
    {
        object Value { get; }
        bool HasValue { get; }
    }
}
