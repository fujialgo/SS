
using UnityEngine;
using System.Collections;

public class Spear: MonoBehaviour
{

    public int m_speed = 10;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.up * m_speed *Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<EnemyMove>().mDeath();
        }
    }
}
