using System;
using UnityEngine;

namespace Krivodeling.Swinging.Demo
{
    [Serializable]
    public sealed class CharacterSwing : TransitableSwing
    {
        [field: SerializeField] public SwingCurve3 PositionCurve { get; private set; } = new();
        [field: SerializeField] public BlendMode BlendMode { get; private set; } = BlendMode.Add;
    }
}
