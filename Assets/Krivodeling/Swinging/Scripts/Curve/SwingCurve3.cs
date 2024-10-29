using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Krivodeling.Swinging
{
    [Serializable, HideReferenceObjectPicker]
    public sealed class SwingCurve3
    {
        [field: SerializeField, HideLabel, SuffixLabel("X")] public SwingCurve CurveX { get; set; } = new();
        [field: SerializeField, HideLabel, SuffixLabel("Y")] public SwingCurve CurveY { get; set; } = new();
        [field: SerializeField, HideLabel, SuffixLabel("Z")] public SwingCurve CurveZ { get; set; } = new();
        [field: SerializeField, HorizontalGroup] public float Speed { get; set; } = 1f;
        [field: SerializeField, HorizontalGroup] public float Multiplier { get; set; } = 1f;

        public void Update(float extraSpeed)
        {
            float finalSpeed = Speed * extraSpeed;

            CurveX.Update(finalSpeed);
            CurveY.Update(finalSpeed);
            CurveZ.Update(finalSpeed);
        }

        public void Update()
        {
            Update(1f);
        }

        public Vector3 Evaluate()
        {
            float x = Evaluate(CurveX);
            float y = Evaluate(CurveY);
            float z = Evaluate(CurveZ);

            return new(x, y, z);
        }

        private float Evaluate(SwingCurve curve)
        {
            return curve.Evaluate() * Multiplier;
        }
    }
}
