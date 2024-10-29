using UnityEngine;

namespace Krivodeling.Swinging.Demo
{
    public sealed class CharacterMovementSwinger : TransitableTransformSwinger<CharacterSwing>
    {
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private CharacterStats _characterStats;
        [SerializeField] private CharacterSwing _idleSwing = new();
        [SerializeField] private CharacterSwing _moveSwing = new();
        [SerializeField] private BlendMode _transitionBlendMode = BlendMode.Add;

        protected override void OnApply(ref ModifiableTransform transform, in SwingMultiplier multiplier)
        {
            _idleSwing.PositionCurve.Update(_characterStats.Respiration * multiplier.Speed);
            _moveSwing.PositionCurve.Update(multiplier.Speed);

            SetSwing(_characterMovement.IsMove ? _moveSwing : _idleSwing);

            var previousNewPosition = PreviousSwing == null
                ? Vector3.zero
                : multiplier.Evaluation * PreviousSwing.Attenuation * PreviousSwing.PositionCurve.Evaluate();
            var currentNewPosition = CurrentSwing.Attenuation * multiplier.Evaluation * CurrentSwing.PositionCurve.Evaluate();
            var newPosition = Blender.Blend(previousNewPosition, currentNewPosition, _transitionBlendMode);

            transform.LocalPosition = Blender.Blend(transform.LocalPosition, newPosition, CurrentSwing.BlendMode);
        }

        private void Awake()
        {
            if (_characterMovement == null)
                _characterMovement = FindAnyObjectByType<CharacterMovement>();

            if (_characterStats == null)
                _characterStats = FindAnyObjectByType<CharacterStats>();
        }
    }
}
