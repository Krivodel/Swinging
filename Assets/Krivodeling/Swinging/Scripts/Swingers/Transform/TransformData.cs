using UnityEngine;

namespace Krivodeling.Swinging
{
    public readonly struct TransformData
    {
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;

        public TransformData(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}
