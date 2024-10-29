namespace Krivodeling.Swinging
{
    public interface ITransformSwinger
    {
        void Apply(ref ModifiableTransform transform, in SwingMultiplier multiplier);
    }
}
