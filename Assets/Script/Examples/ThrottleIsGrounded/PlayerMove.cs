using UnityEngine;

namespace UniRxExamples
{
    //プレイヤを操作する
    [RequireComponent(typeof(ObjectMover))]
    public class PlayerMove : MonoBehaviour
    {
        private ObjectMover _objectMover;
        private CharacterController _characterController;

        [SerializeField]
        private float moveSpeed = 2;

        private void Start()
        {
            _objectMover = GetComponent<ObjectMover>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            var normalizedInputVector = inputVector.normalized;

            _objectMover.MoveHorizontal(normalizedInputVector * moveSpeed);

            if (Input.GetButtonDown("Jump") && _characterController.isGrounded)
            {
                _objectMover.Jump(15);
            }
        }
    }
}