using System;
using System.Collections;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxExamples
{
    /// <summary>
    /// StartSceneのボタン群を生成する
    /// </summary>
    public class StartSceneSetup : MonoBehaviour
    {
        public GameObject sceneChangeButton;

        [SerializeField]
        private Image targetPanelImage;

        private void Start()
        {
            Application.targetFrameRate = 60;

            foreach (GameScenes next in Enum.GetValues(typeof (GameScenes))
                .Cast<GameScenes>().Where(next => next != GameScenes.StartScene))
            {
                CereateButton(next);
            }
           
        }


        private void CereateButton(GameScenes nextScene)
        {
            var button = Instantiate(sceneChangeButton);
            button.transform.SetParent(targetPanelImage.transform);

            button.GetComponent<SceneChangeButton>().NextScene = nextScene;
        }
    }
}