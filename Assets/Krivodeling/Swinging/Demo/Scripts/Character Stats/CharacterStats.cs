using UnityEngine;

namespace Krivodeling.Swinging.Demo
{
    public sealed class CharacterStats : MonoBehaviour
    {
        [field: SerializeField, Range(0.5f, 2f)] public float Respiration { get; set; } = 1f;
        [field: SerializeField, Range(0.15f, 1f)] public float Stress { get; set; } = 0.15f;
    }
}
