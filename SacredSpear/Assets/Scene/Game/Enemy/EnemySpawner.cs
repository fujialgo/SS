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

    // Use this for initialization
    void Start () {
        m_spawnTime = Random.Range(0, mkSpawnTimeMax);

#if UNITY_EDITOR
        m_lowTable = (GameInfo.mInstance.mWaveManager.mWaveNum) * mkWaveAddtional;
        m_hiTable = GameInfo.mInstance.mWaveManager.mWaveNum * mkWaveAddtional;
#endif
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
            float time = 4.0f;
            m_timeTick = -time;
            StartCoroutine(mToNextWave(time));
        }
	}

    //waveToNext
    IEnumerator mToNextWave(float time) {
        m_enemyCnt = 0;
        yield return new WaitForSeconds(time);

        if (m_lowTable <= m_EnemyPrefs.Length-2)
        {
            m_lowTable += mkWaveAddtional;
        }
        if(m_hiTable <= m_EnemyPrefs.Length-1) {
            m_hiTable += mkWaveAddtional;
        }

        GameInfo.mInstance.mWaveManager.mWaveNum++;
        yield break;
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
