using DG.Tweening;
using UnityEngine;

namespace Krivodeling.Swinging
{
    public abstract class TransitableSwing
    {
        [field: SerializeField] public float EnterDuration { get; private set; } = 0.5f;
        [field: SerializeField] public float ExitDuration { get; private set; } = 0.5f;

        public float Attenuation { get; private set; }

        public void Enter()
        {
            DOVirtual.Float(Attenuation, 1f, EnterDuration, v => Attenuation = v);
        }

        public void Exit()
        {
            DOVirtual.Float(Attenuation, 0f, ExitDuration, v => Attenuation = v);
        }
    }
}
