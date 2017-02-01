using UnityEngine;
using System.Collections;

public class Spear: Weapon
{
    void Start()
    {
        m_power = 1;
    }

    void Update()
    {
//        Debug.Log(m_power);

        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(Vector3.up * m_speed *Time.deltaTime);
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
