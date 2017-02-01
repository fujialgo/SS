using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum eEnemyState {
    eWalk,eAttack,eDead,eMAX
}

public class EnemyMove : MonoBehaviour {
    [SerializeField]
    private int m_power;
    [SerializeField]
    private int m_hp;
    public int mHp
    {
        get { return m_hp; } set { m_hp = value; }
    }
    [SerializeField]
    private int m_score;

    [SerializeField]
    private int m_velocity;
    private Point m_pointObj;

    [SerializeField]
    private GameObject m_attackObjPrefs;

    public delegate void StateCall();
    protected StateCall[] m_stateFunc;
    protected eEnemyState m_stateNum;

    protected float m_timer;
	// Use this for initialization
	void Start () {
        //デリゲートによる分岐をしてみる
        m_stateNum = eEnemyState.eWalk;
        m_stateFunc = new StateCall[(int)eEnemyState.eMAX];
        m_stateFunc[(int)eEnemyState.eWalk] = mEnemyWalk;
        m_stateFunc[(int)eEnemyState.eAttack] = mEnemyAttack;
        m_stateFunc[(int)eEnemyState.eDead] = mEnemyDead;

        m_pointObj = GameObject.Find("Point").GetComponent<Point>();
	}

    // Update is called once per frame
    void Update()
    {
        m_stateFunc[(int)m_stateNum].Invoke();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Wall")
        {
            m_stateNum = eEnemyState.eAttack;
        }
    }

    //派生先でも記述可能とする
    protected virtual void mEnemyWalk()
    {
        transform.Translate(new Vector3(-1, 0) * m_velocity * Time.deltaTime);
    }
    protected virtual void mEnemyAttack()
    {
        m_timer += Time.deltaTime;
        if(m_timer >= 1)
        {
            mCreateAttack();
        }
    }
    protected virtual void mEnemyDead()
    {
        DestroyObject(gameObject);
    }

    protected void mCreateAttack()
    {
        var obj = Instantiate(m_attackObjPrefs) as GameObject;
        obj.GetComponent<EnemyAttackObj>().mPower = m_power;
        obj.transform.position = transform.position;
        m_timer = 0;
        StartCoroutine(mAttackCheck(obj));
    }

    private IEnumerator mAttackCheck(GameObject obj)
    {
        yield return new WaitForSeconds(0.5f);
        if (obj){
            m_stateNum = eEnemyState.eWalk;
            DestroyObject(obj);
        }
    }

    public void mDeath()
    {
        Destroy(gameObject.GetComponent<Collider2D>());
        m_pointObj.mPoint += m_score;   
        m_stateNum = eEnemyState.eDead;
    }
}
