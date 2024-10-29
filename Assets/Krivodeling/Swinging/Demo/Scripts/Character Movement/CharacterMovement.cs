using UnityEngine;

namespace Krivodeling.Swinging.Demo
{
    public sealed class CharacterMovement : MonoBehaviour
    {
        public bool IsMove { get; private set; }

        private void Update()
        {
            IsMove = Input.GetKey(KeyCode.W);
        }
    }
}
