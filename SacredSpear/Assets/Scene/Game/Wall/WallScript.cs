using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WallScript : MonoBehaviour {
    [SerializeField]
    private Text m_text;
    [SerializeField]
    private int m_hp;
    public int mHp
    {
        get { return m_hp; }
        set { m_hp = value; }
    }
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        m_text.text = m_hp.ToString();
        if (Input.GetKey(KeyCode.Space))
        {
            --m_hp;
            
        }

        if (m_hp <= 0)
        {
            DestroyObject(gameObject);
        }
	}
}
