using UnityEngine;
using UniRx;

namespace UniRxExamples
{
    //クリックされたらジャンプする
    [RequireComponent(typeof (ObjectMover))]
    public class PlayerJump : MonoBehaviour
    {
        private ObjectMover _objectMover;
        private CharacterController _characterController;

        private void Start()
        {

            _objectMover = GetComponent<ObjectMover>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {

            if (Input.GetButtonDown("Jump") && _characterController.isGrounded)
            {
                _objectMover.Jump(15);
            }

        }
    }
}