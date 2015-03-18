using UniRx;
using UnityEngine;

namespace UniRxExamples
{
    /// <summary>
    /// オブジェクトをCharacterController経由で動かす
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class ObjectMover : TypedMonoBehaviour
    {
        private CharacterController _characterController;
        private Vector3 _moveVector;

        public override void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _moveVector = new Vector3();
        }

        public override void Update()
        {
            var currentVelocity = _characterController.velocity;
            var nextVelocity =
                new Vector3(
                    _moveVector.x,
                    _moveVector.y + currentVelocity.y + Physics.gravity.y * Time.deltaTime,
                    _moveVector.z
                    );

            _characterController.Move(nextVelocity * Time.deltaTime);

            _moveVector = new Vector3();
        }

        public void Jump(float jumpPower)
        {
            _moveVector += new Vector3(0, jumpPower, 0);
        }

        public void MoveHorizontal(Vector3 moveVector)
        {
            _moveVector = moveVector.SetY(0);
        }
    }
}