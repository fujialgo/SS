using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameInfo : Singleton<GameInfo> {
    [SerializeField]
    Point m_point;
    public Point mPoint
    {
        get { return m_point; }
    }

    [SerializeField]
    WaveManager m_waveManager;
    public WaveManager mWaveManager
    {
        get { return m_waveManager; }
    }


    public void mSceneChange(string str)
    {
        SceneManager.LoadScene(str);
    }

}
