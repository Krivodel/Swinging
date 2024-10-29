using UnityEngine;

namespace Krivodeling.Swinging
{
    public struct ModifiableTransform
    {
        public readonly Transform Transform;
        public readonly Vector3 StartLocalPosition;
        public readonly Quaternion StartLocalRotation;

        public Vector3 LocalPosition;
        public Quaternion LocalRotation;

        public ModifiableTransform(Transform transform, Vector3 startLocalPosition, Quaternion startLocalRotation)
        {
            Transform = transform;
            StartLocalPosition = startLocalPosition;
            StartLocalRotation = startLocalRotation;

            LocalPosition = StartLocalPosition;
            LocalRotation = StartLocalRotation;
        }

        public ModifiableTransform(Transform transform, TransformData startTransformData)
            : this(transform, startTransformData.Position, startTransformData.Rotation)
        {

        }
    }
}
