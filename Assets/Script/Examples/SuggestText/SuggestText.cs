#if UNITY_WEBPLAYER
#else
using System.Xml.Linq;
using UniRx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
#endif
using UnityEngine;
using UnityEngine.UI;

namespace UniRxExamples
{
    public class SuggestText : MonoBehaviour
    {
        [SerializeField]
        private InputField _inputField;

        [SerializeField]
        private Text _text;

        [SerializeField]
        private Text _errorText;

        private readonly string _apiUrlFormat
            = "http://www.google.com/complete/search?oe=utf_8&ie=utf_8&hl=ja&output=toolbar&q={0}";

#if UNITY_WEBPLAYER
    //WebPlayerではクロスドメイン制限があるので動作しない
#else
        private void Start()
        {

            _inputField
                .OnValueChangeAsObservable()
                .Throttle(TimeSpan.FromMilliseconds(200))
                .Where(word => word.Length > 0)
                .SelectMany(word => ObservableWWW.Get(string.Format(_apiUrlFormat, WWW.EscapeURL(word))))
                .Select(xml => XMLResultToStrings(xml)) //通信結果がXMLなのでパースする
                .Subscribe(suggestResults =>
                    _text.text =
                        suggestResults.Count() > 0
                            ? suggestResults.Aggregate((s, n) => s + n + System.Environment.NewLine)
                            : ""
                    , ex => _errorText.text = ex.ToString());

            _inputField
                .OnValueChangeAsObservable()
                .Where(word => word.Length == 0)
                .SubscribeToText(_text, _ => "");

        }

        /// <summary>
        /// GoogleSuggestAPIのXMLからSuggest文字列のシーケンスに変換する
        /// </summary>
        /// <param name="xmlString">対象のXML文字列</param>
        /// <returns>Suggest結果の文字列シーケンス</returns>
        private IEnumerable<string> XMLResultToStrings(string xmlString)
        {
            var xml = XDocument.Parse(xmlString);
            return xml
                .Descendants("CompleteSuggestion")
                .Elements(XName.Get("suggestion"))
                .Attributes("data")
                .Select(x => x.Value);
        }
#endif
    }

}