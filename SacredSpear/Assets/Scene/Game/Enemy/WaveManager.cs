using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

    [SerializeField]
    int m_waveCnt;

    public int mWaveNum
    {
        get { return m_waveCnt; }
        set { m_waveCnt = value; }
    }

}
