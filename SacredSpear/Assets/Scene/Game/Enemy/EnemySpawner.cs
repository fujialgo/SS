using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] m_EnemyPrefs;

    float m_lowTable = 0;
    float m_hiTable = 1;

    float m_spawnTime;
    float m_timeTick;

    int m_enemyCnt;

    const int mkSpawnMax = 20;
    const float mkSpawnTimeMax = 1.2f;
    const float mkWaveAddtional = 0.3f;


    public int mWaveNum
    {
        get { return (int)(m_lowTable / mkWaveAddtional)+1; } 
    }

	// Use this for initialization
	void Start () {
        m_spawnTime = Random.Range(0, mkSpawnTimeMax);
        m_lowTable = 3;
        m_hiTable = 4;
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
        Debug.Log(m_lowTable + "low = hi" + m_hiTable);
        if (m_lowTable <= m_EnemyPrefs.Length-2)
        {
            m_lowTable += mkWaveAddtional;
        }
        if(m_hiTable <= m_EnemyPrefs.Length-1) {
            m_hiTable += mkWaveAddtional;
        }
        m_enemyCnt = 0;


    }



    //敵生成メソッド
    void mCreate()
    {
        int rand = (int)Random.Range(m_lowTable, m_hiTable);
//        Debug.Log(rand);
        var obj = Instantiate(m_EnemyPrefs[rand]);
        obj.transform.position = transform.position;
        m_enemyCnt++;
    }






}
