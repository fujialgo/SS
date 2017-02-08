using UnityEngine;
using System.Collections;

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


    [SerializeField]
    float m_gameSpeed;
    public float mGameSpeed
    {
        get { return m_gameSpeed; }
        set { m_gameSpeed = value; }
    }


    public bool mIsPause
    {
        get; set;
    }

    [SerializeField]
    FadeManager m_fadeManager;
    string m_nextLoadSceneName;

    protected override void Awake()
    {
        m_fadeManager.gameObject.SetActive(true);
    }

    void Start()
    {
        GameInfo.mInstance.mGameSpeed = Time.timeScale;
        m_fadeManager.mFadeOut();
        mIsPause = false;
    }



    public void mSceneLoad(string str)
    {
        GameInfo.mInstance.mGameSpeed = 1.0f;
        m_nextLoadSceneName = str;
        m_fadeManager.mFadeIn();
    }

    public void mSceneActivate()
    {
        GetComponent<SceneLoader>().mSceneLoad(m_nextLoadSceneName);
    }

}
