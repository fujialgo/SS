using UnityEngine;
using System.Collections;

public class Spear: MonoBehaviour
{ 
    [SerializeField]
    public int m_power;
    [SerializeField]
    public int m_speed;

	private SpriteChange m_Spear;


    void Start()
    {
		
    }

    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(Vector3.up * m_speed * Time.deltaTime);
    }
		
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<EnemyMove>().mHp -= m_power;
            if (other.gameObject.GetComponent<EnemyMove>().mHp <=0)
            {
                other.gameObject.GetComponent<EnemyMove>().mDeath();
            }
        }
    }
}
