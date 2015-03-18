using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;

namespace UniRxExamples
{
    public class OpenURLButton : TypedMonoBehaviour
    {

        private string baseUrl 
            = "https://github.com/TORISOUP/UniRxExamples/blob/master/Assets/Script/Examples";


        public override void Start()
        {
            var levelName = Application.loadedLevelName;
            var targetURL = string.Format("{0}/{1}/{1}.cs", baseUrl, levelName);


            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
#if UNITY_WEBPLAYER
                    var cmd = string.Format(("window.open('{0}','{1}')"),targetURL,levelName);
                    Application.ExternalEval(cmd);
#else
                    Application.OpenURL(targetURL);
#endif
                });
        }
    }
}