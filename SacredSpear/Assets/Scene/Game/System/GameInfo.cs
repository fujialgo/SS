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

    [SerializeField]
    SceneLoader m_sceneLoader;
    public SceneLoader mSceneLoader
    {
        get { return m_sceneLoader; }
    }

    public bool mIsPause
    {
        get; set;
    }

    protected override void Awake()
    {
        base.Awake();
        mIsPause = false;
    }

}
