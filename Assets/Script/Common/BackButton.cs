using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxExamples
{
    public class BackButton : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick
                .AsObservable()
                .Subscribe(_ => Application.LoadLevel(GameScenes.StartScene.ToString()));
        }
    }
}