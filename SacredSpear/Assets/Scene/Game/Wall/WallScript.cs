using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WallScript : MonoBehaviour {
    [SerializeField]
    private Text m_text;
    [SerializeField]
    private int m_hp;
    private int m_maxHp;
    public int mHp
    {
        get { return m_hp; }
        set { m_hp = Mathf.Clamp(value,0,m_maxHp); }
    }
    [SerializeField]
    private Point m_pointObj;

    private float m_HealMagnification = 1.0f;
    [SerializeField]
    private float m_HealPoint;
    // Use this for initialization
    void Start () {
        m_maxHp = mHp;
	}
	
	// Update is called once per frame
	void Update () {
        m_text.text = m_hp.ToString();
        if (m_hp <= 0)
        {
            DestroyObject(gameObject);
        }
	}

    public void mHealWall()
    {
        float healpoint = m_HealPoint * m_HealMagnification;
        if(m_pointObj.mPoint > (int)healpoint)
        {
            m_pointObj.mPoint -= (int)healpoint;
            mHp += (int)(m_maxHp * 0.3f);
            m_HealMagnification *= 1.2f;
        }
    }
}
