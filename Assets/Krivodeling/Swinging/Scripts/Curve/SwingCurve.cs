using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Krivodeling.Swinging
{
    [Serializable, HideReferenceObjectPicker]
    public sealed class SwingCurve
    {
        [field: SerializeField, HorizontalGroup, HideLabel, HideReferenceObjectPicker] public AnimationCurve Curve { get; set; }
        [field: SerializeField, HorizontalGroup(Width = 110f)] public float Speed { get; set; }
        [field: SerializeField, HorizontalGroup(Width = 110f)] public float Multiplier { get; set; }

        private float _time;

        public SwingCurve(AnimationCurve curve, float speed, float multiplier)
        {
            Curve = curve;
            Speed = speed;
            Multiplier = multiplier;
        }

        public SwingCurve()
            : this(AnimationCurve.Linear(0f, 0f, 1f, 0f), 1f, 1f)
        {

        }

        public void Update(float extraSpeed)
        {
            _time += Speed * extraSpeed * Time.deltaTime;
        }

        public void Update()
        {
            Update(1f);
        }

        public float Evaluate()
        {
            return Curve.Evaluate(_time) * Multiplier;
        }
    }
}
