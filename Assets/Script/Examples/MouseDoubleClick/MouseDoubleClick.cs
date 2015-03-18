using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxExamples
{
    public class MouseDoubleClick : ObservableMonoBehaviour
    {
        [SerializeField]
        private Text _text;

        private void Start()
        {
            base.Start();

            var clickStream = UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonDown(0));

            clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(200)))
                .Where(x => x.Count >= 2)
                .SubscribeToText(_text, x =>
                    string.Format("DoubleClick detected!\n Count:{0}", x.Count));
        }
    }
}