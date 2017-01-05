using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {


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
	
    void OnGUI()
    {
        GUILayout.Label(m_hp.ToString());
    }

	// Update is called once per frame
	void Update () {
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
