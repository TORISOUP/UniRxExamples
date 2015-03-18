using UniRx;
using UnityEngine;

namespace UniRxExamples
{
    public class OnGrounded : ObservableMonoBehaviour
    {
        public override void Start()
        {
            base.Start();
            var characterController = GetComponent<CharacterController>();
            var particleSystem = GetComponentInChildren<ParticleSystem>();

            UpdateAsObservable()
                .Select(_ => characterController.isGrounded)
                .DistinctUntilChanged()
                .Where(x => x)
                .Subscribe(_ => particleSystem.Play());
        }
    }
}