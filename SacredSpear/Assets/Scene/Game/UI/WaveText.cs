using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveText : MonoBehaviour {

    void Update()
    {
        GetComponent<Text>().text = "Wave "+ GameInfo.mInstance.mWaveManager.mWaveNum.ToString();
    }

}
