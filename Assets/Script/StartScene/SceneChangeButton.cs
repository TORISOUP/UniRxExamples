using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxExamples
{
    /// <summary>
    /// シーン遷移ボタン
    /// </summary>
    public class SceneChangeButton : MonoBehaviour
    {
        public GameScenes NextScene { get; set; }

        private void Start()
        {
            var button = GetComponent<Button>();

            button.onClick
                .AsObservable()
                .Subscribe(x => Application.LoadLevel(NextScene.ToString()));

            button.GetComponentInChildren<Text>().text
                = string.Format("{0}\n{1}", (int) NextScene, NextScene.ToString());
        }
    }
}