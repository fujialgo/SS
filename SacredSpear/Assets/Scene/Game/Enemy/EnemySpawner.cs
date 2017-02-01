using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] m_EnemyPrefs;

    float m_lowTable = 0;
    float m_hiTable = 1;

    float m_spawnTime;
    float m_timeTick;
    int m_waveCount;

    int m_enemyCnt;

    const int mkSpawnMax = 20;
    const float mkSpawnTimeMax = 1.2f;
    const float mkWaveAddtional = 0.3f;


    public int mWaveNum
    {
        get { return (int)(m_lowTable / 0.2f)+1; } 
    }

	// Use this for initialization
	void Start () {
        m_spawnTime = Random.Range(0, mkSpawnTimeMax);
	}
	
	// Update is called once per frame
	void Update () {
        m_timeTick += Time.deltaTime;

        if(m_timeTick >= m_spawnTime)
        {
            m_timeTick = 0;
            m_spawnTime = Random.Range(0, mkSpawnTimeMax);
            mCreate();
        }

        if(m_enemyCnt >= mkSpawnMax)
        {
            mToNextWave();
        }
	}

    //waveToNext
    void mToNextWave() {
        if (m_lowTable <= m_EnemyPrefs.Length)
        {
            m_lowTable += mkWaveAddtional;
        }
        if(m_hiTable <= m_EnemyPrefs.Length) {
            m_hiTable += mkWaveAddtional;
        }
        m_enemyCnt = 0;


    }



    //敵生成メソッド
    void mCreate()
    {
        int rand = (int)Random.Range(m_lowTable, m_hiTable);
        Debug.Log(rand);
        var obj = Instantiate(m_EnemyPrefs[rand]);
        obj.transform.position = transform.position;
        m_enemyCnt++;
    }






}
