using UnityEngine;

namespace UniRxExamples
{
    public class OnGroundedWithoutUniRx : MonoBehaviour
    {
        private CharacterController _characterController;
        private ParticleSystem _particleSystem;
        private bool oldFlag;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _particleSystem = GetComponentInChildren<ParticleSystem>();

            oldFlag = _characterController.isGrounded;
        }

        private void Update()
        {
            var currentFlag = _characterController.isGrounded;
            if (currentFlag && !oldFlag)
            {
                _particleSystem.Play();
            }
            oldFlag = currentFlag;
        }
    }
}