using UnityEngine;

namespace Krivodeling.Swinging
{
    public abstract class TransitableTransformSwinger<TSwing> : MonoBehaviour, ITransformSwinger where TSwing : TransitableSwing
    {
        protected TSwing PreviousSwing { get; set; }
        protected TSwing CurrentSwing { get; set; }

        void ITransformSwinger.Apply(ref ModifiableTransform transform, in SwingMultiplier multiplier)
        {
            OnApply(ref transform, multiplier);
        }

        protected virtual void OnApply(ref ModifiableTransform transform, in SwingMultiplier multiplier)
        {
            
        }

        protected virtual void SetSwing(TSwing swing)
        {
            if (CurrentSwing == swing)
                return;

            PreviousSwing = CurrentSwing;
            CurrentSwing = swing;

            PreviousSwing?.Exit();
            CurrentSwing.Enter();
        }
    }
}
