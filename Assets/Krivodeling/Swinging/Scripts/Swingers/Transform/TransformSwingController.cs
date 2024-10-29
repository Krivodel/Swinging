using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Krivodeling.Swinging
{
    public sealed class TransformSwingController : SerializedMonoBehaviour
    {
        public SwingMultiplierCollection Multipliers { get; } = new();

        [SerializeField] private Transform _transform;
        [SerializeField] private float _sharpness = 10f;
        [SerializeField] private List<ITransformSwinger> _swingers = new();

        private TransformData _startTransformData;

        public void AddSwinger(ITransformSwinger swinger)
        {
            _swingers.Add(swinger);
        }

        public void RemoveSwinger(ITransformSwinger swinger)
        {
            _swingers.Remove(swinger);
        }

        public void Apply()
        {
            ModifiableTransform modifiableTransform = new(_transform, _startTransformData);
            var multiplier = Multipliers.Calculate();

            for (int i = 0; i < _swingers.Count; i++)
                _swingers[i].Apply(ref modifiableTransform, multiplier);

            _transform.GetLocalPositionAndRotation(out var currentPosition, out var currentRotation);

            var sharpness = _sharpness * Time.deltaTime;
            var newPosition = Vector3.Lerp(currentPosition, modifiableTransform.LocalPosition, sharpness);
            var newRotation = Quaternion.Lerp(currentRotation, modifiableTransform.LocalRotation, sharpness);

            _transform.SetLocalPositionAndRotation(newPosition, newRotation);
        }

        private void Awake()
        {
            if (_transform == null)
                _transform = GetComponent<Transform>();

            transform.GetLocalPositionAndRotation(out var position, out var rotation);

            _startTransformData = new(position, rotation);
        }

        private void Update()
        {
            Apply();
        }
    }
}
