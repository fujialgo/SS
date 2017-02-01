using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveText : MonoBehaviour {

    [SerializeField]
    EnemySpawner m_enemySpawner;

    void Update()
    {
        GetComponent<Text>().text = "Wave "+m_enemySpawner.mWaveNum.ToString();
    }

}
