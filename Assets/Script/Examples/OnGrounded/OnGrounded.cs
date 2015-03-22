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

            //UpdateAsObservable()
            //    .Select(_ => characterController.isGrounded)
            //    .DistinctUntilChanged()
            //    .Where(x => x)
            //    .Subscribe(_ => particleSystem.Play());

            //毎フレーム変動を監視するならObserveEveryValueChangedが使える
            characterController
                .ObserveEveryValueChanged(x => x.isGrounded)
                .Where(x => x)
                .Subscribe(_ => particleSystem.Play());
        }
    }
}