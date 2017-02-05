using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WallScript : MonoBehaviour {
    [SerializeField]
    private Image m_wallBar;

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
    [SerializeField]
    private SpriteChange m_wallHp;

    private float m_HealMagnification = 1.0f;
    [SerializeField]
    private float m_HealPoint;
    // Use this for initialization
    void Start () {
        m_maxHp = mHp;
	}

    // Update is called once per frame
    void Update()
    {
        m_wallBar.fillAmount = (float)m_hp / m_maxHp;
        if (m_hp <= 0)
        {
            m_wallHp.GetComponent<SpriteChange>().mSpriteChange();
            m_wallHp.GetComponent<SpriteChange>().mTextChange();

            DestroyObject(gameObject);
        }
        IfuseCheck();
    }

    //壁回復ボタンが使用可能かどうかのチェック
    void IfuseCheck()
    {
        if (m_HealPoint * m_HealMagnification < m_pointObj.mPoint)
        {
            m_wallHp.GetComponent<ButtonStateChange>().mSetInteractable(true);
        }
        else
        {
            m_wallHp.GetComponent<ButtonStateChange>().mSetInteractable(false);
        }

    }

    public void mHealWall()
    {
        float healpoint = m_HealPoint * m_HealMagnification;
        if(m_pointObj.mPoint > (int)healpoint)
        {
            m_pointObj.mPoint -= (int)healpoint;
            m_HealMagnification *= 1.2f;
            StartCoroutine(mHealAnim((int)(m_maxHp * 0.4f)+m_hp));
        }
    }

    IEnumerator mHealAnim(float val)
    {
        float accel = 1.1f;
        float vol = 1;
        while (true)
        {
            vol *= accel;
            m_hp += (int)vol;
            yield return null;
            if (m_hp >=val) yield break;
        }
    }
}
