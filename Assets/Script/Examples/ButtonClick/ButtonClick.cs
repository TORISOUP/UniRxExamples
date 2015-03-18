using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxExamples
{
    public class ButtonClick : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        [SerializeField]
        private Text text;

        private void Start()
        {
            button
                .OnClickAsObservable()
                .SubscribeToText(text, _ => text.text + "clicked\n");

        }
    }
}