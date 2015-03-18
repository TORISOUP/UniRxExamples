using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlertOnWebPlayer : MonoBehaviour {

    private void Start()
    {
#if UNITY_WEBPLAYER
        GetComponent<Text>().text = "Not working on WebPlayer!";
#endif
    }

}
