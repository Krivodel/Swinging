using UnityEngine;

namespace Krivodeling.Swinging.Demo
{
    public sealed class CharacterStatsSwinger : MonoBehaviour, ITransformSwinger
    {
        [SerializeField] private CharacterStats _characterStats;
        [SerializeField] private SwingCurve3 _positionCurve = new();
        [SerializeField] private BlendMode _blendMode = BlendMode.Add;

        void ITransformSwinger.Apply(ref ModifiableTransform transform, in SwingMultiplier multiplier)
        {
            _positionCurve.Update(_characterStats.Respiration * multiplier.Speed);

            var offset = _characterStats.Stress * multiplier.Evaluation * _positionCurve.Evaluate();

            transform.LocalPosition = Blender.Blend(transform.LocalPosition, offset, _blendMode);
        }

        private void Awake()
        {
            if (_characterStats == null)
                _characterStats = FindAnyObjectByType<CharacterStats>();
        }
    }
}
