using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public int m_speed = 10;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * m_speed;
    }
}
