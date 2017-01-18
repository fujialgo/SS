using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] enemyPrefs;

    int m_lowTable = 0;
    int m_hiTable = 1;

    float m_spawnTime;
    float m_timeTick;

    const float mkSpawnTimeMax = 1.2f;
	// Use this for initialization
	void Start () {
        m_spawnTime = Random.Range(0, mkSpawnTimeMax);
	}
	
	// Update is called once per frame
	void Update () {
        m_timeTick += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var obj = Instantiate(enemyPrefs[0]);
            obj.transform.position = transform.position;
        }

        if(m_timeTick >= m_spawnTime)
        {
            m_timeTick = 0;
            m_spawnTime = Random.Range(0, mkSpawnTimeMax);
            mCreate();
        }
	}

    void mCreate()
    {
        int rand = Random.Range(m_lowTable, m_hiTable);
        var obj = Instantiate(enemyPrefs[rand]);
        obj.transform.position = transform.position;
    }






}
