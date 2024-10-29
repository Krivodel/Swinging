using System;
using UnityEngine;

namespace Krivodeling
{
    public static class Blender
    {
        public static float Blend(float a, float b, BlendMode mode)
        {
            return mode switch
            {
                BlendMode.Add => a + b,
                BlendMode.Multiply => a * b,
                BlendMode.Subtract => a - b,
                BlendMode.Average => (a + b) / 2f,
                BlendMode.Max => Mathf.Max(a, b),
                BlendMode.Min => Mathf.Min(a, b),
                _ => throw new NotSupportedException(),
            };
        }

        public static Vector3 Blend(Vector3 a, Vector3 b, BlendMode mode)
        {
            return mode switch
            {
                BlendMode.Add => new(a.x + b.x, a.y + b.y, a.z + b.z),
                BlendMode.Multiply => new(a.x * b.x, a.y * b.y, a.z * b.z),
                BlendMode.Subtract => new(a.x - b.x, a.y - b.y, a.z - b.z),
                BlendMode.Average => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z) / 2f,
                BlendMode.Max => new(Mathf.Max(a.x, b.x), Mathf.Max(a.y, b.y), Mathf.Max(a.z, b.z)),
                BlendMode.Min => new(Mathf.Min(a.x, b.x), Mathf.Min(a.y, b.y), Mathf.Min(a.z, b.z)),
                _ => throw new NotSupportedException(),
            };
        }

        public static Quaternion Blend(Quaternion a, Quaternion b, BlendMode mode)
        {
            return Quaternion.Euler(
                Blend(a.eulerAngles, b.eulerAngles, mode));
        }
    }
}
