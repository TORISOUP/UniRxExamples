using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxExamples
{
    /// <summary>
    /// ボタンを３回押した時にTextに表示する
    /// </summary>
    public class BufferExample : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        [SerializeField]
        private Text text;

        private void Start()
        {
            button
                .OnClickAsObservable()
                .Buffer(3)
                .SubscribeToText(text, _ => text.text + "clicked\n");
        }
    }
}