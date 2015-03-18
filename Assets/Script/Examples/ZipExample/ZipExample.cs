using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxExamples
{
    public class ZipExample : MonoBehaviour
    {
        [SerializeField]
        private Button button1;

        [SerializeField]
        private Button button2;

        [SerializeField]
        private Text text;

        private void Start()
        {
            button1.OnClickAsObservable()
                .Zip(
                    button2.OnClickAsObservable(),
                    (b1, b2) => "Clicked!"
                )
                .First()
                .Repeat()
                .SubscribeToText(text, x => text.text + x + "\n");

        }
    }
}